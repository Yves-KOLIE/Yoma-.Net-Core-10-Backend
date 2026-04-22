

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("Students")]
    public class Student
    {
        [Key]
		public int ID { get; set; }
        public required string NAME { get; set; }
        public required string SURNAME { get; set; }
        public required string SEXE { get; set; }
        public required DateTime BIRTH_DAY_DATE { get; set; }
        public required string QUARTER { get; set; }
        public string? TELEPHONE_1 { get; set; } = null;
        public string? TELEPHONE_2 { get; set; } = null;
        public string? EMAIL { get; set; } = null;
        public required string MATRICULE { get; set; }
        public string? PASSWORD { get; set; } = null;
        public string? PHOTO { get; set; } = null;

        public bool IS_LOCK { get; set; }
        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime? LOCK_DATE { get; set; } = null;
        public DateTime? UNLOCK_DATE { get; set; } = null;
        public DateTime? LAST_CONNEXION_DATE { get; set; } = null;
        public DateTime? LAST_DECONNEXION_DATE { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;


        [ForeignKey("BIRTH_PLACE")]
        public required int BIRTH_PLACE_ID { get; set; }
        public required BirthPlace BIRTH_PLACE { get; set; }
    }
}