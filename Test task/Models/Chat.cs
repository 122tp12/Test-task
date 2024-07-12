using System.ComponentModel.DataAnnotations;

namespace Test_task.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public User? Creator { get; set; }
        public List<User> Users { get; set; } = new();
        public List<Message> Messages { get; set; } = new();
    }
}
