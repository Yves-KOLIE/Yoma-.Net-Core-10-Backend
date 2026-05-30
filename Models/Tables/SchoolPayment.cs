

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
		public DateTime? MODIFICATION_DATE { get; set; } = null;


        [ForeignKey("STUDENT")]
        public int STUDENT_ID { get; set; }
        public Student STUDENT { get; set; } = null!;


        [ForeignKey("SCHOOL_YEAR")]
        public int SCHOOL_YEAR_ID { get; set; }
        public SchoolYear SCHOOL_YEAR { get; set; } = null!;


        [ForeignKey("PAYMENT_METHOD")]
        public int PAYMENT_METHOD_ID { get; set; }
        public PaymentMethod PAYMENT_METHOD { get; set; } = null!;


        [ForeignKey("BANK")]
        public int? BANK_ID { get; set; } = null;
        public Bank? BANK { get; set; }
    }
}