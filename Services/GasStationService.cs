using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface IGasStationService
{
    Task<GasStation> CreateGasStationAsync(GasStation gasStation);
    Task<GasStation> UpdateGasStationAsync(GasStation gasStation);
    Task<IEnumerable<GasStation>> BatchUpdateGasStationsAsync(List<GasStation> gasStations);
    Task<GasStation?> GetGasStationAsync(int id);
    Task<IEnumerable<GasStation>> GetGasStationsAsync();
}

public class GasStationService : IGasStationService
{
    private readonly Context _context;

    public GasStationService(Context context)
    {
        _context = context;
    }

    public async Task<GasStation> CreateGasStationAsync(GasStation gasStation)
    {
        _context.GasStations.Add(gasStation);
        await _context.SaveChangesAsync();
        return gasStation;
    }

    public async Task<GasStation> UpdateGasStationAsync(GasStation gasStation)
    {
        _context.GasStations.Update(gasStation);
        await _context.SaveChangesAsync();
        return gasStation;
    }

    public async Task<IEnumerable<GasStation>> BatchUpdateGasStationsAsync(List<GasStation> gasStations)
    {
        _context.GasStations.UpdateRange(gasStations);
        await _context.SaveChangesAsync();
        return gasStations;
    }

    public async Task<GasStation?> GetGasStationAsync(int id)
    {
        return await _context.GasStations.AsNoTracking().FirstOrDefaultAsync(gs => gs.ID == id);
    }

    public async Task<IEnumerable<GasStation>> GetGasStationsAsync()
    {
        return await _context.GasStations.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<GasStation>> GetGasStationBatchAsync(int[] ids)
    {
        return await _context.GasStations.Where(gs => ids.Contains(gs.ID)).AsNoTracking().ToListAsync();
    }
}