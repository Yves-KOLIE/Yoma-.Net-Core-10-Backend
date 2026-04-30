using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface IUserTypeService
{
    Task<IEnumerable<UserType>> GetUserTypesAsync();
}

public class UserTypeService : IUserTypeService
{
    private readonly Context _context;

    public UserTypeService(Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserType>> GetUserTypesAsync()
    {
        return await _context.UserTypes.AsNoTracking().ToListAsync();
    }
}