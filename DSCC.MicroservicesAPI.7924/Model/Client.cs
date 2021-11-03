using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.MicroservicesAPI._7924.Model
{
    public class Client : IBaseDBO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PlantID { get; set; }
        public Plant Plant { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Unknown
    }

}
