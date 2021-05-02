using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MotoDex.Models
{
    public class Engine
    {
        [Key]
        public int Id { get; set; }
        public string EngineType { get; set; }
        public string EngineConfiguration { get; set; }
        public float Capacity { get; set; }
        public float MaxPower { get; set; }
        public float MaxTorque { get; set; }
        public string Cooling { get; set; }
        public string InductionType { get; set; }
        public string SparkPlug { get; set; }

    }
}
