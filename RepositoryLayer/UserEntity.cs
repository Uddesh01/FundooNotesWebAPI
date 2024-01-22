using System.ComponentModel.DataAnnotations;

namespace RepositoryLayer
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserContact { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

}
