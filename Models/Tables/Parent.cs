

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace YOMA.Models.Tables
{
    [Table("Parents")]
    public class Parent
    {
        [Key]
		public int ID { get; set; }
        public required string NAME { get; set; }
        public required string SURNAME { get; set; }
        public required char SEXE { get; set; }
        public required string TELEPHONE_1 { get; set; }
        public string? TELEPHONE_2 { get; set; } = null;
        public required string QUARTER { get; set; }
        public string? EMAIL { get; set; } = null;
        #pragma warning disable
        [JsonIgnore]
        public string PASSWORD { get; set; }
        #pragma warning restore
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

        [ForeignKey("PROFESSIONAL_QUALIFICATION")]
        public int PROFESSIONAL_QUALIFICATION_ID { get; set; }
        public required ProfessionalQualification PROFESSIONAL_QUALIFICATION { get; set; }

        [ForeignKey("USER_ROLE")]
        public int USER_ROLE_ID { get; set; }
        public required UserRole USER_ROLE { get; set; }

        [ForeignKey("USER_TYPE")]
        public int USER_TYPE_ID { get; set; }
        public required UserType USER_TYPE { get; set; }
    }
}