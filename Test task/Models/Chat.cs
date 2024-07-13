using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_task.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public User? Creator { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
