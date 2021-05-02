using System.ComponentModel.DataAnnotations;

namespace MotoDex.Models
{
    public class Tyre
    {
        [Key]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int TyreWidth { get; set; }
        public int HeightAspect { get; set; }
        public int RimSize { get; set; }
    }
}