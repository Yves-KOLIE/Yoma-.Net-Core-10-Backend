

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("BusFess")]
    public class BusFess
    {
        [Key]
		public int ID { get; set; }
        public required int PRICE_FESS_1 { get; set; }
        public required int PRICE_FESS_2 { get; set; }
        public required int PRICE_FESS_3 { get; set; }

        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime MODIFICATION_DATE { get; set; } = new DateTime();
		public DateTime? DEADLINE_FESS_1 { get; set; } = null;
		public DateTime? DEADLINE_FESS_2 { get; set; } = null;
		public DateTime? DEADLINE_FESS_3 { get; set; } = null;


        [ForeignKey("SCHOOL_YEAR")]
        public required int SCHOOL_YEAR_ID { get; set; }
        public required SchoolYear SCHOOL_YEAR { get; set; }
    }
}