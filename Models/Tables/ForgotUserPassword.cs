

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("ForgotUserPasswords")]
    public class ForgotUserPassword
    {
        [Key]
		public int ID { get; set; }
        public required string EMAIL { get; set; }
        public required string CODE_GENERETED { get; set; }
        public DateTime CREATION_DATE { get; set; }
		public DateTime EXPIRE_DATE { get; set; }
    }
}