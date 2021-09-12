using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllOrderedAsync();
    }
}
