

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("SumSalaryAdvances")]
    public class SumSalaryAdvance
    {
        [Key]
		public int ID { get; set; }
        public required float SUM { get; set; }

        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;


        [ForeignKey("USER")]
        public required int USER_ID { get; set; }
        public required User USER { get; set; }


        [ForeignKey("TYPE_SALARY_ADVANCE")]
        public int TYPE_SALARY_ADVANCE_ID { get; set; }
        public required TypeSalaryAdvance TYPE_SALARY_ADVANCE { get; set; }
    }
}