

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("StudentParents")]
    public class StudentParent
    {
        [Key]
		public int ID { get; set; }
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;


        [ForeignKey("STUDENT")]
        public required int STUDENT_ID { get; set; }
        public required Student STUDENT { get; set; }


        [ForeignKey("PARENT")]
        public required int PARENT_ID { get; set; }
        public required Parent PARENT { get; set; }


        [ForeignKey("PARENT_TYPE")]
        public required int PARENT_TYPE_ID { get; set; }
        public required ParentType PARENT_TYPE { get; set; }
    }
}