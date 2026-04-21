using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("MonthlySalaryAssignments")]
    public class MonthlySalaryAssignment
    {
        [Key]
		public int ID { get; set; }
        public required int[] USER_POSITION_IDS { get; set; }
        public required int[] MONTH_IDS { get; set; }
        public int MONTHLY_SALARY { get; set; } = 0;
        public bool IS_PAYED { get; set; }

        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime MODIFICATION_DATE { get; set; } = new DateTime();


        [ForeignKey("SCHOOL_YEAR")]
        public required int SCHOOL_YEAR_ID { get; set; }
        public required SchoolYear SCHOOL_YEAR { get; set; }

        [ForeignKey("USER")]
        public required int USER_ID { get; set; }
        public required User USER { get; set; }
    }
}