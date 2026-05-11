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
        schoolYearId = schoolYearId ?? (await _schoolYearService.GetActivedSchoolYear())?.ID ?? 0;

        var monthsOfSalaries = await _context.MonthOfSalaries
            .Where(mos => mos.SCHOOL_YEAR_ID == schoolYearId)
            .Include(m => m.MONTH)
            .Include(sh => sh.SCHOOL_YEAR)
            .OrderBy(mos => mos.ID)
            .AsNoTracking()
        .ToListAsync();

        var monthlySalaryAssignments = await _context.MonthlySalaryAssignments
            .Where(msa => msa.SCHOOL_YEAR_ID == schoolYearId)
            .Select(msa => msa.MONTH_IDS)
        .ToListAsync();

        var coveredMonthIds = monthlySalaryAssignments
            .SelectMany(ids => ids)
        .ToHashSet();

        foreach (var monthOfSalary in monthsOfSalaries)
        {
            if (coveredMonthIds.Contains(monthOfSalary.MONTH_ID))
            {
                monthOfSalary.IS_DISABLED = true;
            }
        }

        return monthsOfSalaries;
    }
    
    public async Task<IEnumerable<MonthOfSalary>> BatchUpdateMonthOfSalariesAsync(List<MonthOfSalary> monthsOfSalaries)
    {
        _context.MonthOfSalaries.UpdateRange(monthsOfSalaries);
        await _context.SaveChangesAsync();
        return monthsOfSalaries;
    }

}