namespace YOMA.Models.Views
{
    public class SubdivisionByYearsView
    {
		public int SUBDIVISION_BY_YEAR_ID { get; set; }
        public required string SUBDIVISION { get; set; }
        public bool IS_CHECK { get; set; } 
    }
    public class SubdivisionByYearViewModel
    {
        public required int? SCHOOL_YEAR_ID { get; set; }
        public required string EDUCATION_LEVEL { get; set; }
        public required List<SubdivisionByYearsView> SUBDIVISION_BY_YEAR_LIST { get; set; }
    }
}