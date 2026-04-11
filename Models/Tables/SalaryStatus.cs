

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("SalaryStatus")]
    public class SalaryStatus
    {
        [Key]
		public int ID { get; set; }
        public string? INFOS { get; set; }
        public bool IS_PAYED { get; set; }
        public required int HOURS_SALARY { get; set; }
        public required string COURS_TITLE { get; set; }
        public required int NUMBER_HOURS_WORKED { get; set; }
        public required int TOTAL_HOURS { get; set; }

        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime MODIFICATION_DATE { get; set; } = new DateTime();


        [ForeignKey("USER")]
        public required int USER_ID { get; set; }
        public required User USER { get; set; }


        [ForeignKey("SCHOOL_YEAR")]
        public required int SCHOOL_YEAR_ID { get; set; }
        public required SchoolYear SCHOOL_YEAR { get; set; }


        [ForeignKey("MONTH")]
        public required int MONTH_ID { get; set; }
        public required Month MONTH { get; set; }


        [ForeignKey("EDUCATION_LEVEL")]
        public required int EDUCATION_LEVEL_ID { get; set; }
        public required EducationLevel EDUCATION_LEVEL { get; set; }


        [ForeignKey("SUBDIVISION")]
        public required int SUBDIVISION_ID { get; set; }
        public required Subdivision SUBDIVISION { get; set; }


        [ForeignKey("COURS")]
        public int? COURS_ID { get; set; } = null;
        public Cours? COURS { get; set; }


        [ForeignKey("TYPE_ADVANCE_SALARY")]
        public required int TYPE_ADVANCE_SALARY_ID { get; set; }
        public required TypeSalaryAdvance TYPE_ADVANCE_SALARY { get; set; }
    }
}