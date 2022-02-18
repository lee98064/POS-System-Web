using System;
using System.ComponentModel.DataAnnotations;

namespace POSSystemApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string name {get; set;}
        public string account { get; set; }
        public string password { get; set; }
    }
}