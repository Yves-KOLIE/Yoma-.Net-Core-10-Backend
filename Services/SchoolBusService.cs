using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface ISchoolBusService
{
    Task<SchoolBus> CreateSchoolBusAsync(SchoolBus schoolBus);
    Task<SchoolBus> UpdateSchoolBusAsync(SchoolBus schoolBus);
    Task<IEnumerable<SchoolBus>> GetSchoolBusAsync();
}

public class SchoolBusService : ISchoolBusService
{
    private readonly Context _context;

    public SchoolBusService(Context context)
    {
        _context = context;
    }

    public async Task<SchoolBus> CreateSchoolBusAsync(SchoolBus schoolBus)
    {
        _context.SchoolBuses.Add(schoolBus);
        await _context.SaveChangesAsync();
        return schoolBus;
    }

    public async Task<SchoolBus> UpdateSchoolBusAsync(SchoolBus schoolBus)
    {
        _context.SchoolBuses.Update(schoolBus);
        await _context.SaveChangesAsync();
        return schoolBus;
    }

    public async Task<IEnumerable<SchoolBus>> GetSchoolBusAsync()
    {
        return await _context.SchoolBuses.AsNoTracking().ToListAsync();
    }

}