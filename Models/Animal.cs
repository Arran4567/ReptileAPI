using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReptileAPI.Models
{
    public class Animal
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DOB { get; set; }

        [NotMapped]
        public int Age { get{ return new DateTime((DateTime.Now - DOB).Ticks).Year - 1;} }

        public string? Species { get; set; } 
    }
}