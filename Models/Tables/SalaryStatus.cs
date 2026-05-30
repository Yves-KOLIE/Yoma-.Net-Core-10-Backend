

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
		public DateTime? MODIFICATION_DATE { get; set; } = null;


        [ForeignKey("USER")]
        public int USER_ID { get; set; }
        public User USER { get; set; } = null!;

        [ForeignKey("SCHOOL_YEAR")]
        public int SCHOOL_YEAR_ID { get; set; }
        public SchoolYear SCHOOL_YEAR { get; set; } = null!;

        [ForeignKey("MONTH")]
        public int MONTH_ID { get; set; }
        public Month MONTH { get; set; } = null!;

        [ForeignKey("EDUCATION_LEVEL")]
        public int EDUCATION_LEVEL_ID { get; set; }
        public EducationLevel EDUCATION_LEVEL { get; set; } = null!;

        [ForeignKey("SUBDIVISION")]
        public int SUBDIVISION_ID { get; set; }
        public Subdivision SUBDIVISION { get; set; } = null!;

        [ForeignKey("COURS")]
        public int? COURS_ID { get; set; } = null;
        public Cours? COURS { get; set; }

        [ForeignKey("TYPE_ADVANCE_SALARY")]
        public int TYPE_ADVANCE_SALARY_ID { get; set; }
        public TypeSalaryAdvance TYPE_ADVANCE_SALARY { get; set; } = null!;
    }
}