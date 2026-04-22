

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("KindergartenSchoolAssignments")]
    public class KindergartenSchoolAssignment
    {
        [Key]
		public int ID { get; set; }
        public required int HOURS_SALARY { get; set; }
        public int[] COURS_IDS { get; set; } = [];

        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;


        [ForeignKey("USER")]
        public required int USER_ID { get; set; }
        public required User USER { get; set; }


        [ForeignKey("SCHOOL_YEAR")]
        public required int SCHOOL_YEAR_ID { get; set; }
        public required SchoolYear SCHOOL_YEAR { get; set; }


        [ForeignKey("EDUCATION_LEVEL")]
        public int EDUCATION_LEVEL_ID { get; set; }
        public required EducationLevel EDUCATION_LEVEL { get; set; }


        [ForeignKey("SUBDIVISION")]
        public int SUBDIVISION_ID { get; set; }
        public required Subdivision SUBDIVISION { get; set; }
    }
}