using ReptileAPI.Authentication;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ReptileAPI.Models
{
    public class Animal
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("SpeciesId")]
        public virtual Species Species { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DOB { get; set; }

        [NotMapped]
        public int Age { get { return new DateTime((DateTime.Now - DOB).Ticks).Year - 1; } }


        [DisplayName("Feeding Size")]
        public string? Feeding_Size { get; set; }

        [DisplayName("Feeding Schedule")]
        public int? Feeding_Schedule { get; set; }

        [DisplayName("Water Change")]
        public int? Water_Change { get; set; }

        [DisplayName("Bedding Change")]
        public int? Bedding_Change { get; set; }
        public virtual List<Morph>? Morphs { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser? User { get; set; }
    }
}