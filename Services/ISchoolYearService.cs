using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface ISchoolYearService
{
    Task<SchoolYear> CreateSchoolYearAsync(SchoolYear schoolYear);
    Task<SchoolYear> UpdateSchoolYearAsync(SchoolYear schoolYear);
    Task<SchoolYear?> GetSchoolYearAsync(int id);
    Task<IEnumerable<SchoolYear>> GetSchoolYearsAsync();
    Task<IEnumerable<SchoolYear>> GetSchoolYearBatchAsync(int[] ids);
}

public class SchoolYearService : ISchoolYearService
{
    private readonly Context _context;

    public SchoolYearService(Context context)
    {
        _context = context;
    }

    public async Task<SchoolYear> CreateSchoolYearAsync(SchoolYear schoolYear)
    {
        _context.SchoolYears.Add(schoolYear);
        await _context.SaveChangesAsync();
        return schoolYear;
    }

    public async Task<SchoolYear> UpdateSchoolYearAsync(SchoolYear schoolYear)
    {
        _context.SchoolYears.Update(schoolYear);
        await _context.SaveChangesAsync();
        return schoolYear;
    }

    public async Task<SchoolYear?> GetSchoolYearAsync(int id)
    {
        return await _context.SchoolYears.FindAsync(id);
    }

    public async Task<IEnumerable<SchoolYear>> GetSchoolYearsAsync()
    {
        return await _context.SchoolYears.ToListAsync();
    }

    public async Task<IEnumerable<SchoolYear>> GetSchoolYearBatchAsync(int[] ids)
    {
        return await _context.SchoolYears.Where(sy => ids.Contains(sy.ID)).ToListAsync();
    }

}