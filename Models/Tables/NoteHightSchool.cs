

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("NoteHightSchools")]
    public class NoteHightSchool
    {
        [Key]
		public int ID { get; set; }
        public float NOTE { get; set; } = 0.00f;
        public string? INFOS { get; set; } = null;
        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;


        [ForeignKey("SCHOOL_YEAR")]
        public required int SCHOOL_YEAR_ID { get; set; }
        public required SchoolYear SCHOOL_YEAR { get; set; }


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