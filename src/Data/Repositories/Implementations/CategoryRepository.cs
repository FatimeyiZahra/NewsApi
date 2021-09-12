using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }
        private ApplicationDbContext _context => Context as ApplicationDbContext;

        public async Task<IEnumerable<Category>> GetAllOrderedAsync()
        {
            return await _context.Categories.Where(c => c.Status).OrderBy(c => c.OrderBy).ToListAsync();

        }
    }
}
