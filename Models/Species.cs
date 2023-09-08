using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReptileAPI.Models
{
    public class Species
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("ConditionId")]
        public virtual Condition Condition { get; set; }
    }
}
