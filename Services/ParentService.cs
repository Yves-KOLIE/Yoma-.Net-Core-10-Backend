using Microsoft.EntityFrameworkCore;
using YOMA.Helpers;
using YOMA.Models;
using YOMA.Models.Tables;

public interface IParentService
{
    Task<Parent> addNewParent(Parent parent);
    Task<bool> parentUserEmailExist(Parent parent);
    Task<Parent?> parentExist(Parent parent);
    Task<List<Parent>> searchParentsByPhone(string telephone, char sexe);
}

public class ParentService : IParentService
{
    private readonly Context _context;

    public ParentService(Context context)
    {
        _context = context;
    }

    public async Task<Parent> addNewParent(Parent parent)
    {
        parent.PASSWORD = PasswordHelper.HashPassword();
        if(!string.IsNullOrEmpty(parent?.USER_EMAIL?.EMAIL))
        {
            UserEmail userEmail = new UserEmail
            {
                ID                = 0,
                EMAIL             = parent.USER_EMAIL.EMAIL,
                IS_ACTIVE         = true,
                CREATED_USER_ID   = parent.CREATED_USER_ID,
                UPDATED_USER_ID   = null,
                CREATION_DATE     = parent.CREATION_DATE,
                MODIFICATION_DATE = null,
                USER_TYPE_ID      = 3 // Parents
            };
            await _context.UserEmails.AddAsync(userEmail);
            await _context.SaveChangesAsync();

            parent.USER_EMAIL_ID = userEmail.ID;
            parent.USER_EMAIL = userEmail;
        }
        else
        {
            parent!.USER_EMAIL_ID = null;
            parent.USER_EMAIL = null;
        }

        parent!.USER_ROLE_ID = 12; // Parent d'élève
        await _context.Parents.AddAsync(parent);
        await _context.SaveChangesAsync();
        return parent;
    }

    public async Task<bool> parentUserEmailExist(Parent parent)
    {
        var userEmail = await _context.UserEmails.FirstOrDefaultAsync(x => 
            parent.USER_EMAIL != null 
            && parent.USER_EMAIL.EMAIL != null 
            && x.EMAIL.Equals(parent.USER_EMAIL.EMAIL)
        );

        return userEmail != null;
    }

    public async Task<Parent?> parentExist(Parent parent)
    {
        if(!string.IsNullOrEmpty(parent.USER_EMAIL?.EMAIL))
        {
            return await _context.Parents
            .Include(x => x.USER_EMAIL)
            .FirstOrDefaultAsync(x => 
                (x.USER_EMAIL!.EMAIL == parent.USER_EMAIL.EMAIL)
                || x.ID == parent.ID
            );
        }
        return null;
    }

    public async Task<List<Parent>> searchParentsByPhone(string telephone, char sexe)
    {
        return await _context.Parents.Where(x => 
            x.SEXE == sexe
            && x.TELEPHONE_1 == telephone
            ||
            (
                x.TELEPHONE_2 != null && x.TELEPHONE_2 == telephone
            )
        ).ToListAsync();
    }
}