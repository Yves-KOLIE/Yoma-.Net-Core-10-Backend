using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface ITypePrimeService
{
    Task<TypePrime> CreateTypePrimeAsync(TypePrime typePrime);
    Task<TypePrime> UpdateTypePrimeAsync(TypePrime typePrime);
    Task<IEnumerable<TypePrime>> BatchUpdateTypePrimesAsync(List<TypePrime> typePrimes);
    Task<TypePrime?> GetTypePrimeAsync(int id);
    Task<IEnumerable<TypePrime>> GetTypePrimesAsync();
}

public class TypePrimeService : ITypePrimeService
{
    private readonly Context _context;

    public TypePrimeService(Context context)
    {
        _context = context;
    }

    public async Task<TypePrime> CreateTypePrimeAsync(TypePrime typePrime)
    {
        _context.TypePrimes.Add(typePrime);
        await _context.SaveChangesAsync();
        return typePrime;
    }

    public async Task<TypePrime> UpdateTypePrimeAsync(TypePrime typePrime)
    {
        _context.TypePrimes.Update(typePrime);
        await _context.SaveChangesAsync();
        return typePrime;
    }

    public async Task<IEnumerable<TypePrime>> BatchUpdateTypePrimesAsync(List<TypePrime> typePrimes)
    {
        _context.TypePrimes.UpdateRange(typePrimes);
        await _context.SaveChangesAsync();
        return typePrimes;
    }

    public async Task<TypePrime?> GetTypePrimeAsync(int id)
    {
        return await _context.TypePrimes.AsNoTracking().FirstOrDefaultAsync(tp => tp.ID == id);
    }

    public async Task<IEnumerable<TypePrime>> GetTypePrimesAsync()
    {
        return await _context.TypePrimes.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<TypePrime>> GetTypePrimeBatchAsync(int[] ids)
    {
        return await _context.TypePrimes.Where(tp => ids.Contains(tp.ID)).AsNoTracking().ToListAsync();
    }

    public async Task<SchoolYear?> GetActivedSchoolYear()
    {
        return await _context.SchoolYears.AsNoTracking().FirstOrDefaultAsync(sy => sy.IS_ACTIVE == true);
    }
}