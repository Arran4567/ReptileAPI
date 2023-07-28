using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReptileAPI.Models
{
    public class Animal
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Species { get; set; }

        public string Sex { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DOB { get; set; }

        [NotMapped]
        public int Age { get { return new DateTime((DateTime.Now - DOB).Ticks).Year - 1; } }

        public string? Morphs { get; set; }

        [DisplayName("Feeding Size")]
        public string? Feeding_Size { get; set; }

        [DisplayName("Feeding Schedule")]
        public int? Feeding_Schedule { get; set; }

        [DisplayName("Water Change")]
        public int? Water_Change { get; set; }

        [DisplayName("Bedding Change")]
        public int? Bedding_Change { get; set; }
    }
}