using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface IParentTypeService
{
    Task<IEnumerable<ParentType>> GetParentTypesAsync();
}

public class ParentTypeService : IParentTypeService
{
    private readonly Context _context;

    public ParentTypeService(Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ParentType>> GetParentTypesAsync()
    {
        return await _context.ParentTypes.AsNoTracking().ToListAsync();
    }
}