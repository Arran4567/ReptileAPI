﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ReptileAPI.Models
{
    public class Morph
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<Animal>? Animals { get; set; }
    }
}
