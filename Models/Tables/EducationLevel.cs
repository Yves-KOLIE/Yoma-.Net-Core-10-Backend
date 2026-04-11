

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
		public DateTime MODIFICATION_DATE { get; set; } = new DateTime();
        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        

        [ForeignKey("SCHOOL_EDUCATION")]
        public required int SCHOOL_EDUCATION_ID { get; set; }
        public required SchoolEducation SCHOOL_EDUCATION { get; set; }

        [ForeignKey("HIGH_SCHOOL_OPTION")]
        public int? HIGH_SCHOOL_OPTION_ID { get; set; } = null;
        public HighSchoolOption? HIGH_SCHOOL_OPTION { get; set; }
    }
}