using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface ICourService
{
    Task<Cours> CreateCoursAsync(Cours cours);
    Task<Cours> UpdateCoursAsync(Cours cours);
}

public class CoursService : ICourService
{
    private readonly Context _context;

    public CoursService(Context context)
    {
        _context = context;
    }

    public async Task<Cours> CreateCoursAsync(Cours cours)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // Liste des élèves inscrits
            var studentRegistrations = await _context.StudentRegistrations
                .Where(x => 
                    x.SCHOOL_YEAR_ID == cours.SCHOOL_YEAR_ID
                    & x.EDUCATION_LEVEL_ID == cours.EDUCATION_LEVEL_ID
                )
            .ToListAsync();

            var noteMonths = await _context.NoteMonths
                .Where(mos => mos.SCHOOL_YEAR_ID == cours.SCHOOL_YEAR_ID)
                .Include(m => m.MONTH)
                .Include(sh => sh.SCHOOL_YEAR)
                .Include(el => el.EDUCATION_LEVEL).ThenInclude(x => x.SCHOOL_EDUCATION)
                .Include(el => el.EDUCATION_LEVEL).ThenInclude(x => x.HIGH_SCHOOL_OPTION)
                .OrderBy(mos => mos.ID)
                .AsNoTracking()
            .ToListAsync();

            var primaryNoteMonths = noteMonths.Where(x =>
                x.EDUCATION_LEVEL_ID == cours.EDUCATION_LEVEL_ID
            ).ToList();

            foreach(var studentRegistration in studentRegistrations)
            {
                switch(cours.EDUCATION_LEVEL.SCHOOL_EDUCATION_ID)
                {
                    case 2: // Primaire
                        foreach(var primaryNoteMonth in primaryNoteMonths)
                        {
                            var student = await _context.Students.FirstOrDefaultAsync(x => x.ID == studentRegistration.STUDENT_ID);
                            var newNotePrimary = new NotePrimary
                            {
                                ID = 0,
                                NOTE = 0.00f,
                                INFOS = null,
                                CREATED_USER_ID = null,
                                UPDATED_USER_ID = null,
                                CREATION_DATE = DateTime.UtcNow,
                                MODIFICATION_DATE = DateTime.UtcNow,
                                SCHOOL_YEAR_ID = cours.SCHOOL_YEAR_ID,
                                SCHOOL_YEAR = cours.SCHOOL_YEAR,
                                STUDENT_ID = studentRegistration.ID,
                                STUDENT = student!,
                                NOTE_MONTH_ID = primaryNoteMonth.ID,
                                NOTE_MONTH = primaryNoteMonth,
                                COURS_ID = cours.ID,
                                COURS = cours
                            };
                            _context.NotePrimaries.Add(newNotePrimary);
                        }
                    break;

                    case 3: // Collège
                        foreach(var primaryNoteMonth in primaryNoteMonths)
                        {
                            var student = await _context.Students.FirstOrDefaultAsync(x => x.ID == studentRegistration.STUDENT_ID);
                            var newNotePrimary = new NoteMiddleSchool
                            {
                                ID = 0,
                                NOTE = 0.00f,
                                INFOS = null,
                                CREATED_USER_ID = null,
                                UPDATED_USER_ID = null,
                                CREATION_DATE = DateTime.UtcNow,
                                MODIFICATION_DATE = DateTime.UtcNow,
                                SCHOOL_YEAR_ID = cours.SCHOOL_YEAR_ID,
                                SCHOOL_YEAR = cours.SCHOOL_YEAR,
                                STUDENT_ID = studentRegistration.ID,
                                STUDENT = student!,
                                NOTE_MONTH_ID = primaryNoteMonth.ID,
                                NOTE_MONTH = primaryNoteMonth,
                                COURS_ID = cours.ID,
                                COURS = cours
                            };
                            _context.NoteMiddleSchools.Add(newNotePrimary);
                        }
                    break;

                    case 4: // Lycée
                        foreach(var primaryNoteMonth in primaryNoteMonths)
                        {
                            var student = await _context.Students.FirstOrDefaultAsync(x => x.ID == studentRegistration.STUDENT_ID);
                            var newNotePrimary = new NoteHightSchool
                            {
                                ID = 0,
                                NOTE = 0.00f,
                                INFOS = null,
                                CREATED_USER_ID = null,
                                UPDATED_USER_ID = null,
                                CREATION_DATE = DateTime.UtcNow,
                                MODIFICATION_DATE = DateTime.UtcNow,
                                SCHOOL_YEAR_ID = cours.SCHOOL_YEAR_ID,
                                SCHOOL_YEAR = cours.SCHOOL_YEAR,
                                STUDENT_ID = studentRegistration.ID,
                                STUDENT = student!,
                                NOTE_MONTH_ID = primaryNoteMonth.ID,
                                NOTE_MONTH = primaryNoteMonth,
                                COURS_ID = cours.ID,
                                COURS = cours
                            };
                            _context.NoteHightSchools.Add(newNotePrimary);
                        }
                    break;
                }
            }

            _context.Cours.Add(cours);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
        }
        return cours;
    }

    public async Task<Cours> UpdateCoursAsync(Cours cours)
    {
        _context.Cours.Update(cours);
        await _context.SaveChangesAsync();
        return cours;
    }
}