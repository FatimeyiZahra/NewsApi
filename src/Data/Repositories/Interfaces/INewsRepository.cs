using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface INewsRepository : IRepository<News>
    {
        Task<IEnumerable<News>> GetAllNewWithCategories();
        Task<int> GetNewsCountByCategoryId(int categoryId);
        Task<IEnumerable<News>> GetNewsByCategoryId(int categoryId);
        Task<News> GetNewsById(int id);
        Task<IEnumerable<News>> GetSimilarNews(News news);
    }
}
