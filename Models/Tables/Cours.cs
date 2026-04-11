

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("Cours")]
    public class Cours
    {
        [Key]
		public int ID { get; set; }
        public required string DESCRIPTION { get; set; }
        public required string CODE { get; set; }
        public bool IS_ACTIVE { get; set; } = true;
        public required int COEFFICIENT { get; set; }
        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime MODIFICATION_DATE { get; set; } = new DateTime();


        [ForeignKey("SCHOOL_YEAR")]
        public required int SCHOOL_YEAR_ID { get; set; }
        public required SchoolYear SCHOOL_YEAR { get; set; }

        [ForeignKey("EDUCATION_LEVEL")]
        public required int EDUCATION_LEVEL_ID { get; set; }
        public required EducationLevel EDUCATION_LEVEL { get; set; }
    }
}