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
        public string Make { get; set; }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string FrontTyre { get; set; }
        public string RearTyre { get; set; }
        public string FrontBreakPads { get; set; }
        public string RearBreakPads { get; set; }
    }
}
