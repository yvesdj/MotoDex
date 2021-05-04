using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoDex.Models
{
    public class MotorcycleRearTyres
    {
        public int MotorcycleId { get; set; }
        public Motorcycle Motorcycle { get; set; }

        public int RearTyreId { get; set; }
        public Tyre RearTyre { get; set; }
    }
}
