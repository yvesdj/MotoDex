using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MotoDex.Models
{
    public class MotorcycleMake
    {
        public MotorcycleMake(string name, string summary)
        {
            Name = name;
            Summary = summary;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }

        //[JsonIgnore]
        public ICollection<Motorcycle> Motorcycles { get; set; }
    }
}