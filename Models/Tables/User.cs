

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOMA.Models.Tables
{
    [Table("Users")]
    public class User
    {
        [Key]
		public int ID { get; set; }
        public required string NAME { get; set; }
        public required string SURNAME { get; set; }
        public required string SEXE { get; set; }
        public required string QUARTER { get; set; }
        public required string TELEPHONE_1 { get; set; }
        public string? TELEPHONE_2 { get; set; } = null;
        public string? EMAIL { get; set; } = null;
        public required string MATRICULE { get; set; }
        public required string PASSWORD { get; set; }
        public string? PHOTO { get; set; } = null;
        public bool IS_LOCK { get; set; }
        public bool IS_ACTIVE { get; set; }
        public bool IS_PRINCIPAL_TEACHER { get; set; }
        public int[] USER_POSITION_IDS { get; set; } = [];
        public int[] SCHOOL_EDUCATION_IDS { get; set; } = [];
        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime? LOCK_DATE { get; set; } = null;
        public DateTime? UNLOCK_DATE { get; set; } = null;
        public DateTime? LAST_CONNEXION_DATE { get; set; } = null;
        public DateTime? LAST_DECONNEXION_DATE { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;

        [ForeignKey("PROFESSIONAL_QUALIFICATION")]
        public int PROFESSIONAL_QUALIFICATION_ID { get; set; }
        public required ProfessionalQualification PROFESSIONAL_QUALIFICATION { get; set; }
    }
}