using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface IMonthlySalaryAssignmentService
{
    Task<IEnumerable<MonthlySalaryAssignment>> GetMonthlySalaryAssignmentByYearIdAsync(int? schoolYearId);
    Task<MonthlySalaryAssignment?> CreateMonthlySalaryAssignmentAsync(MonthlySalaryAssignment monthlySalaryAssignment);
    Task<MonthlySalaryAssignment> UpdateMonthlySalaryAssignmentAsync(MonthlySalaryAssignment monthlySalaryAssignment);
    Task<MonthlySalaryAssignment> DeleteMonthlySalaryAssignmentAsync(MonthlySalaryAssignment monthlySalaryAssignment);
}

public class MonthlySalaryAssignmentService : IMonthlySalaryAssignmentService
{
    private readonly Context _context;
    private readonly SchoolYearService _schoolYearService;

    public MonthlySalaryAssignmentService(Context context, SchoolYearService schoolYearService)
    {
        _context = context;
        _schoolYearService = schoolYearService;
    }

    public async Task<IEnumerable<MonthlySalaryAssignment>> GetMonthlySalaryAssignmentByYearIdAsync(int? schoolYearId)
    {
        int id = schoolYearId ?? (await _schoolYearService.GetActivedSchoolYear())?.ID ?? 0;
        return await _context.MonthlySalaryAssignments
            .Where(msa => msa.SCHOOL_YEAR_ID == id)
            .Include(x => x.USER)
            .Include(x => x.SCHOOL_YEAR)
            .AsNoTracking()
        .ToListAsync();
    }

    public async Task<MonthlySalaryAssignment?> CreateMonthlySalaryAssignmentAsync(MonthlySalaryAssignment monthlySalaryAssignment)
    {
        _context.MonthlySalaryAssignments.Add(monthlySalaryAssignment);
        await _context.SaveChangesAsync();
        return await _context.MonthlySalaryAssignments
            .Where(x => x.ID == monthlySalaryAssignment.ID)
            .Include(x => x.USER)
            .Include(x => x.SCHOOL_YEAR)
            .AsNoTracking()
        .FirstOrDefaultAsync();
    }

    public async Task<MonthlySalaryAssignment> UpdateMonthlySalaryAssignmentAsync(MonthlySalaryAssignment monthlySalaryAssignment)
    {
        _context.MonthlySalaryAssignments.Update(monthlySalaryAssignment);
        await _context.SaveChangesAsync();
        return monthlySalaryAssignment;
    }

    public async Task<MonthlySalaryAssignment> DeleteMonthlySalaryAssignmentAsync(MonthlySalaryAssignment monthlySalaryAssignment)
    {
        _context.MonthlySalaryAssignments.Remove(monthlySalaryAssignment);
        await _context.SaveChangesAsync();
        return monthlySalaryAssignment;
    }

}