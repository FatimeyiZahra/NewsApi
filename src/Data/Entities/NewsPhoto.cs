using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class NewsPhoto :BaseEntity
    {
        public int NewsId { get; set; }
        public string Photo { get; set; }

        public News News { get; set; }
    }
}
