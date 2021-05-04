using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MotoDex.Models
{
    public class Motorcycle
    {
        [Key]
        public int Id { get; set; }

        public int MakeId { get; set; }
        public MotorcycleMake Make { get; set; }

        public string Model { get; set; }

        public int EngineId { get; set; }
        public Engine Engine { get; set; }

        public string FinalDrive { get; set; }

        [ForeignKey("FrontTyreId")]
        public ICollection<int> FrontTyreId { get; set; }
        public virtual ICollection<Tyre> FrontTyre { get; set; }
        //public virtual ICollection<Tyre> RearTyre { get; set; }

        public int FrontBreakPadsId { get; set; }
        public BreakPad FrontBreakPads { get; set; }

        public int RearBreakPadsId { get; set; }
        public BreakPad RearBreakPads { get; set; }
    }
}
