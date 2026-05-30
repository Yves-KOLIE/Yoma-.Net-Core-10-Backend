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

    private async Task CopyBusFessesAsync(SchoolYear lastSchoolYear, SchoolYear schoolYear)
    {
        // Frais de bus de l'année précédente
        var busFessesRecords = await _context.BusFesses
            .Where(b => b.SCHOOL_YEAR_ID == lastSchoolYear.ID)
            .AsNoTracking()
        .ToListAsync();

        // Créer de nouvelles instances pour l'insertion
        var newRecords = busFessesRecords.Select(b => new BusFess
        {
            ID = 0,
            PRICE_FESS_1 = b.PRICE_FESS_1,
            PRICE_FESS_2 = b.PRICE_FESS_2,
            PRICE_FESS_3 = b.PRICE_FESS_3,
            CREATED_USER_ID = schoolYear.CREATED_USER_ID,
            UPDATED_USER_ID = schoolYear.UPDATED_USER_ID,
            CREATION_DATE = schoolYear.CREATION_DATE,
            MODIFICATION_DATE = schoolYear.MODIFICATION_DATE,
            DEADLINE_FESS_1 = b.DEADLINE_FESS_1,
            DEADLINE_FESS_2 = b.DEADLINE_FESS_2,
            DEADLINE_FESS_3 = b.DEADLINE_FESS_3,
            SCHOOL_YEAR_ID = schoolYear.ID,
        }).ToList();
        _context.BusFesses.AddRange(newRecords);
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

    private async Task CopyMonthOfSalaryAsync(SchoolYear schoolYear)
    {
        // Mois de l'année
        var monthRecords = await _context.Months
            .AsNoTracking()
        .ToListAsync();

        // Créer de nouvelles instances pour l'insertion
        var newMonthOfSalaryRecords = monthRecords.Select(m => new MonthOfSalary
        {
            IS_ACTIVE = false,
            CREATED_USER_ID = schoolYear.CREATED_USER_ID,
            UPDATED_USER_ID = schoolYear.UPDATED_USER_ID,
            CREATION_DATE = schoolYear.CREATION_DATE,
            MODIFICATION_DATE = schoolYear.MODIFICATION_DATE,
            SCHOOL_YEAR_ID = schoolYear.ID,
            SCHOOL_YEAR = schoolYear,
            MONTH_ID = m.ID,
        }).ToList();

        _context.MonthOfSalaries.AddRange(newMonthOfSalaryRecords);
        await _context.SaveChangesAsync();
    }

    private async Task CopyNoteMonthAsync(SchoolYear lastSchoolYear, SchoolYear schoolYear)
    {
        // Notes mensuelles de l'année précédente
        var noteMonthRecords = await _context.NoteMonths
            .Where(n => n.SCHOOL_YEAR_ID == lastSchoolYear.ID)
            .AsNoTracking()
        .ToListAsync();

        // Créer de nouvelles instances pour l'insertion
        var newNoteMonthRecords = noteMonthRecords.Select(n => new NoteMonth
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
            MONTH_ID = n.MONTH_ID,
            EDUCATION_LEVEL_ID = n.EDUCATION_LEVEL_ID
        }).ToList();
        _context.NoteMonths.AddRange(newNoteMonthRecords);
        await _context.SaveChangesAsync();
    }

    private async Task CopySchoolFessAsync(SchoolYear lastSchoolYear, SchoolYear schoolYear)
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
        await _context.SaveChangesAsync();
    }

    private async Task CopySubdivisionByYearAsync(SchoolYear lastSchoolYear, SchoolYear schoolYear)
    {
        // Subdivisions by year de l'année précédente
        var subdivisionRecords = await _context.SubdivisionByYears
            .Where(s => s.SCHOOL_YEAR_ID == lastSchoolYear.ID)
            .AsNoTracking()
        .ToListAsync();

        // Créer de nouvelles instances pour l'insertion
        var newSubdivisionRecords = subdivisionRecords.Select(s => new SubdivisionByYear
        {
            ID = 0,
            IS_CHECK = false,
            CREATED_USER_ID = schoolYear.CREATED_USER_ID,
            UPDATED_USER_ID = schoolYear.UPDATED_USER_ID,
            CREATION_DATE = schoolYear.CREATION_DATE,
            MODIFICATION_DATE = schoolYear.MODIFICATION_DATE,
            SCHOOL_YEAR_ID = schoolYear.ID,
            SUBDIVISION_ID = s.SUBDIVISION_ID,
            EDUCATION_LEVEL_ID = s.EDUCATION_LEVEL_ID,
        }).ToList();
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
            .OrderBy(b => b.ID)
                .AsNoTracking()
            .LastOrDefaultAsync(x => x.ID != schoolYear.ID);
            
            if(lastSchoolYear != null)
            {
                await CopyBusFessesAsync(lastSchoolYear, schoolYear);
                await CopyCoursAsync(lastSchoolYear, schoolYear);
                await CopyMonthOfSalaryAsync(schoolYear);
                await CopySubdivisionByYearAsync(lastSchoolYear, schoolYear);
                await CopySchoolFessAsync(lastSchoolYear, schoolYear);
                await CopyNoteMonthAsync(lastSchoolYear, schoolYear);

                lastSchoolYear.IS_ACTIVE = false;
                _context.SchoolYears.Update(lastSchoolYear);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
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

            await _context.MonthOfSalaries
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

            await _context.SchoolYears
                .Where(b => b.ID == schoolYear.ID)
            .ExecuteDeleteAsync();

            var studentsToDelete = await _context.Students
                .Where(s => !_context.StudentRegistrations
                .Any(r => r.STUDENT_ID == s.ID))
                .AsNoTracking()
            .ToListAsync();
            _context.Students.RemoveRange(studentsToDelete);

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