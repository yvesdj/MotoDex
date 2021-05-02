using System.ComponentModel.DataAnnotations;

namespace MotoDex.Models
{
    public class BreakPad
    {
        [Key]
        public int Id { get; set; }
        public string PadType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}