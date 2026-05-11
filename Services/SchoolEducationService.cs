using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface ISchoolEducationService
{
    Task<IEnumerable<SchoolEducation>> GetSchoolEducationsAsync();
}

public class SchoolEducationService : ISchoolEducationService
{
    private readonly Context _context;

    public SchoolEducationService(Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SchoolEducation>> GetSchoolEducationsAsync()
    {
        return await _context.SchoolEducations.AsNoTracking().ToListAsync();
    }
}