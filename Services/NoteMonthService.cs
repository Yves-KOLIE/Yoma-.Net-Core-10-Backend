using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface INoteMonthService
{
    Task<IEnumerable<NoteMonth>> GetNoteMonthsByYearAsync(int? schoolYearId = null);
    Task<IEnumerable<NoteMonth>> BatchUpdateNoteMonthsAsync(List<NoteMonth> monthsOfSalaries);
}

public class NoteMonthService : INoteMonthService
{
    private readonly Context _context;
    private readonly SchoolYearService _schoolYearService;

    public NoteMonthService(Context context, SchoolYearService schoolYearService)
    {
        _context = context;
        _schoolYearService = schoolYearService;
    }

    public async Task<IEnumerable<NoteMonth>> GetNoteMonthsByYearAsync(int? schoolYearId = null)
    {
        schoolYearId = schoolYearId ?? (await _schoolYearService.GetActivedSchoolYear())?.ID ?? 0;

        var noteMonths = await _context.NoteMonths
            .Where(mos => mos.SCHOOL_YEAR_ID == schoolYearId)
            .Include(m => m.MONTH)
            .Include(sh => sh.SCHOOL_YEAR)
            .Include(el => el.EDUCATION_LEVEL).ThenInclude(x => x.SCHOOL_EDUCATION)
            .Include(el => el.EDUCATION_LEVEL).ThenInclude(x => x.HIGH_SCHOOL_OPTION)
            .OrderBy(mos => mos.ID)
            .AsNoTracking()
        .ToListAsync();

        foreach (var noteMonth in noteMonths)
        {
            switch(noteMonth.EDUCATION_LEVEL.SCHOOL_EDUCATION_ID)
            {
                case 2: // Primaire
                    var notePrimary = await _context.NotePrimaries.FirstOrDefaultAsync(x => 
                        x.SCHOOL_YEAR_ID == schoolYearId
                        && x.NOTE_MONTH_ID == noteMonth.MONTH_ID
                        && x.NOTE > 0
                    );
                    if(notePrimary != null) noteMonth.IS_DISABLED = true;
                break;

                case 3: // Collège
                    var noteMiddleSchool = await _context.NoteMiddleSchools.FirstOrDefaultAsync(x => 
                        x.SCHOOL_YEAR_ID == schoolYearId
                        && x.NOTE_MONTH_ID == noteMonth.MONTH_ID
                        && x.NOTE > 0
                    );
                    if(noteMiddleSchool != null) noteMonth.IS_DISABLED = true;
                break;

                case 4: // Lycée
                    var noteHightSchool = await _context.NoteHightSchools.FirstOrDefaultAsync(x =>
                        x.SCHOOL_YEAR_ID == schoolYearId
                        && x.NOTE_MONTH_ID == noteMonth.MONTH_ID
                        && x.NOTE > 0
                    );
                    if(noteHightSchool != null) noteMonth.IS_DISABLED = true;
                break;
            }
        } 

        return noteMonths;
    }
    
    public async Task<IEnumerable<NoteMonth>> BatchUpdateNoteMonthsAsync(List<NoteMonth> noteMonths)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            foreach (var noteMonth in noteMonths)
            {
                // bool isExamClasses = IsExamClasses(noteMonth.EDUCATION_LEVEL);
                if(noteMonth.IS_TRIMESTER_1 == true || noteMonth.IS_TRIMESTER_2 == true || noteMonth.IS_TRIMESTER_3 == true || noteMonth.IS_COMPOSITION_MONTH == true)
                {
                    // Liste des élèves inscrits
                    var studentRegistrations = await _context.StudentRegistrations
                        .Where(x => 
                            x.SCHOOL_YEAR_ID == noteMonth.SCHOOL_YEAR_ID
                            & x.EDUCATION_LEVEL_ID == noteMonth.EDUCATION_LEVEL_ID
                        )
                    .ToListAsync();

                    // Liste des cours pour ce niveau d'études
                    var cours = await _context.Cours
                        .Where(x => 
                            x.SCHOOL_YEAR_ID == noteMonth.SCHOOL_YEAR_ID
                            && x.EDUCATION_LEVEL_ID == noteMonth.EDUCATION_LEVEL_ID
                            && x.IS_ACTIVE == true
                        )
                    .ToListAsync();
  
                    switch(noteMonth.EDUCATION_LEVEL.SCHOOL_EDUCATION_ID)
                    {
                        case 2: // Primaire
                            foreach(var cour in cours)
                            {
                                foreach(var studentRegistration in studentRegistrations)
                                {
                                    // On vérifie que cet élève n'a pas une note dans la table
                                    var oldNode = await _context.NotePrimaries.FirstOrDefaultAsync(x => 
                                        x.SCHOOL_YEAR_ID == noteMonth.SCHOOL_YEAR_ID
                                        && x.STUDENT_ID == studentRegistration.ID
                                        && x.NOTE_MONTH_ID == noteMonth.ID
                                        && x.COURS_ID == cour.ID
                                    );

                                    if(oldNode == null)
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
                                            SCHOOL_YEAR_ID = noteMonth.SCHOOL_YEAR_ID,
                                            SCHOOL_YEAR = noteMonth.SCHOOL_YEAR,
                                            STUDENT_ID = studentRegistration.ID,
                                            STUDENT = student!,
                                            NOTE_MONTH_ID = noteMonth.ID,
                                            NOTE_MONTH = noteMonth,
                                            COURS_ID = cour.ID,
                                            COURS = cour
                                        };
                                        _context.NotePrimaries.Add(newNotePrimary);
                                    }
                                }
                            }
                        break;

                        case 3: // Collège
                            foreach(var cour in cours)
                            {
                                foreach(var studentRegistration in studentRegistrations)
                                {
                                    // On vérifie que cet élève n'a pas une note dans la table
                                    var oldNode = await _context.NoteMiddleSchools.FirstOrDefaultAsync(x => 
                                        x.SCHOOL_YEAR_ID == noteMonth.SCHOOL_YEAR_ID
                                        && x.STUDENT_ID == studentRegistration.ID
                                        && x.NOTE_MONTH_ID == noteMonth.ID
                                        && x.COURS_ID == cour.ID
                                    );

                                    if(oldNode == null)
                                    {
                                        var student = await _context.Students.FirstOrDefaultAsync(x => x.ID == studentRegistration.STUDENT_ID);
                                        var newNote = new NoteMiddleSchool
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
                                            COURS_ID = cour.ID,
                                            COURS = cour
                                        };
                                        _context.NoteMiddleSchools.Add(newNote);
                                    }

                                }
                            }
                        break;

                        case 4: // Lycée
                            foreach(var cour in cours)
                            {
                                foreach(var studentRegistration in studentRegistrations)
                                {
                                    // On vérifie que cet élève n'a pas une note dans la table
                                    var oldNode = await _context.NoteHightSchools.FirstOrDefaultAsync(x => 
                                        x.SCHOOL_YEAR_ID == noteMonth.SCHOOL_YEAR_ID
                                        && x.STUDENT_ID == studentRegistration.ID
                                        && x.NOTE_MONTH_ID == noteMonth.ID
                                        && x.COURS_ID == cour.ID
                                    );

                                    if(oldNode == null)
                                    {
                                        var student = await _context.Students.FirstOrDefaultAsync(x => x.ID == studentRegistration.STUDENT_ID);                                    
                                        var newNote = new NoteHightSchool
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
                                            COURS_ID = cour.ID,
                                            COURS = cour
                                        };
                                        _context.NoteHightSchools.Add(newNote);
                                    }
                                }
                            }
                        break;
                    }
                }
                else
                {
                    switch(noteMonth.EDUCATION_LEVEL.SCHOOL_EDUCATION_ID)
                    {
                        case 2: // Primaire
                            await _context.NotePrimaries
                                .Where(x => 
                                    x.SCHOOL_YEAR_ID == noteMonth.SCHOOL_YEAR_ID
                                    && x.NOTE_MONTH_ID == noteMonth.MONTH_ID
                                )
                            .ExecuteDeleteAsync();
                        break;

                        case 3: // Collège
                            await _context.NoteMiddleSchools
                                .Where(x => 
                                    x.SCHOOL_YEAR_ID == noteMonth.SCHOOL_YEAR_ID
                                    && x.NOTE_MONTH_ID == noteMonth.MONTH_ID
                                )
                            .ExecuteDeleteAsync();
                        break;

                        case 4: // Lycée
                            await _context.NoteHightSchools
                                .Where(x => 
                                    x.SCHOOL_YEAR_ID == noteMonth.SCHOOL_YEAR_ID
                                    && x.NOTE_MONTH_ID == noteMonth.MONTH_ID
                                )
                            .ExecuteDeleteAsync();
                        break;
                    }
                }
            } 

            _context.NoteMonths.UpdateRange(noteMonths);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
        }

        return noteMonths;
    }

}