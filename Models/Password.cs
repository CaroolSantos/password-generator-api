using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace PasswordGeneratorAPI.Models
{
    public class Password
    {
        [Key]
        public int Id { get; set; }
        public string GeneratedPassword { get; set; }
        public DateTime GeneratedAt { get; set; }
    }
}
