using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface ISchoolYearService
{
    Task<SchoolYear> CreateSchoolYearAsync(SchoolYear schoolYear);
    Task<SchoolYear> UpdateSchoolYearAsync(SchoolYear schoolYear);
    Task<SchoolYear> DeleteSchoolYearAsync(SchoolYear schoolYear);
    Task<IEnumerable<SchoolYear>> BatchUpdateSchoolYearsAsync(List<SchoolYear> schoolYears);
    Task<SchoolYear?> GetSchoolYearAsync(int id);
    Task<IEnumerable<SchoolYear>> GetSchoolYearsAsync();
    Task<IEnumerable<SchoolYear>> GetSchoolYearBatchAsync(int[] ids);
    Task<SchoolYear?> GetActivedSchoolYear();
}

public class SchoolYearService : ISchoolYearService
{
    private readonly Context _context;

    public SchoolYearService(Context context)
    {
        _context = context;
    }

    private async Task CopyBusFessesAsync(SchoolYear? lastSchoolYear, SchoolYear schoolYear)
    {
        if(lastSchoolYear != null)
        {
            // Frais de bus de l'année précédente
            var busFessesRecords = await _context.BusFesses
                .Where(b => b.SCHOOL_YEAR_ID == lastSchoolYear.ID)
                .AsNoTracking()
            .ToListAsync();

            // Créer de nouvelles instances pour l'insertion
            var newBusFessesRecords = busFessesRecords.Select(b => new BusFess
            {
                ID = 0,
                PRICE_FESS_1 = b.PRICE_FESS_1,
                PRICE_FESS_2 = b.PRICE_FESS_2,
                PRICE_FESS_3 = b.PRICE_FESS_3,
                CREATED_USER_ID = schoolYear.CREATED_USER_ID,
                UPDATED_USER_ID = schoolYear.UPDATED_USER_ID,
                CREATION_DATE = DateTime.UtcNow,
                MODIFICATION_DATE = null,
                DEADLINE_FESS_1 = b.DEADLINE_FESS_1,
                DEADLINE_FESS_2 = b.DEADLINE_FESS_2,
                DEADLINE_FESS_3 = b.DEADLINE_FESS_3,
                SCHOOL_YEAR_ID = schoolYear.ID,
            }).ToList();
            _context.BusFesses.AddRange(newBusFessesRecords);
        }
        else
        {
            var newBusFesses = new BusFess {
                SCHOOL_YEAR_ID = schoolYear.ID,
                PRICE_FESS_1 = 100000,
                PRICE_FESS_2 = 100000,
                PRICE_FESS_3 = 100000,
                CREATION_DATE = DateTime.UtcNow,
                MODIFICATION_DATE = null,
                CREATED_USER_ID = schoolYear.CREATED_USER_ID,
                UPDATED_USER_ID = schoolYear.UPDATED_USER_ID,
            };
            _context.BusFesses.Add(newBusFesses);
        }
        await _context.SaveChangesAsync();
    }

    private async Task CopyCoursAsync(SchoolYear lastSchoolYear, SchoolYear schoolYear)
    {
        // Cours de l'année précédente
        var coursRecords = await _context.Cours
            .Where(b => b.SCHOOL_YEAR_ID == lastSchoolYear.ID)
            .AsNoTracking()
        .ToListAsync();

        // Créer de nouvelles instances pour l'insertion
        var newCoursRecords = coursRecords.Select(b => new Cours
        {
            ID = 0,
            DESCRIPTION = b.DESCRIPTION,
            CODE = b.CODE,
            IS_ACTIVE = b.IS_ACTIVE,
            COEFFICIENT = b.COEFFICIENT,
            CREATED_USER_ID = schoolYear.CREATED_USER_ID,
            UPDATED_USER_ID = schoolYear.UPDATED_USER_ID,
            CREATION_DATE = schoolYear.CREATION_DATE,
            MODIFICATION_DATE = schoolYear.MODIFICATION_DATE,
            SCHOOL_YEAR_ID = schoolYear.ID,
            SCHOOL_YEAR = schoolYear,
            EDUCATION_LEVEL_ID = b.EDUCATION_LEVEL_ID,
        }).ToList();
        _context.Cours.AddRange(newCoursRecords);
        await _context.SaveChangesAsync();
    }

    private async Task CopyNoteMonthAsync(SchoolYear schoolYear)
    {
        // Mois de l'année
        var monthRecords = await _context.Months
            .AsNoTracking()
        .ToListAsync();

        // Niveau d'étude
        var educationLevelRecords = await _context.EducationLevels
            .AsNoTracking()
        .ToListAsync();

        List<NoteMonth> newNoteMonthRecords = new List<NoteMonth>();
        foreach(var educationLevel in educationLevelRecords)
        {
            foreach(var month in monthRecords)
            {
                newNoteMonthRecords.Add(new NoteMonth
                {
                    ID = 0,
                    IS_COMPOSITION_MONTH = false,
                    IS_TRIMESTER_1 = false,
                    IS_TRIMESTER_2 = false,
                    IS_TRIMESTER_3 = false,
                    CREATED_USER_ID = schoolYear.CREATED_USER_ID,
                    UPDATED_USER_ID = schoolYear.UPDATED_USER_ID,
                    CREATION_DATE = schoolYear.CREATION_DATE,
                    MODIFICATION_DATE = schoolYear.MODIFICATION_DATE,
                    SCHOOL_YEAR_ID = schoolYear.ID,
                    SCHOOL_YEAR = schoolYear,
                    MONTH_ID = month.ID,
                    EDUCATION_LEVEL_ID = educationLevel.ID
                });
            }
        }
        _context.NoteMonths.AddRange(newNoteMonthRecords);
        await _context.SaveChangesAsync();
    }

    private async Task CopySchoolFessAsync(SchoolYear? lastSchoolYear, SchoolYear schoolYear)
    {
        if(lastSchoolYear != null)
        {
            // Frais scolaires de l'année précédente
            var schoolFessRecords = await _context.SchoolFesses
                .Where(s => s.SCHOOL_YEAR_ID == lastSchoolYear.ID)
                .AsNoTracking()
            .ToListAsync();

            // Créer de nouvelles instances pour l'insertion
            var newSchoolFessRecords = schoolFessRecords.Select(s => new SchoolFess
            {
                ID = 0,
                REGISTRATION_FESS = s.REGISTRATION_FESS,
                PRICE_FESS_1 = s.PRICE_FESS_1,
                PRICE_FESS_2 = s.PRICE_FESS_2,
                PRICE_FESS_3 = s.PRICE_FESS_3,
                CREATED_USER_ID = schoolYear.CREATED_USER_ID,
                UPDATED_USER_ID = schoolYear.UPDATED_USER_ID,
                CREATION_DATE = schoolYear.CREATION_DATE,
                MODIFICATION_DATE = schoolYear.MODIFICATION_DATE,
                DEADLINE_FESS_1 = s.DEADLINE_FESS_1,
                DEADLINE_FESS_2 = s.DEADLINE_FESS_2,
                DEADLINE_FESS_3 = s.DEADLINE_FESS_3,
                SCHOOL_YEAR_ID = schoolYear.ID,
                EDUCATION_LEVEL_ID = s.EDUCATION_LEVEL_ID,
            }).ToList();
            _context.SchoolFesses.AddRange(newSchoolFessRecords);
        }
        else
        {
            // Niveau d'étude
            var educationLevelRecords = await _context.EducationLevels
                .AsNoTracking()
            .ToListAsync();

            List<SchoolFess> newSchoolFessRecords = new List<SchoolFess>();
            foreach (var educationLevel in educationLevelRecords)
            {
                newSchoolFessRecords.Add(new SchoolFess
                {
                    SCHOOL_YEAR_ID = schoolYear.ID,
                    EDUCATION_LEVEL_ID = educationLevel.ID,
                    REGISTRATION_FESS = 100000,
                    PRICE_FESS_1 = 100000,
                    PRICE_FESS_2 = 100000,
                    PRICE_FESS_3 = 100000,
                    CREATION_DATE = DateTime.UtcNow,
                    MODIFICATION_DATE = null,
                });
            }
            _context.SchoolFesses.AddRange(newSchoolFessRecords);
        }
        await _context.SaveChangesAsync();
    }

    private async Task CopySubdivisionByYearAsync(SchoolYear schoolYear)
    {
        // Niveau d'étude
        var educationLevelRecords = await _context.EducationLevels
            .AsNoTracking()
        .ToListAsync();

        // Subdivision
        var subdivisionRecords = await _context.Subdivisions
            .AsNoTracking()
        .ToListAsync();

        List<SubdivisionByYear> newSubdivisionRecords = new List<SubdivisionByYear>();
        foreach(var educationLevel in educationLevelRecords)
        {
            foreach(var subdivision in subdivisionRecords)
            {
                newSubdivisionRecords.Add(new SubdivisionByYear
                {
                    ID = 0,
                    IS_CHECK = false,
                    CREATED_USER_ID = schoolYear.CREATED_USER_ID,
                    UPDATED_USER_ID = schoolYear.UPDATED_USER_ID,
                    CREATION_DATE = schoolYear.CREATION_DATE,
                    MODIFICATION_DATE = schoolYear.MODIFICATION_DATE,
                    SCHOOL_YEAR_ID = schoolYear.ID,
                    SUBDIVISION_ID = subdivision.ID,
                    EDUCATION_LEVEL_ID = educationLevel.ID,
                });
            }
        }
        _context.SubdivisionByYears.AddRange(newSubdivisionRecords);
        await _context.SaveChangesAsync();
    }

    public async Task<SchoolYear> CreateSchoolYearAsync(SchoolYear schoolYear)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.SchoolYears.Add(schoolYear);
            await _context.SaveChangesAsync();

            // On recupere la dernière année différente de celle ajoutés
            var lastSchoolYear = await _context.SchoolYears
                .OrderBy(y => y.ID) 
            .LastOrDefaultAsync(x => x.ID != schoolYear.ID);
            
            if(lastSchoolYear != null)
            {
                await CopyCoursAsync(lastSchoolYear, schoolYear);

                var schoolYearList = await _context.SchoolYears.Where(x => x.ID != schoolYear.ID).ToListAsync();
                foreach (var currentSchoolYear in schoolYearList)
                {
                    currentSchoolYear.IS_ACTIVE = false;
                }
                _context.SchoolYears.UpdateRange(schoolYearList);
            }

            await CopyBusFessesAsync(lastSchoolYear, schoolYear);
            await CopySchoolFessAsync(lastSchoolYear, schoolYear);
            await CopySubdivisionByYearAsync(schoolYear);
            await CopyNoteMonthAsync(schoolYear);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return schoolYear;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<SchoolYear> UpdateSchoolYearAsync(SchoolYear schoolYear)
    {
        _context.SchoolYears.Update(schoolYear);
        await _context.SaveChangesAsync();
        return schoolYear;
    }

    public async Task<SchoolYear> DeleteSchoolYearAsync(SchoolYear schoolYear)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            await _context.SchoolFesses
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.BusFesses
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.NotePrimaries
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.NoteMiddleSchools
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.NoteHightSchools
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.Cours
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.NoteMonths
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.SchoolPayments
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.BusPayments
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.HightSchoolAssignments
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.KindergartenSchoolAssignments
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.MiddleSchoolAssignments
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.MonthlySalaryAssignments
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.OtherPrimes
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.PayrollValidations
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.PrimarySchoolAssignments
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.SalaryAdvances
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.SalaryStatuses
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.StudentRegistrations
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.SubdivisionByYears
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.UserPrimes
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            await _context.StudentFolders
                .Where(b => b.SCHOOL_YEAR_ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            var studentsToDelete = await _context.Students
                .Where(s => !_context.StudentRegistrations
                .Any(r => r.STUDENT_ID == s.ID))
                .AsNoTracking()
            .ToListAsync();
            _context.Students.RemoveRange(studentsToDelete);

            await _context.SchoolYears
                .Where(b => b.ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            // Verifie qu'une année n'est pas active
            var activeSchoolYear = await _context.SchoolYears
                .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IS_ACTIVE == true);

            if(activeSchoolYear == null)
            {
                var lastSchoolYear = await _context.SchoolYears
                    .OrderBy(y => y.ID) 
                .LastOrDefaultAsync();

                if(lastSchoolYear != null)
                {
                    lastSchoolYear.IS_ACTIVE = true;
                    _context.Update(lastSchoolYear);
                }
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return schoolYear;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<IEnumerable<SchoolYear>> BatchUpdateSchoolYearsAsync(List<SchoolYear> schoolYears)
    {
        _context.SchoolYears.UpdateRange(schoolYears);
        await _context.SaveChangesAsync();
        return schoolYears;
    }

    public async Task<SchoolYear?> GetSchoolYearAsync(int id)
    {
        return await _context.SchoolYears.AsNoTracking().FirstOrDefaultAsync(sy => sy.ID == id);
    }

    public async Task<IEnumerable<SchoolYear>> GetSchoolYearsAsync()
    {
        return await _context.SchoolYears
            .AsNoTracking()
            .OrderByDescending(x => x.ID)
        .ToListAsync();
    }

    public async Task<IEnumerable<SchoolYear>> GetSchoolYearBatchAsync(int[] ids)
    {
        return await _context.SchoolYears.Where(sy => ids.Contains(sy.ID)).AsNoTracking().ToListAsync();
    }

    public async Task<SchoolYear?> GetActivedSchoolYear()
    {
        return await _context.SchoolYears.AsNoTracking().FirstOrDefaultAsync(sy => sy.IS_ACTIVE == true);
    }
}