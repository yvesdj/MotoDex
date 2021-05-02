using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
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

        public ICollection<Tyre> FrontTyre { get; set; }
        public ICollection<Tyre> RearTyre { get; set; }
        public BreakPad FrontBreakPads { get; set; }
        public BreakPad RearBreakPads { get; set; }
    }
}
