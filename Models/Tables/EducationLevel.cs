

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("EducationLevels")]
    public class EducationLevel
    {
        [Key]
		public int ID { get; set; }
        public required string DESCRIPTION { get; set; }
        public string? ABREVIATION { get; set; } = null;
        public bool IS_ACTIVE { get; set; } = true;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;
        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public bool IS_EXAM_CLASS { get; set; }
        
        [ForeignKey("SCHOOL_EDUCATION")]
        public int SCHOOL_EDUCATION_ID { get; set; }
        public SchoolEducation SCHOOL_EDUCATION { get; set; } = null!;

        [ForeignKey("HIGH_SCHOOL_OPTION")]
        public int? HIGH_SCHOOL_OPTION_ID { get; set; } = null;
        public HighSchoolOption? HIGH_SCHOOL_OPTION { get; set; }

        [NotMapped]
        public int STUDENT_REGISTRATED_COUNT { get; set; } = 0;
    }
}