using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        INewsCategoryRepository NewsCategory { get; }
        INewsPhotoRepository NewsPhoto { get; }
        INewsRepository News { get; }
        Task<int> CommitAsync();
    }
}
