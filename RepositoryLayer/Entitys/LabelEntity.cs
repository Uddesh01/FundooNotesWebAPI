using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entitys
{
    public class LabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LabelID { get; set; }
        public string LabelName { get; set; }
        [ForeignKey("Notes")]
        public long NoteID { get; set; }
        public ICollection<NoteLabelEntity> NoteLabels { get; set; }

    }
}
