using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;
using YOMA.Models.Views;

public interface ISubdivisionServiceByYearService
{
    Task<IEnumerable<SubdivisionByYear>> GetSubdivisionByYearsAsync(int? schoolYearId = null);
    Task<bool> BatchUpdateSubdivisionByYearAsync(List<SubdivisionByYear> subdivisionByYearList);
    Task<List<SubdivisionByYearViewModel>> GetSubdivisionByYearsViewModelAsync(IEnumerable<SubdivisionByYear> subdivisionByYears, int? schoolYearId = null);
}

public class SubdivisionByYearService : ISubdivisionServiceByYearService
{
    private readonly Context _context;
    private readonly SchoolYearService _schoolYearService;
    private readonly EducationLevelService _educationLevelService;

    public SubdivisionByYearService(Context context, SchoolYearService schoolYearService, EducationLevelService educationLevelService)
    {
        _context = context;
        _schoolYearService = schoolYearService;
        _educationLevelService = educationLevelService;
    }

    public async Task<IEnumerable<SubdivisionByYear>> GetSubdivisionByYearsAsync(int? schoolYearId = null)
    {
        schoolYearId = schoolYearId ?? (await _schoolYearService.GetActivedSchoolYear())?.ID ?? 0;
        var subdivisionByYearsList = await _context.SubdivisionByYears
            .Where(sy => sy.SCHOOL_YEAR_ID == schoolYearId)
            .Include(sy => sy.SUBDIVISION)
            .Include(sy => sy.SCHOOL_YEAR)
            .Include(sy => sy.EDUCATION_LEVEL).ThenInclude(se => se.HIGH_SCHOOL_OPTION)
            .Include(sy => sy.EDUCATION_LEVEL).ThenInclude(se => se.SCHOOL_EDUCATION)
            .OrderBy(sy => sy.EDUCATION_LEVEL.ID)
            .ThenBy(sy => sy.SUBDIVISION.DESCRIPTION)
            .AsNoTracking()
        .ToListAsync();

        var educationLevels = await _educationLevelService.GetEducationLevelsByYearIdAsync(schoolYearId ?? 0);
        var educationLevelDict = educationLevels.ToDictionary(el => el.ID, el => el);

        foreach (var subdivisionByYear in subdivisionByYearsList)
        {
            var key = new { subdivisionByYear.SCHOOL_YEAR_ID, subdivisionByYear.EDUCATION_LEVEL_ID, subdivisionByYear.SUBDIVISION_ID };
            subdivisionByYear.EDUCATION_LEVEL.STUDENT_REGISTRATED_COUNT = educationLevelDict.TryGetValue(subdivisionByYear.EDUCATION_LEVEL_ID, out var educationLevel) ? educationLevel.STUDENT_REGISTRATED_COUNT : 0;
        }

        return subdivisionByYearsList;
    }

    public async Task<List<SubdivisionByYearViewModel>> GetSubdivisionByYearsViewModelAsync(IEnumerable<SubdivisionByYear> subdivisionByYears, int? schoolYearId = null)
    {
        var educationLevels = await _context.EducationLevels
            .AsNoTracking()
            .Include(x => x.HIGH_SCHOOL_OPTION)
            .OrderBy(x => x.ID)
        .ToListAsync();

        var updatedRows = new List<SubdivisionByYearViewModel>();

        foreach (var educationLevel in educationLevels)
        {
            var subdivisionList = subdivisionByYears
                .Where(sy => sy.EDUCATION_LEVEL_ID == educationLevel.ID && sy.SUBDIVISION.IS_ACTIVE == true)
                .OrderBy(sy => sy.EDUCATION_LEVEL_ID)
            .ToList();

            var subdivisionByYearsList = new List<SubdivisionByYear>();

            foreach (var subdivision in subdivisionList) subdivisionByYearsList.Add(subdivision);                    

            updatedRows.Add(new SubdivisionByYearViewModel
            {
                SCHOOL_YEAR_ID = schoolYearId,
                EDUCATION_LEVEL = (educationLevel.DESCRIPTION + " " + educationLevel?.HIGH_SCHOOL_OPTION?.ABBREVIATION).Trim(),
                SUBDIVISION_BY_YEAR_LIST = subdivisionByYearsList
            });
        }

        if(schoolYearId == null)
        {
            var activeYear = await _schoolYearService.GetActivedSchoolYear();
            if(activeYear != null) updatedRows.ForEach(f => f.SCHOOL_YEAR_ID = activeYear.ID);
        }

        return updatedRows;
    }

    public async Task<bool> BatchUpdateSubdivisionByYearAsync(List<SubdivisionByYear> subdivisionByYearList)
    {   
        try
        {
            foreach(var su in subdivisionByYearList)
            {
                await _context.SubdivisionByYears.Where(x => x.ID == su.ID)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.IS_CHECK, p => su.IS_CHECK)
                    .SetProperty(p => p.NUMBER_OF_SEAT, p => su.NUMBER_OF_SEAT)
                );
            }

            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }

    }
}