using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;


public interface IEducationLevelService
{
    Task<IEnumerable<EducationLevel>> GetEducationLevelsByYearIdAsync(int schoolYearId);
}


public class EducationLevelService : IEducationLevelService
{
    private readonly Context _context;

    public EducationLevelService(Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EducationLevel>> GetEducationLevelsByYearIdAsync(int schoolYearId)
    {
        var educationLevels = await _context.EducationLevels
            .LeftJoin(
                _context.Set<StudentRegistration>(),
                el => el.ID,
                sr => sr.EDUCATION_LEVEL_ID,
                (el, sr) => el
            )
            .Include(el => el.SCHOOL_EDUCATION)
            .Include(el => el.HIGH_SCHOOL_OPTION)
            .OrderBy(el => el.ID)
            .AsNoTracking()
        .ToListAsync();

        var sudentRegistrationsCount = await _context.StudentRegistrations
            .Where(sr => sr.SCHOOL_YEAR_ID == schoolYearId && sr.IS_DELETED == false)
            .GroupBy(sr => sr.EDUCATION_LEVEL_ID)
            .Select(g => new { g.Key, Count = g.Count() })
            .AsNoTracking()
        .ToDictionaryAsync(x => x.Key, x => x.Count);

        foreach (var el in educationLevels)
        {
            el.STUDENT_REGISTRATED_COUNT = sudentRegistrationsCount.GetValueOrDefault(el.ID, 0);
        }
        
        return educationLevels;
    }
}