using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class News :BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public List<NewsCategory> NewsCategories { get; set; }

        public ICollection<NewsPhoto> NewsPhotos { get; set; }


    }
}
