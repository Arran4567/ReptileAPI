using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ReptileAPI.Models
{
    public class Condition
    {
        [Key]
        public Guid Id { get; set; }
        public double HotSpotTemp { get; set; }
        public double AmbientTemp { get; set; }
        public int Humidity { get; set; }

    }
}
