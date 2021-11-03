using DSCC.MicroservicesAPI._7924.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.MicroservicesAPI._7924.DbContexts
{

    public class FlowerShopDbContext : DbContext
    {
        public FlowerShopDbContext(DbContextOptions<FlowerShopDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Plant> Plants { get; set; }
    }
}
