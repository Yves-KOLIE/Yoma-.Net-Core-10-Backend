

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("NoteMonths")]
    public class NoteMonth
    {
        [Key]
		public int ID { get; set; }
        public bool IS_COMPOSITION_MONTH { get; set; }
        public bool IS_TRIMESTER_1 { get; set; }
        public bool IS_TRIMESTER_2 { get; set; }
        public bool IS_TRIMESTER_3 { get; set; }
        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;

        [ForeignKey("SCHOOL_YEAR")]
        public int SCHOOL_YEAR_ID { get; set; }
        public SchoolYear SCHOOL_YEAR { get; set; } = null!;

        [ForeignKey("MONTH")]
        public int MONTH_ID { get; set; }
        public Month MONTH { get; set; } = null!;

        [ForeignKey("EDUCATION_LEVEL")]
        public int EDUCATION_LEVEL_ID { get; set; }
        public EducationLevel EDUCATION_LEVEL { get; set; } = null!;

        [NotMapped]
        public bool IS_DISABLED { get; set; }
    }
}