

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("SchoolFess")]
    public class SchoolFess
    {
        [Key]
		public int ID { get; set; }
        public required int REGISTRATION_FESS { get; set; }
        public required int PRICE_FESS_1 { get; set; }
        public required int PRICE_FESS_2 { get; set; }
        public required int PRICE_FESS_3 { get; set; }

        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;
		public DateTime? DEADLINE_FESS_1 { get; set; } = null;
		public DateTime? DEADLINE_FESS_2 { get; set; } = null;
		public DateTime? DEADLINE_FESS_3 { get; set; } = null;

        [ForeignKey("SCHOOL_YEAR")]
        public int SCHOOL_YEAR_ID { get; set; }
        public SchoolYear SCHOOL_YEAR { get; set; } = null!;

        [ForeignKey("EDUCATION_LEVEL")]
        public int EDUCATION_LEVEL_ID { get; set; }
        public EducationLevel EDUCATION_LEVEL { get; set; } = null!;
    }
}