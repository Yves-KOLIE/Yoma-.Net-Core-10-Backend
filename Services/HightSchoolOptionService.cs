using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface IHightSchoolOptionService
{
    Task<IEnumerable<HighSchoolOption>> GetHighSchoolOptionsAsync();
}

public class HightSchoolOptionService : IHightSchoolOptionService
{
    private readonly Context _context;

    public HightSchoolOptionService(Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HighSchoolOption>> GetHighSchoolOptionsAsync()
    {
        return await _context.HighSchoolOptions.AsNoTracking().ToListAsync();
    }
}