using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("BookRentals")]
    public class BookRental
    {
        [Key]
		public int ID { get; set; }
        public string? INFORMATION { get; set; }
        
        [ForeignKey("STUDENT")]
        public required int STUDENT_ID { get; set; }
        public required Student STUDENT { get; set; }

        [ForeignKey("BOOK")]
        public required int BOOK_ID { get; set; }
        public required Book BOOK { get; set; }

        public int DAY_RENTAL_PRICE { get; set; } = 0;
        public DateTime RENTAL_DATE { get; set; } = new DateTime();
        public DateTime RETURN_DATE { get; set; }

        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;
    }
}