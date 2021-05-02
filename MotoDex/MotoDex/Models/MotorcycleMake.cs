using System.ComponentModel.DataAnnotations;

namespace MotoDex.Models
{
    public class MotorcycleMake
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }

        public Motorcycle[] Motorcycles { get; set; }
    }
}