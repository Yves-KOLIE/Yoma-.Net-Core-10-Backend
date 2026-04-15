using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface ISalaryOfMonthService
{
    Task<IEnumerable<MonthOfSalary>> BatchUpdateMonthOfSalariesAsync(List<MonthOfSalary> monthsOfSalaries);
    Task<IEnumerable<MonthOfSalary>> GetMonthsOfSalariesByYearAsync(int? schoolYearId = null);
}

public class MonthOfSalaryService : ISalaryOfMonthService
{
    private readonly Context _context;
    private readonly SchoolYearService _schoolYearService;

    public MonthOfSalaryService(Context context, SchoolYearService schoolYearService)
    {
        _context = context;
        _schoolYearService = schoolYearService;
    }

    public async Task<IEnumerable<MonthOfSalary>> GetMonthsOfSalariesByYearAsync(int? schoolYearId = null)
    {
        int id = schoolYearId ?? (await _schoolYearService.GetActivedSchoolYear())?.ID ?? 0;
        return await _context.MonthOfSalaries
            .Where(mos => mos.SCHOOL_YEAR_ID == id)
            .Include(m => m.MONTH)
            .Include(sh => sh.SCHOOL_YEAR)
            .OrderBy(mos => mos.ID)
            .AsNoTracking()
        .ToListAsync();
    }
    
    public async Task<IEnumerable<MonthOfSalary>> BatchUpdateMonthOfSalariesAsync(List<MonthOfSalary> monthsOfSalaries)
    {
        _context.MonthOfSalaries.UpdateRange(monthsOfSalaries);
        await _context.SaveChangesAsync();
        return monthsOfSalaries;
    }

}