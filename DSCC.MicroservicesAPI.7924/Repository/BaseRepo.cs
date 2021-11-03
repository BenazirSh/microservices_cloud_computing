using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.MicroservicesAPI._7924.Repository
{
    public abstract class BaseRepo<T> where T : class
    {
        protected readonly DbContexts.FlowerShopDbContext _context;

        protected BaseRepo(DbContexts.FlowerShopDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
