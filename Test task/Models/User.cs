using System.ComponentModel.DataAnnotations;

namespace Test_task.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
