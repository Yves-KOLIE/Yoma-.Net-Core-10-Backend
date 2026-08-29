using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("BusRegistrations")]
    public class BusRegistration
    {
        [Key]
		public int ID { get; set; }
        public int BUS_PRICE_1 { get; set; }
        public int BUS_PRICE_2 { get; set; }
        public int BUS_PRICE_3 { get; set; }
        public bool IS_SUBSCRIBE_TO_THE_BUS_FESS_1 { get; set; }
        public bool IS_SUBSCRIBE_TO_THE_BUS_FESS_2 { get; set; }
        public bool IS_SUBSCRIBE_TO_THE_BUS_FESS_3 { get; set; }

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
    }
}