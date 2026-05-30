

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
		public DateTime? MODIFICATION_DATE { get; set; } = null;


        [ForeignKey("SCHOOL_YEAR")]
        public int SCHOOL_YEAR_ID { get; set; }
        public SchoolYear SCHOOL_YEAR { get; set; } = null!;


        [ForeignKey("MONTH")]
        public int MONTH_ID { get; set; }
        public Month MONTH { get; set; } = null!;


        [ForeignKey("USER")]
        public int USER_ID { get; set; }
        public User USER { get; set; } = null!;


        [ForeignKey("TYPE_SALARY_ADVANCE")]
        public int TYPE_SALARY_ADVANCE_ID { get; set; }
        public TypeSalaryAdvance TYPE_SALARY_ADVANCE { get; set; } = null!;
    }
}