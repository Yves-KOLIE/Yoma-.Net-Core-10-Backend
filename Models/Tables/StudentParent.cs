

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
        public int STUDENT_ID { get; set; }
        public Student STUDENT { get; set; } = null!;

        [ForeignKey("PARENT")]
        public int PARENT_ID { get; set; }
        public Parent PARENT { get; set; } = null!;

        [ForeignKey("PARENT_TYPE")]
        public int PARENT_TYPE_ID { get; set; }
        public ParentType PARENT_TYPE { get; set; } = null!;
    }
}