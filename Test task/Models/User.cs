using System.ComponentModel.DataAnnotations;

namespace Test_task.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public List<Chat> Chats { get; set; } = new();
        public List<Chat> MyChats { get; set; } = new();
        public List<Message> Messages { get; set; } = new();
    }
}
