using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface ISubdivisionService
{
    Task<IEnumerable<Subdivision>> GetBanksAsync();
}

public class SubdivisionService : ISubdivisionService
{
    private readonly Context _context;

    public SubdivisionService(Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Subdivision>> GetBanksAsync()
    {
        return await _context.Subdivisions.AsNoTracking().ToListAsync();
    }
}