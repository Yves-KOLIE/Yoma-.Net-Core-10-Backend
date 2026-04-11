

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("SalaryAdvances")]
    public class SalaryAdvance
    {
        [Key]
		public int ID { get; set; }
        public string? INFOS { get; set; } = null;
        public required int AMOUNT { get; set; }

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


        [ForeignKey("USER")]
        public required int USER_ID { get; set; }
        public required User USER { get; set; }


        [ForeignKey("TYPE_SALARY_ADVANCE")]
        public int TYPE_SALARY_ADVANCE_ID { get; set; }
        public required TypeSalaryAdvance TYPE_SALARY_ADVANCE { get; set; }
    }
}