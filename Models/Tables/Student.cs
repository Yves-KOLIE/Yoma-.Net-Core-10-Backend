

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace YOMA.Models.Tables
{
    [Table("Students")]
    public class Student
    {
        [Key]
		public int ID { get; set; }
        public required string NAME { get; set; }
        public required string SURNAME { get; set; }
        public required char SEXE { get; set; }
        public required DateTime BIRTH_DAY_DATE { get; set; }
        public required string QUARTER { get; set; }
        public string? TELEPHONE_1 { get; set; } = null;
        public string? TELEPHONE_2 { get; set; } = null;
        public required string MATRICULE { get; set; }
        #pragma warning disable
        [JsonIgnore]
        public string PASSWORD { get; set; }
        #pragma warning restore
        public string? PHOTO { get; set; } = null;

        public bool IS_LOCK { get; set; }
        public bool IS_DARK_THEME { get; set; } = false;
        public int? CREATED_USER_ID { get; set; } = null;
        public int? UPDATED_USER_ID { get; set; } = null;
        public DateTime? LOCK_DATE { get; set; } = null;
        public DateTime? UNLOCK_DATE { get; set; } = null;
        public DateTime? LAST_CONNEXION_DATE { get; set; } = null;
        public DateTime? LAST_DECONNEXION_DATE { get; set; } = null;
        public DateTime CREATION_DATE { get; set; } = new DateTime();
		public DateTime? MODIFICATION_DATE { get; set; } = null;

        [ForeignKey("BIRTH_PLACE")]
        public int BIRTH_PLACE_ID { get; set; }
        public BirthPlace BIRTH_PLACE { get; set; } = null!;
        
        [ForeignKey("USER_ROLE")]
        public int USER_ROLE_ID { get; set; }
        public UserRole USER_ROLE { get; set; } = null!;

        [ForeignKey("PARENT_1")]
        public int PARENT_1_ID { get; set; }
        public StudentParent PARENT_1 { get; set; } = null!;

        [ForeignKey("PARENT_2")]
        public int PARENT_2_ID { get; set; }
        public StudentParent PARENT_2 { get; set; } = null!;

        [ForeignKey("USER_EMAIL")]
        public int USER_EMAIL_ID { get; set; }
        public UserEmail USER_EMAIL { get; set; } = null!;
    }
}