using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface IBusFessService
{
    Task<BusFess> CreateBusFessAsync(BusFess busFess);
    Task<BusFess> UpdateBusFessAsync(BusFess busFess);
    Task<BusFess?> GetBusFessAsync(int id);
    Task<IEnumerable<BusFess>> GetBusFessesAsync();
}

public class BusFessService : IBusFessService
{
    private readonly Context _context;

    public BusFessService(Context context)
    {
        _context = context;
    }

    public async Task<BusFess> CreateBusFessAsync(BusFess busFess)
    {
        _context.BusFesses.Add(busFess);
        await _context.SaveChangesAsync();
        return busFess;
    }

    public async Task<BusFess> UpdateBusFessAsync(BusFess busFess)
    {
        _context.BusFesses.Update(busFess);
        await _context.SaveChangesAsync();
        return busFess;
    }

    public async Task<BusFess?> GetBusFessAsync(int id)
    {
        return await _context.BusFesses
            .Include(bf => bf.SCHOOL_YEAR)
            .AsNoTracking()
        .FirstOrDefaultAsync(bf => bf.ID == id);
    }

    public async Task<IEnumerable<BusFess>> GetBusFessesAsync()
    {
        return await _context.BusFesses
            .Include(bf => bf.SCHOOL_YEAR)
            .AsNoTracking()
        .ToListAsync();
    }
}