

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
		public DateTime MODIFICATION_DATE { get; set; } = new DateTime();


        [ForeignKey("SCHOOL_YEAR")]
        public required int SCHOOL_YEAR_ID { get; set; }
        public required SchoolYear SCHOOL_YEAR { get; set; }

        [ForeignKey("MONTH")]
        public required int MONTH_ID { get; set; }
        public required Month MONTH { get; set; }

        [ForeignKey("EDUCATION_LEVEL")]
        public int EDUCATION_LEVEL_ID { get; set; }
        public required EducationLevel EDUCATION_LEVEL { get; set; }

        [NotMapped]
        public bool IS_DISABLED { get; set; }
    }
}