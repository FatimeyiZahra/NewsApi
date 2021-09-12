using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Resources
{
    public class NewsResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string[] Photos { get; set; }
        public string Text { get; set; }
        public List<string> NewsCategories { get; set; }
    }
}
