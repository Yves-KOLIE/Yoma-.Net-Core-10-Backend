using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface IStudentRegistration
{
    Task<StudentRegistration> CreateStudentRegistrationAsync(StudentRegistration studentRegistration);
    Task<StudentRegistration> UpdateStudentRegistrationAsync(StudentRegistration studentRegistration);
}

public class StudentRegistrationService : IStudentRegistration
{
    private readonly Context _context;

    public StudentRegistrationService(Context context)
    {
        _context = context;
    }

    public async Task<StudentRegistration> CreateStudentRegistrationAsync(StudentRegistration studentRegistration)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            if(studentRegistration.SCHOOL_FESS_IS_SUPPORTED) // Si les frais de scolarité sont pris en charge par l'école
            {
                studentRegistration.REGISTRATION_FESS = 0;
                studentRegistration.PRICE_FESS_1 = 0;
                studentRegistration.PRICE_FESS_2 = 0;
                studentRegistration.PRICE_FESS_3 = 0;
            }
            else if(studentRegistration.SCHOOL_FESS_IS_DISCOUNTED == false)
            {
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
            }

            if(studentRegistration.BUS_PRICE_IS_SUPPORTED)
            {
                studentRegistration.BUS_PRICE_1 = null;
                studentRegistration.BUS_PRICE_2 = null;
                studentRegistration.BUS_PRICE_2 = null;
            }
            else if(studentRegistration.BUS_PRICE_IS_DISCOUNTED == false)
            {
                var busFesses = await _context.BusFesses.FirstOrDefaultAsync(x => 
                    x.SCHOOL_YEAR_ID == studentRegistration.SCHOOL_YEAR_ID
                );

                if(busFesses != null)
                {
                    studentRegistration.BUS_PRICE_1 = studentRegistration.IS_SUBSCRIBE_TO_THE_BUS_FESS_1 ? busFesses.PRICE_FESS_1 : null;
                    studentRegistration.BUS_PRICE_2 = studentRegistration.IS_SUBSCRIBE_TO_THE_BUS_FESS_2 ? busFesses.PRICE_FESS_2 : null;
                    studentRegistration.BUS_PRICE_3 = studentRegistration.IS_SUBSCRIBE_TO_THE_BUS_FESS_3 ? busFesses.PRICE_FESS_3 : null;
                }
                else
                {
                    studentRegistration.BUS_PRICE_1 = null;
                    studentRegistration.BUS_PRICE_2 = null;
                    studentRegistration.BUS_PRICE_2 = null;
                }
            }

            studentRegistration.CREATION_DATE = DateTime.UtcNow;

            studentRegistration.AVERAGE_QUARTER_1 = 0.00f;
            studentRegistration.AVERAGE_QUARTER_2 = 0.00f;
            studentRegistration.AVERAGE_QUARTER_3 = 0.00f;
            studentRegistration.ANNUAL_AVERAGE = 0.00f;

            _context.StudentRegistrations.Add(studentRegistration);
            await _context.SaveChangesAsync();

            if(studentRegistration.EDUCATION_LEVEL.IS_EXAM_CLASS)
            {
                var newExamClass = new ExamClass
                {
                    ID = 0,
                    IS_ADMITTED = false,
                    CREATED_USER_ID = null,
                    UPDATED_USER_ID = null,
                    CREATION_DATE = DateTime.UtcNow,
                    MODIFICATION_DATE = null,
                    STUDENT_REGISTRATION_ID = studentRegistration.ID,
                    STUDENT_REGISTRATION = studentRegistration
                };

                _context.ExamClasses.Add(newExamClass);
                await _context.SaveChangesAsync();
            }

            var noteMonthList = await _context.NoteMonths
                .Where(X =>
                    X.SCHOOL_YEAR_ID == studentRegistration.SCHOOL_YEAR_ID
                    && X.EDUCATION_LEVEL_ID == studentRegistration.EDUCATION_LEVEL_ID
                    && (
                        X.IS_TRIMESTER_1 == true 
                        || X.IS_TRIMESTER_2 == true 
                        || X.IS_TRIMESTER_3 == true
                        || X.IS_COMPOSITION_MONTH == true
                    )
                )
            .ToListAsync();

            if(noteMonthList.Count > 0)
            {
                var coursList = await _context.Cours
                    .Where(x =>
                        x.SCHOOL_YEAR_ID == studentRegistration.SCHOOL_YEAR_ID
                        && x.EDUCATION_LEVEL_ID == studentRegistration.EDUCATION_LEVEL_ID
                        && x.IS_ACTIVE == true
                    )
                .ToListAsync();

                if(coursList.Count > 0)
                {
                    var student = await _context.Students.FirstOrDefaultAsync(x => x.ID == studentRegistration.STUDENT_ID);

                    foreach(var noteMonth in noteMonthList)
                    {
                        foreach(var cours in coursList)
                        {
                            switch(noteMonth.EDUCATION_LEVEL.SCHOOL_EDUCATION_ID)
                            {
                                case 2: // Primaire
                                    var newNotePrimary = new NotePrimary
                                    {
                                        ID = 0,
                                        NOTE = 0.00f,
                                        INFOS = null,
                                        CREATED_USER_ID = null,
                                        UPDATED_USER_ID = null,
                                        CREATION_DATE = DateTime.UtcNow,
                                        MODIFICATION_DATE = DateTime.UtcNow,
                                        SCHOOL_YEAR_ID = noteMonth.SCHOOL_YEAR_ID,
                                        SCHOOL_YEAR = noteMonth.SCHOOL_YEAR,
                                        STUDENT_ID = studentRegistration.ID,
                                        STUDENT = student!,
                                        NOTE_MONTH_ID = noteMonth.ID,
                                        NOTE_MONTH = noteMonth,
                                        COURS_ID = cours.ID,
                                        COURS = cours
                                    };
                                    _context.NotePrimaries.Add(newNotePrimary);
                                break;

                                case 3: // Collège
                                    var newNoteMiddleSchool = new NoteMiddleSchool
                                    {
                                        ID = 0,
                                        NOTE = 0.00f,
                                        INFOS = null,
                                        CREATED_USER_ID = null,
                                        UPDATED_USER_ID = null,
                                        CREATION_DATE = DateTime.UtcNow,
                                        MODIFICATION_DATE = DateTime.UtcNow,
                                        SCHOOL_YEAR_ID = noteMonth.SCHOOL_YEAR_ID,
                                        SCHOOL_YEAR = noteMonth.SCHOOL_YEAR,
                                        STUDENT_ID = studentRegistration.ID,
                                        STUDENT = student!,
                                        NOTE_MONTH_ID = noteMonth.ID,
                                        NOTE_MONTH = noteMonth,
                                        COURS_ID = cours.ID,
                                        COURS = cours
                                    };
                                    _context.NoteMiddleSchools.Add(newNoteMiddleSchool);
                                break;

                                case 4: // Lycée
                                    var newNoteHightSchool = new NoteHightSchool
                                    {
                                        ID = 0,
                                        NOTE = 0.00f,
                                        INFOS = null,
                                        CREATED_USER_ID = null,
                                        UPDATED_USER_ID = null,
                                        CREATION_DATE = DateTime.UtcNow,
                                        MODIFICATION_DATE = DateTime.UtcNow,
                                        SCHOOL_YEAR_ID = noteMonth.SCHOOL_YEAR_ID,
                                        SCHOOL_YEAR = noteMonth.SCHOOL_YEAR,
                                        STUDENT_ID = studentRegistration.ID,
                                        STUDENT = student!,
                                        NOTE_MONTH_ID = noteMonth.ID,
                                        NOTE_MONTH = noteMonth,
                                        COURS_ID = cours.ID,
                                        COURS = cours
                                    };
                                    _context.NoteHightSchools.Add(newNoteHightSchool);
                                break;
                            }
                        }
                    }
                }
            }
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
        }
        return studentRegistration;
    }

    public async Task<StudentRegistration> UpdateStudentRegistrationAsync(StudentRegistration studentRegistration)
    {
        _context.StudentRegistrations.Update(studentRegistration);
        await _context.SaveChangesAsync();
        return studentRegistration;
    }
}