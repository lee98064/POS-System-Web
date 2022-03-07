using System;
using System.ComponentModel.DataAnnotations;

namespace POSSystemApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name {get; set;}
        [Required]
        public int price {get; set;}
        [Required]
        public int amount { get; set; }
        [Required]
        public bool is_sale {get; set; }
    }
}