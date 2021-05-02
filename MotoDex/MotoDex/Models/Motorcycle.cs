using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MotoDex.Models
{
    public class Motorcycle
    {
        [Key]
        public int Id { get; set; }
        public MotorcycleMake Make { get; set; }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string FinalDrive { get; set; }
        public Tyre FrontTyre { get; set; }
        public Tyre RearTyre { get; set; }
        public BreakPad FrontBreakPads { get; set; }
        public BreakPad RearBreakPads { get; set; }
    }
}
