using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.Implementations;
using Data.Repositories.Interfaces;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private CategoryRepository _categoryRepository;
        private NewsCategoryRepository _newsCategoryRepository;
        private NewsPhotoRepository _newsPhotoRepository;
        private NewsRepository _newsRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public ICategoryRepository Category => _categoryRepository ??= new CategoryRepository(_context);


        public INewsCategoryRepository NewsCategory => _newsCategoryRepository ??= new NewsCategoryRepository(_context);

        public INewsPhotoRepository NewsPhoto => _newsPhotoRepository ??= new NewsPhotoRepository(_context);

        public INewsRepository News => _newsRepository ??= new NewsRepository(_context);






        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
