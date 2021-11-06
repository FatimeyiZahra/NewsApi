using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Data.Repositories.Implementations
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(ApplicationDbContext context) : base(context) { }
        private ApplicationDbContext _context => Context as ApplicationDbContext;

        public async Task<IEnumerable<News>> GetAllNewWithCategories()
        {
            return await _context.News
                                  .Include(p => p.NewsCategories).ThenInclude(p => p.Category)
                                  //.Include("NewsCategories")
                                  //.Include("NewsCategories.Category")
                                  .Where(n => n.Status)
                                  .Include(p => p.NewsPhotos)
                                  .ToListAsync();
            //.Include(p => p.Discounts).ThenInclude(p => p.Discount)

        }

        public async Task<IEnumerable<News>> GetSimilarNews(News news)
        {
            return await _context.News
                        .Include("NewsCategories.Category")
                        .Where(n => n.NewsCategories
                        .Any(c => c.Category.Name
                        .Contains(news.NewsCategories.FirstOrDefault().Category.Name)))
                        .ToListAsync();
        }
        public async Task<IEnumerable<News>> GetNewsByCategoryId(int categoryId)
        {
            return await _context.News
                                    .Include(p => p.NewsPhotos)
                                    //.IncludeFilter(p => p.NewsCategories.FirstOrDefault(s => s.CategoryId == categoryId))
                                    .Where(p => p.NewsCategories.Any(c => c.CategoryId == categoryId))
                                    .OrderByDescending(p => p.AddedDate)
                                    .ToListAsync();
        }

        public async Task<News> GetNewsById(int id)
        {
            return await _context.News
                                      .Include("NewsCategories")
                                      .Include("NewsCategories.Category")
                                      .Include(p => p.NewsPhotos)
                                      .Where(p => p.Status && p.Id == id)
                                      .FirstOrDefaultAsync();
        }

        public async Task<int> GetNewsCountByCategoryId(int categoryId)
        {
            return await _context.News
                                    .Include(p => p.NewsPhotos)
                                    .Where(p => p.Status)
                                    .IncludeFilter(p => p.NewsCategories.FirstOrDefault(s => s.CategoryId == categoryId))
                                    .CountAsync();
        }


    }
}
