

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("StudentRegistrations")]
    public class StudentRegistration
    {
        [Key]
		public int ID { get; set; }
        public bool IS_ACTIVE { get; set; } = true;
        public bool IS_DELETED { get; set; }
        public bool IS_ABANDON { get; set; }

        public required int REGISTRATION_FESS { get; set; }
        public required int PRICE_FESS_1 { get; set; }
        public required int PRICE_FESS_2 { get; set; }
        public required int PRICE_FESS_3 { get; set; }

        // Moyenne de cours
        public required float AVERAGE_QUARTER_1 { get; set; }
        public required float AVERAGE_QUARTER_2 { get; set; }
        public required float AVERAGE_QUARTER_3 { get; set; }
        public required float ANNUAL_AVERAGE { get; set; }

        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;

        [ForeignKey("STUDENT")]
        public int STUDENT_ID { get; set; }
        public Student STUDENT { get; set; } = null!;

        [ForeignKey("SCHOOL_YEAR")]
        public int SCHOOL_YEAR_ID { get; set; }
        public SchoolYear SCHOOL_YEAR { get; set; } = null!;

        [ForeignKey("EDUCATION_LEVEL")]
        public int EDUCATION_LEVEL_ID { get; set; }
        public EducationLevel EDUCATION_LEVEL { get; set; } = null!;

        [ForeignKey("SUBDIVISION")]
        public int SUBDIVISION_ID { get; set; }
        public Subdivision SUBDIVISION { get; set; } = null!;

        [ForeignKey("STUDENT_SCHOOL_STATUS_OF_CARE")]
        public int STUDENT_SCHOOL_STATUS_OF_CARE_ID { get; set; }
        public StudentSchoolStatusOfCare STUDENT_SCHOOL_STATUS_OF_CARE { get; set; } = null!;

        [ForeignKey("STUDENT_BUS_STATUS_OF_CARE")]
        public int STUDENT_BUS_STATUS_OF_CARE_ID { get; set; }
        public StudentBusStatusOfCare STUDENT_BUS_STATUS_OF_CARE { get; set; } = null!;
    }
}