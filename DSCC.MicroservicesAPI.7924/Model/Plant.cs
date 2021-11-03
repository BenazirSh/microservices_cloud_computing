using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DSCC.MicroservicesAPI._7924.Model
{
    public class Plant : IBaseDBO
    {
        public int Id { get; set; }
        public string PlantName { get; set; }
        public PlantType PlantType { get; set; }

        [JsonIgnore]
        public virtual ICollection<Client> Clients { get; set; }
    }

    //[JsonConverter(typeof(StringEnumConverter))]
    public enum PlantType
    {
        Flower,
        Bush,
        Tree

    }
}
