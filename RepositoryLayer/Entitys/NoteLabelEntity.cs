using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepositoryLayer.Entitys
{
    public class NoteLabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LabelNoteID { get; set; }

        public long LabelID { get; set; }
        public LableEntity Label { get; set; }

        public long NoteID { get; set; }
        public NoteEntity Note { get; set; }
    }
}
