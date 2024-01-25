using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entitys
{
    public class LableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LableID { get; set; }
        public string LableName { get; set; }
        [JsonIgnore]
        public virtual UserEntity User { get; set; }
        [ForeignKey("Notes")]
        public long NoteID { get; set; }
        [JsonIgnore]
        public virtual NoteEntity Note { get; set; }
        public ICollection<NoteEntity> NoteLabels { get; set; }

    }
}
