

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("NotePrimarys")]
    public class NotePrimary
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
        public int SCHOOL_YEAR_ID { get; set; }
        public SchoolYear SCHOOL_YEAR { get; set; } = null!;

        [ForeignKey("STUDENT")]
        public int STUDENT_ID { get; set; }
        public Student STUDENT { get; set; } = null!;

        [ForeignKey("NOTE_MONTH")]
        public int NOTE_MONTH_ID { get; set; }
        public NoteMonth NOTE_MONTH { get; set; } = null!;

        [ForeignKey("COURS")]
        public int COURS_ID { get; set; }
        public Cours COURS { get; set; } = null!;
    }
}