using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;
using YOMA.Models.Views;

public interface ISubdivisionByYears
{
    Task<IEnumerable<SubdivisionByYear>> GetSubdivisionByYearsAsync(int? schoolYearId = null);
    Task<List<SubdivisionByYearViewModel>> BatchUpdateSubdivisionByYearAsync(List<SubdivisionByYearViewModel> subdivisionByYearViewModelList);
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

    public async Task<List<SubdivisionByYearViewModel>> BatchUpdateSubdivisionByYearAsync(List<SubdivisionByYearViewModel> subdivisionByYearViewModelList)
    {   
        var subdivisionByYearList = subdivisionByYearViewModelList.SelectMany(s => s.SUBDIVISION_BY_YEAR_LIST.Select(sb => new
        {
            sb.SUBDIVISION_BY_YEAR_ID,
            sb.IS_CHECK
        })).ToList();

        foreach(var subdivisionByYear in subdivisionByYearList)
        {
            var subdivisionByYearToUpdate = await _context.SubdivisionByYears.FirstOrDefaultAsync(sy => sy.ID == subdivisionByYear.SUBDIVISION_BY_YEAR_ID);
            if(subdivisionByYearToUpdate != null)
            {
                subdivisionByYearToUpdate.IS_CHECK = subdivisionByYear.IS_CHECK;
                _context.SubdivisionByYears.Update(subdivisionByYearToUpdate);
            }
        }

        await _context.SaveChangesAsync();
        return subdivisionByYearViewModelList;
    }
}