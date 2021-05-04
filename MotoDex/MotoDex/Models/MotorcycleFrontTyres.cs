using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoDex.Models
{
    public class MotorcycleFrontTyres
    {
        public int MotorcycleId { get; set; }
        public Motorcycle Motorcycle { get; set; }

        public int FrontTyreId { get; set; }
        public Tyre FrontTyre { get; set; }
    }
}
