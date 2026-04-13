using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface ISubdivisionByYears
{
    Task<IEnumerable<SubdivisionByYear>> GetSubdivisionByYearsAsync(int? schoolYearId = null);
    Task<List<SubdivisionByYear>> BatchUpdateSubdivisionByYearAsync(List<SubdivisionByYear> subdivisionByYears);
}

public class SubdivisionByYearService : ISubdivisionByYears
{
    private readonly Context _context;
    private readonly ISchoolYearService _schoolYearService;

    public SubdivisionByYearService(Context context, ISchoolYearService schoolYearService)
    {
        _context = context;
        _schoolYearService = schoolYearService;
    }

    public async Task<IEnumerable<SubdivisionByYear>> GetSubdivisionByYearsAsync(int? schoolYearId = null)
    {
        if(schoolYearId != null)
        {
            return await _context.SubdivisionByYears
                .Where(sy => sy.SCHOOL_YEAR_ID == schoolYearId)
                .Include(sy => sy.SCHOOL_YEAR)
                .Include(sy => sy.SUBDIVISION)
                .Include(sy => sy.EDUCATION_LEVEL)
                .OrderBy(sy => sy.ID)
                .AsNoTracking()
            .ToListAsync();
        }

        var activeYear = await _schoolYearService.GetActivedSchoolYear();
        if(activeYear != null)
        {
            return await _context.SubdivisionByYears
                .Where(sy => sy.SCHOOL_YEAR_ID == activeYear.ID)
                .AsNoTracking()
                .Include(sy => sy.SCHOOL_YEAR)
                .Include(sy => sy.SUBDIVISION)
                .Include(sy => sy.EDUCATION_LEVEL)
                .OrderBy(sy => sy.ID)
            .ToListAsync();
        }
        return new List<SubdivisionByYear>();

    }

    public async Task<List<SubdivisionByYear>> BatchUpdateSubdivisionByYearAsync(List<SubdivisionByYear> subdivisionByYears)
    {   
        _context.SubdivisionByYears.UpdateRange(subdivisionByYears);
        await _context.SaveChangesAsync();
        return subdivisionByYears;
    }
}