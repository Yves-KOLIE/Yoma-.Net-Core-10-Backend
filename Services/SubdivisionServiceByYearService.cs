using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;
using YOMA.Models.Views;

public interface ISubdivisionServiceByYearService
{
    Task<IEnumerable<SubdivisionByYear>> GetSubdivisionByYearsAsync(int? schoolYearId = null);
    Task<bool> BatchUpdateSubdivisionByYearAsync(List<SubdivisionByYear> subdivisionByYearList);
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

    public async Task<bool> BatchUpdateSubdivisionByYearAsync(List<SubdivisionByYear> subdivisionByYearList)
    {   
        try
        {
            foreach(var su in subdivisionByYearList)
            {
                await _context.SubdivisionByYears.Where(x => x.ID == su.ID)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.IS_CHECK, p => su.IS_CHECK)
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