using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MotoDex.Models
{
    public class Tyre
    {
        [Key]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public float TyreWidth { get; set; }
        public int HeightAspect { get; set; }
        public int RimSize { get; set; }

        //[JsonIgnore]
        public virtual ICollection<MotorcycleFrontTyres> MotorcycleFrontTyres { get; set; }
        public virtual ICollection<MotorcycleRearTyres> MotorcycleRearTyres { get; set; }
    }
}