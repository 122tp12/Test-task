﻿using System.ComponentModel.DataAnnotations;
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

        public List<User> Users { get; set; } = new();
        public List<Message> Messages { get; set; } = new();
    }
}
