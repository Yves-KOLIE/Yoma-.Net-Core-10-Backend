

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("ExamClasses")]
    public class ExamClass
    {
        [Key]
		public int ID { get; set; }
        public bool IS_ADMITTED { get; set; }
        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
        public DateTime? MODIFICATION_DATE { get; set; } = null;

        [ForeignKey("STUDENT_REGISTRATION")]
        public int STUDENT_REGISTRATION_ID { get; set; }
        public StudentRegistration STUDENT_REGISTRATION { get; set; } = null!;
    }
}