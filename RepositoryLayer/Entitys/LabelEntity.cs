<<<<<<< HEAD
﻿using RepositoryLayer.Entitys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entities
=======
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entitys
>>>>>>> 896f895f42d09d1f10c9f51804d233948b59fa77
{
    public class LabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LabelID { get; set; }
<<<<<<< HEAD

        [Required]
        public string LabelName { get; set; }

       
        [ForeignKey("NoteEntity")]
        public long NoteID { get; set; }

        [JsonIgnore]
        public NoteEntity Note { get; set; }

        [JsonIgnore]
        public UserEntity User { get; set; }   
=======
        public string LabelName { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [NotMapped]
        public ICollection<NoteLabelEntity> NoteLabels { get; set; }
>>>>>>> 896f895f42d09d1f10c9f51804d233948b59fa77

    }
}
