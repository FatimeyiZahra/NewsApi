using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class NewsCategory
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int CategoryId { get; set; }
        public News News { get; set; }
        public Category Category { get; set; }
    }
}
