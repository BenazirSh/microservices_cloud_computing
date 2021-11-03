using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.MicroservicesAPI._7924.Repository
{
    public interface IRepo<T> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Boolean Exists(int id);

    }
}
