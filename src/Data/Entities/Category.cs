using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Category :BaseEntity
    {
        public int OrderBy { get; set; }

        public string Name { get; set; }

        public List<NewsCategory> NewsCategories { get; set; }
    }
}
