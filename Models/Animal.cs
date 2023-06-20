using System.ComponentModel;

namespace ReptileAPI.Models
{
    public class Animal
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DOB { get; set; }
    }
}