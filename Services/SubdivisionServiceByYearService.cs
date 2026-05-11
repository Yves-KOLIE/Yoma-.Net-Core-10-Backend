using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;
using YOMA.Models.Views;

public interface ISubdivisionServiceByYearService
{
    Task<IEnumerable<SubdivisionByYear>> GetSubdivisionByYearsAsync(int? schoolYearId = null);
    Task<List<SubdivisionByYearViewModel>> BatchUpdateSubdivisionByYearAsync(List<SubdivisionByYearViewModel> subdivisionByYearViewModelList);
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
            .Include(sy => sy.SCHOOL_YEAR)
            .Include(sy => sy.SUBDIVISION)
            .Include(sy => sy.EDUCATION_LEVEL)
                .ThenInclude(se => se.SCHOOL_EDUCATION)
            .Include(sy => sy.EDUCATION_LEVEL)
                .ThenInclude(se => se.HIGH_SCHOOL_OPTION)
            .OrderBy(sy => sy.ID)
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

    public async Task<List<SubdivisionByYearViewModel>> BatchUpdateSubdivisionByYearAsync(List<SubdivisionByYearViewModel> subdivisionByYearViewModelList)
    {   
        var updates = subdivisionByYearViewModelList
            .SelectMany(s => s.SUBDIVISION_BY_YEAR_LIST)
            .Select(sb => new { ID = sb.ID, IS_CHECK = sb.IS_CHECK })
        .ToList();

        // Étape 2: Charger TOUTES les entités en une seule requête (évite N+1)
        var ids = updates.Select(u => u.ID).Distinct().ToList();
        var entitiesToUpdate = await _context.SubdivisionByYears
            .Where(sy => ids.Contains(sy.ID))
            .AsNoTracking()
        .ToDictionaryAsync(sy => sy.ID);

        foreach (var update in updates)
        {
            if (entitiesToUpdate.TryGetValue(update.ID, out var entity))
            {
                entity.IS_CHECK = update.IS_CHECK;
            }
        }

        await _context.SaveChangesAsync();
        return subdivisionByYearViewModelList;
    }
}