using Microsoft.EntityFrameworkCore;
using YOMA;
using YOMA.Helpers;
using YOMA.Models;
using YOMA.Models.Tables;

public interface IStudentRegistration
{
    Task<SaveResult> registerStudentAsync(StudentRegistration studentRegistration);
    Task<StudentRegistration> UpdateStudentRegistrationAsync(StudentRegistration studentRegistration);
}

public class StudentRegistrationService : IStudentRegistration
{
    private readonly Context _context;
    private readonly StudentService _studentService;
    private readonly ParentService _parentService;

    public StudentRegistrationService(Context context, StudentService studentService, ParentService parentService)
    {
        _context = context;
        _studentService = studentService;
        _parentService = parentService;
    }

    public async Task<SaveResult> registerStudentAsync(StudentRegistration studentRegistration)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // Création de userEmail
            var studentUserEmail = await _context.UserEmails.FirstOrDefaultAsync(x => 
                studentRegistration.STUDENT.USER_EMAIL != null
                && studentRegistration.STUDENT.USER_EMAIL.EMAIL != null 
                && x.EMAIL.Equals(studentRegistration.STUDENT.USER_EMAIL.EMAIL)
            );

            if(studentUserEmail != null)
            {
                await transaction.RollbackAsync();
                return new SaveResult
                {
                    success = false,
                    message = "L'adresse email de cet élève existe déjà dans notre base de données"
                };
            }
            else
            {
                studentRegistration.STUDENT.PASSWORD = PasswordHelper.HashPassword();
                if(!string.IsNullOrEmpty(studentRegistration.STUDENT?.USER_EMAIL?.EMAIL))
                {
                    UserEmail newStudentUserEmail = new UserEmail
                    {
                        ID                = 0,
                        EMAIL             = studentRegistration.STUDENT.USER_EMAIL.EMAIL,
                        IS_ACTIVE         = true,
                        CREATED_USER_ID   = studentRegistration.CREATED_USER_ID,
                        CREATION_DATE     = studentRegistration.CREATION_DATE,
                        UPDATED_USER_ID   = null,
                        MODIFICATION_DATE = null,
                        USER_TYPE_ID      = 2 // Eleves
                    };
                    
                    await _context.UserEmails.AddAsync(newStudentUserEmail);
                    await _context.SaveChangesAsync();
                    studentRegistration.STUDENT.USER_EMAIL_ID = newStudentUserEmail.ID;
                }

                var parent1 = await _parentService.parentExist(studentRegistration.STUDENT!.PARENT_1.PARENT);
                if(parent1 == null)
                {
                    // Creation du parent 1
                    await _parentService.addNewParent(studentRegistration.STUDENT.PARENT_1.PARENT);
                }
                else
                {
                    await transaction.RollbackAsync();
                    return new SaveResult
                    {
                        success = false,
                        message = "L'adresse email du Père ou du tuteur existe déjà dans notre base de données"
                    };
                }

                var parent2 = await _parentService.parentExist(studentRegistration.STUDENT.PARENT_2.PARENT);
                if(parent2 == null)
                {
                    // Creation du parent 2
                    await _parentService.addNewParent(studentRegistration.STUDENT.PARENT_2.PARENT);
                }
                else
                {
                    await transaction.RollbackAsync();
                    return new SaveResult
                    {
                        success = false,
                        message = "L'adresse email de la mère ou de la tutrice existe déjà dans notre base de données"
                    };
                }


                await _context.Students.AddAsync(studentRegistration.STUDENT);
                await _context.SaveChangesAsync();

                await _context.StudentRegistrations.AddAsync(studentRegistration);
                await _context.SaveChangesAsync();

                // await transaction.CommitAsync();
                await transaction.RollbackAsync();
                return new SaveResult
                {
                    success = true,
                    message = "Inscription réussie"
                };
            }
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return new SaveResult
            {
                success = false,
                message = "Une erreur s'est produite pendant la création du dossier de l'élève"
            };
        }
    }


    public async Task<StudentRegistration> UpdateStudentRegistrationAsync(StudentRegistration studentRegistration)
    {
        _context.StudentRegistrations.Update(studentRegistration);
        await _context.SaveChangesAsync();
        return studentRegistration;
    }
}