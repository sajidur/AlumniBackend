using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL
{
    public class NewsContent:BaseEntity
    {
        public string Type { get; set; }
        public string Headline { get; set; }
        public string ImageUrl { get; set; }
        public string MainText { get; set; }
        public string DetailText { get; set; }
        public int Order { get; set; }

    }
}
