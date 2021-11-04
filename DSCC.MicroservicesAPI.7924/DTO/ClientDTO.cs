using DSCC.MicroservicesAPI._7924.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.MicroservicesAPI._7924.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int PlantID { get; set; }

        public Plant Plant { get; set; }
    }
}
