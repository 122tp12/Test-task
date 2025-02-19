﻿using System.ComponentModel.DataAnnotations;

namespace Test_task.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int ChatId { get; set; }
        public Chat? Chat { get; set; }
        public string? Content { get; set; }
    }
}
