using Data.Entities;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.Implementations
{
    public class NewsCategoryRepository : Repository<NewsCategory>, INewsCategoryRepository
    {
        public NewsCategoryRepository(ApplicationDbContext context) : base(context) { }
    }

}
