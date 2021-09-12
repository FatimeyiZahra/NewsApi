using Data.Entities;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.Implementations
{
    public class NewsPhotoRepository : Repository<NewsPhoto>, INewsPhotoRepository
    {
        public NewsPhotoRepository(ApplicationDbContext context) : base(context) { }
    }

}
