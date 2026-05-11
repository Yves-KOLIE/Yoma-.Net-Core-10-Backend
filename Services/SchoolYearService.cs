using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface ISchoolYearService
{
    Task<SchoolYear> CreateSchoolYearAsync(SchoolYear schoolYear);
    Task<SchoolYear> UpdateSchoolYearAsync(SchoolYear schoolYear);
    Task<IEnumerable<SchoolYear>> BatchUpdateSchoolYearsAsync(List<SchoolYear> schoolYears);
    Task<SchoolYear?> GetSchoolYearAsync(int id);
    Task<IEnumerable<SchoolYear>> GetSchoolYearsAsync();
    Task<IEnumerable<SchoolYear>> GetSchoolYearBatchAsync(int[] ids);
    Task<SchoolYear?> GetActivedSchoolYear();
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

    public async Task<IEnumerable<SchoolYear>> BatchUpdateSchoolYearsAsync(List<SchoolYear> schoolYears)
    {
        _context.SchoolYears.UpdateRange(schoolYears);
        await _context.SaveChangesAsync();
        return schoolYears;
    }

    public async Task<SchoolYear?> GetSchoolYearAsync(int id)
    {
        return await _context.SchoolYears.AsNoTracking().FirstOrDefaultAsync(sy => sy.ID == id);
    }

    public async Task<IEnumerable<SchoolYear>> GetSchoolYearsAsync()
    {
        return await _context.SchoolYears.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<SchoolYear>> GetSchoolYearBatchAsync(int[] ids)
    {
        return await _context.SchoolYears.Where(sy => ids.Contains(sy.ID)).AsNoTracking().ToListAsync();
    }

    public async Task<SchoolYear?> GetActivedSchoolYear()
    {
        return await _context.SchoolYears.AsNoTracking().FirstOrDefaultAsync(sy => sy.IS_ACTIVE == true);
    }
}