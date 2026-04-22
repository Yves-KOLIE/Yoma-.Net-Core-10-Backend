

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("SchoolYears")]
    public class SchoolYear
    {
        [Key]
		public int ID { get; set; }
        public required string DESCRIPTION { get; set; }
        public bool IS_ACTIVE { get; set; } = true;
        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;
    }
}