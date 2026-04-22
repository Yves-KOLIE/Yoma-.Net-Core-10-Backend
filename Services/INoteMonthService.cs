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
    private readonly SchoolEducationService _schoolEducationService;
    private readonly HightSchoolOptionService _hightSchoolOptionService;

    public NoteMonthService(Context context, SchoolYearService schoolYearService, SchoolEducationService schoolEducationService, HightSchoolOptionService hightSchoolOptionService)
    {
        _context = context;
        _schoolYearService = schoolYearService;
        _schoolEducationService = schoolEducationService;
        _hightSchoolOptionService = hightSchoolOptionService;
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
                if(noteMonth.IS_TRIMESTER_1 == false && noteMonth.IS_TRIMESTER_2 == false && noteMonth.IS_TRIMESTER_3 == false && noteMonth.IS_COMPOSITION_MONTH == false)
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
                else
                {
                    switch(noteMonth.EDUCATION_LEVEL.SCHOOL_EDUCATION_ID)
                    {
                        case 2: // Primaire
                            // await _context.NotePrimaries
                            //     .Where(x => 
                            //         x.SCHOOL_YEAR_ID == noteMonth.SCHOOL_YEAR_ID
                            //         && x.NOTE_MONTH_ID == noteMonth.MONTH_ID
                            //     )
                            // .ExecuteDeleteAsync();
                        break;

                        case 3: // Collège
                            // await _context.NoteMiddleSchools
                            //     .Where(x => 
                            //         x.SCHOOL_YEAR_ID == noteMonth.SCHOOL_YEAR_ID
                            //         && x.NOTE_MONTH_ID == noteMonth.MONTH_ID
                            //     )
                            // .ExecuteDeleteAsync();
                        break;

                        case 4: // Lycée
                            // await _context.NoteHightSchools
                            //     .Where(x => 
                            //         x.SCHOOL_YEAR_ID == noteMonth.SCHOOL_YEAR_ID
                            //         && x.NOTE_MONTH_ID == noteMonth.MONTH_ID
                            //     )
                            // .ExecuteDeleteAsync();
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