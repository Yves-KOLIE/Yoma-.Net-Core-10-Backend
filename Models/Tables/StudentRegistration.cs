

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("StudentRegistrations")]
    public class StudentRegistration
    {
        [Key]
		public int ID { get; set; }
        public string? FOLDER_INFORMATION { get; set; } = null;
        public bool IS_ACTIVE { get; set; } = true;
        public bool IS_DELETED { get; set; }
        public bool IS_ABANDON { get; set; }

        public bool SCHOOL_FESS_IS_SUPPORTED { get; set; }
        public bool SCHOOL_FESS_IS_DISCOUNTED { get; set; }
        public required int REGISTRATION_FESS { get; set; }
        public required int PRICE_FESS_1 { get; set; }
        public required int PRICE_FESS_2 { get; set; }
        public required int PRICE_FESS_3 { get; set; }

        // Moyenne de cours
        public required float AVERAGE_QUARTER_1 { get; set; }
        public required float AVERAGE_QUARTER_2 { get; set; }
        public required float AVERAGE_QUARTER_3 { get; set; }
        public required float ANNUAL_AVERAGE { get; set; }

        public bool IS_SUBSCRIBE_TO_THE_BUS_FESS_1 { get; set; }
        public bool IS_SUBSCRIBE_TO_THE_BUS_FESS_2 { get; set; }
        public bool IS_SUBSCRIBE_TO_THE_BUS_FESS_3 { get; set; }

        public bool BUS_PRICE_IS_SUPPORTED { get; set; }
        public bool BUS_PRICE_IS_DISCOUNTED { get; set; }
        public int? BUS_PRICE_1 { get; set; } = null;
        public int? BUS_PRICE_2 { get; set; } = null;
        public int? BUS_PRICE_3 { get; set; } = null;

        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;


        [ForeignKey("STUDENT")]
        public required int STUDENT_ID { get; set; }
        public required Student STUDENT { get; set; }


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