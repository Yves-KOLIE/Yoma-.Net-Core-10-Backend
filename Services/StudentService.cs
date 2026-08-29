using Microsoft.EntityFrameworkCore;
using YOMA.Helpers;
using YOMA.Models;
using YOMA.Models.Tables;

public interface IStudentService
{
    Task<Student?> AddStudentAsync(Student student);
    Task<Student> UpdateStudentAsync(Student student);
}

public class StudentService : IStudentService
{
    private readonly Context _context;

    public StudentService(Context context)
    {
        _context = context;
    }

    public async Task<Student?> AddStudentAsync(Student student)
    {
        student.PASSWORD = PasswordHelper.HashPassword();
        if(!string.IsNullOrEmpty(student.USER_EMAIL?.EMAIL))
        {
            var checkEmail = await _context.UserEmails.FirstOrDefaultAsync(x => x.EMAIL == student.USER_EMAIL.EMAIL);
            if(checkEmail != null) return null;
            
            // On vérifie que l'existence de cet eleve
            UserEmail userEmail = new UserEmail
            {
                ID                = 0,
                EMAIL             = student.USER_EMAIL.EMAIL,
                IS_ACTIVE         = true,
                CREATED_USER_ID   = student.CREATED_USER_ID,
                UPDATED_USER_ID   = null,
                CREATION_DATE     = student.CREATION_DATE,
                MODIFICATION_DATE = null,
                USER_TYPE_ID      = 2 // Eleves
            };

            await _context.UserEmails.AddAsync(userEmail);
            await _context.SaveChangesAsync();

            student.USER_EMAIL_ID = userEmail.ID;
            student.USER_EMAIL = userEmail;
        }
        else
        {
            student.USER_EMAIL_ID = null;
            student.USER_EMAIL = null;
        }
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task<Student> UpdateStudentAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
        return student;
    }
}