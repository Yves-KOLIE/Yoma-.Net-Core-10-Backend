

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
        public int USER_ID { get; set; }
        public User USER { get; set; } = null!;


        [ForeignKey("SCHOOL_YEAR")]
        public int SCHOOL_YEAR_ID { get; set; }
        public SchoolYear SCHOOL_YEAR { get; set; } = null!;


        [ForeignKey("EDUCATION_LEVEL")]
        public int EDUCATION_LEVEL_ID { get; set; }
        public EducationLevel EDUCATION_LEVEL { get; set; } = null!;


        [ForeignKey("SUBDIVISION")]
        public int SUBDIVISION_ID { get; set; }
        public Subdivision SUBDIVISION { get; set; } = null!;
    }
}