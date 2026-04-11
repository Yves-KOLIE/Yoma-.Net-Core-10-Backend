

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("SchoolPayments")]
    public class SchoolPayment
    {
        [Key]
		public int ID { get; set; }
        public string? INFOS { get; set; } = null;
        public required string INVOICE_NUMBER { get; set; }
        public required int AMOUNT { get; set; }
        public bool IS_REGISTRATION { get; set; }
        public bool IS_FESS_1 { get; set; }
        public bool IS_FESS_2 { get; set; }
        public bool IS_FESS_3 { get; set; }
        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime MODIFICATION_DATE { get; set; } = new DateTime();


        [ForeignKey("STUDENT")]
        public required int STUDENT_ID { get; set; }
        public required Student STUDENT { get; set; }


        [ForeignKey("SCHOOL_YEAR")]
        public required int SCHOOL_YEAR_ID { get; set; }
        public required SchoolYear SCHOOL_YEAR { get; set; }


        [ForeignKey("PAYMENT_METHOD")]
        public required int PAYMENT_METHOD_ID { get; set; }
        public required PaymentMethod PAYMENT_METHOD { get; set; }


        [ForeignKey("BANK")]
        public int? BANK_ID { get; set; } = null;
        public Bank? BANK { get; set; }
    }
}