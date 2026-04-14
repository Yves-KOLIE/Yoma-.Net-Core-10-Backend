using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface IBirthPlaceService
{
    Task<BirthPlace> CreateBirthPlaceAsync(BirthPlace birthPlace);
    Task<BirthPlace> UpdateBirthPlaceAsync(BirthPlace birthPlace);
    Task<IEnumerable<BirthPlace>> BatchUpdateBirthPlacesAsync(List<BirthPlace> birthPlaces);
    Task<BirthPlace?> GetBirthPlaceAsync(int id);
    Task<IEnumerable<BirthPlace>> GetBirthPlacesAsync();
    Task<IEnumerable<BirthPlace>> GetBirthPlaceBatchAsync(int[] ids);
}

public class BirthPlaceService : IBirthPlaceService
{
    private readonly Context _context;

    public BirthPlaceService(Context context)
    {
        _context = context;
    }

    public async Task<BirthPlace> CreateBirthPlaceAsync(BirthPlace birthPlace)
    {
        _context.BirthPlaces.Add(birthPlace);
        await _context.SaveChangesAsync();
        return birthPlace;
    }

    public async Task<BirthPlace> UpdateBirthPlaceAsync(BirthPlace birthPlace)
    {
        _context.BirthPlaces.Update(birthPlace);
        await _context.SaveChangesAsync();
        return birthPlace;
    }

    public async Task<IEnumerable<BirthPlace>> BatchUpdateBirthPlacesAsync(List<BirthPlace> birthPlaces)
    {
        _context.BirthPlaces.UpdateRange(birthPlaces);
        await _context.SaveChangesAsync();
        return birthPlaces;
    }

    public async Task<BirthPlace?> GetBirthPlaceAsync(int id)
    {
        return await _context.BirthPlaces.AsNoTracking().FirstOrDefaultAsync(b => b.ID == id);
    }

    public async Task<IEnumerable<BirthPlace>> GetBirthPlacesAsync()
    {
        return await _context.BirthPlaces.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<BirthPlace>> GetBirthPlaceBatchAsync(int[] ids)
    {
        return await _context.BirthPlaces.Where(b => ids.Contains(b.ID)).AsNoTracking().ToListAsync();
    }
}