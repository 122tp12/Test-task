using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Test_task.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
        public virtual ICollection<Chat> MyChats { get; set; } = new List<Chat>();
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
