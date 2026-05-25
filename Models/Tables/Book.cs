using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("Books")]
    public class Book
    {
        [Key]
		public int ID { get; set; }
        public required string TITLE { get; set; }
        public required string AUTHOR { get; set; }
        public string? EDITION { get; set; }
        public string? PUBLISHER { get; set; }
        public string? YEAR_OF_PUBLICATION { get; set; }
        public int DAY_RENTAL_PRICE { get; set; } = 0;
        public required int QTE_TOTAL { get; set; }
        public bool IS_ACTIVE { get; set; } = true;

        [ForeignKey("BOOK_CATEGORY")]
        public required int BOOK_CATEGORY_ID { get; set; }
        public required BookCategory BOOK_CATEGORY { get; set; }

        [ForeignKey("LANGUAGE")]
        public required int LANGUAGE_ID { get; set; }
        public required Language LANGUAGE { get; set; }

        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;
    }
}