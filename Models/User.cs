using System;
using System.ComponentModel.DataAnnotations;

namespace POSSystemApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string email {get; set;}
        [Required]
        public string name {get; set;}
        [Required]
        public string account { get; set; }
        [Required]
        public string password { get; set; }
    }
}