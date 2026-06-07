using YOMA.Models.Tables;

namespace YOMA.Models.Views
{
    public class CoursViewModel
    {
		public int ID { get; set; }
        public required string DESCRIPTION { get; set; }
        public required string CODE { get; set; }
        public bool IS_ACTIVE { get; set; } = true;
        public required int COEFFICIENT { get; set; }
        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;
    }
}