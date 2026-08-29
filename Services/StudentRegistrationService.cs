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
            // Creation du parent 1
            var parent1 = await _parentService.parentExist(studentRegistration.STUDENT!.PARENT_1);
            switch(parent1)
            {
                case null:
                    var newParent = await _parentService.addNewParent(studentRegistration.STUDENT.PARENT_1);
                    if(newParent != null)
                    {
                        studentRegistration.STUDENT.PARENT_1_ID = newParent.ID;
                        studentRegistration.STUDENT.PARENT_1 = newParent;
                    }
                break;

                case 1: // l'email existe
                    await transaction.RollbackAsync();
                    return new SaveResult
                    {
                        success = false,
                        message = "L'adresse email du Père ou du tuteur existe déjà dans notre base de données"
                    };

                case 2: // Le téléphone existe
                    await transaction.RollbackAsync();
                    return new SaveResult
                    {
                        success = false,
                        message = "Le numéro de téléphone du Père ou du tuteur existe déjà dans notre base de données"
                    };
            }

            // Creation du parent 2
            var parent2 = await _parentService.parentExist(studentRegistration.STUDENT!.PARENT_2);
            switch(parent2)
            {
                case null:
                    var newParent = await _parentService.addNewParent(studentRegistration.STUDENT.PARENT_2);
                    if(newParent != null)
                    {
                        studentRegistration.STUDENT.PARENT_2_ID = newParent.ID;
                        studentRegistration.STUDENT.PARENT_2 = newParent;
                    }
                break;

                case 1: // l'email existe
                    await transaction.RollbackAsync();
                    return new SaveResult
                    {
                        success = false,
                        message = "L'adresse email de la mère ou de la tutrice existe déjà dans notre base de données"
                    };

                case 2: // Le téléphone existe
                    await transaction.RollbackAsync();
                    return new SaveResult
                    {
                        success = false,
                        message = "Le numéro de téléphone de la mère ou de la tutrice existe déjà dans notre base de données"
                    };
            }

            // Création de l'élève
            studentRegistration.STUDENT.MATRICULE = MatriculeGenerator.GenererMatricule(studentRegistration.STUDENT.SURNAME, studentRegistration.STUDENT.NAME, studentRegistration.STUDENT.BIRTH_DAY_DATE);
            var matricule = await _context.Students.FirstOrDefaultAsync(x => x.MATRICULE == studentRegistration.STUDENT.MATRICULE);
            if(matricule != null)
            {
                await transaction.RollbackAsync();
                return new SaveResult
                {
                    success = false,
                    message = studentRegistration.STUDENT.SEXE == 'M' ?
                    "Le matricule de cet élève existe déjà dans notre base de données"
                    : "Le matricule de cette élève existe déjà dans notre base de données"
                };
            }
            else
            {
                var student = await _studentService.AddStudentAsync(studentRegistration.STUDENT);
                if(student == null)
                {
                    await transaction.RollbackAsync();
                    return new SaveResult
                    {
                        success = false,
                        message = studentRegistration.STUDENT.SEXE == 'M' ?
                        "L'adresse email de cet élève existe déjà dans notre base de données"
                        : "L'adresse email de cette élève existe déjà dans notre base de données"
                    };
                }
                else
                {
                    switch(studentRegistration.STUDENT_SCHOOL_STATUS_OF_CARE_ID)
                    {
                        case 1: // Normal
                            var schoolFess = await _context.SchoolFesses.FirstOrDefaultAsync(x => 
                                x.SCHOOL_YEAR_ID == studentRegistration.SCHOOL_YEAR_ID
                                && x.EDUCATION_LEVEL_ID == studentRegistration.EDUCATION_LEVEL_ID
                            );

                            if(schoolFess != null)
                            {
                                studentRegistration.REGISTRATION_FESS = schoolFess.REGISTRATION_FESS;
                                studentRegistration.PRICE_FESS_1 = schoolFess.PRICE_FESS_1;
                                studentRegistration.PRICE_FESS_2 = schoolFess.PRICE_FESS_2;
                                studentRegistration.PRICE_FESS_3 = schoolFess.PRICE_FESS_3;
                            }
                            else
                            {
                                studentRegistration.REGISTRATION_FESS = 0;
                                studentRegistration.PRICE_FESS_1 = 0;
                                studentRegistration.PRICE_FESS_2 = 0;
                                studentRegistration.PRICE_FESS_3 = 0;
                            }
                        break;

                        case 3: // Pris en charge
                            studentRegistration.REGISTRATION_FESS = 0;
                            studentRegistration.PRICE_FESS_1 = 0;
                            studentRegistration.PRICE_FESS_2 = 0;
                            studentRegistration.PRICE_FESS_3 = 0;
                        break;
                    }

                    studentRegistration.STUDENT_ID = student.ID;

                    await _context.StudentRegistrations.AddAsync(studentRegistration);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return new SaveResult
                    {
                        success = true,
                        message = "Inscription réussie"
                    };
                }
            }
        }
        catch (DbUpdateException ex)
        {
            await transaction.RollbackAsync();
            var innerMessage = ex.InnerException?.Message ?? ex.Message;
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