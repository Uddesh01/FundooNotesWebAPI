
using RepositoryLayer.Entitys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class LabelEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long LabelID { get; set; }


    [Required]
    public string LabelName { get; set; }


    [ForeignKey("NoteEntity")]
    public long NoteID { get; set; }

    [JsonIgnore]
    public NoteEntity Note { get; set; }

    [JsonIgnore]
    public UserEntity User { get; set; }

    [ForeignKey("Users")]
    public int UserId { get; set; }
    [NotMapped]
    public ICollection<NoteLabelEntity> NoteLabels { get; set; }

}

