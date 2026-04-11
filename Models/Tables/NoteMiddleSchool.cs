

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("NoteMiddleSchools")]
    public class NoteMiddleSchool
    {
        [Key]
		public int ID { get; set; }
        public float NOTE { get; set; } = 0.00f;
        public string? INFOS { get; set; } = null;
        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime MODIFICATION_DATE { get; set; } = new DateTime();


        [ForeignKey("STUDENT")]
        public required int STUDENT_ID { get; set; }
        public required Student STUDENT { get; set; }


        [ForeignKey("NOTE_MONTH")]
        public required int NOTE_MONTH_ID { get; set; }
        public required NoteMonth NOTE_MONTH { get; set; }
        

        [ForeignKey("COURS")]
        public int COURS_ID { get; set; }
        public required Cours COURS { get; set; }
    }
}