using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL
{
    public class Category:BaseEntity
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string TitleText { get; set; }
        public string ImageUrl { get; set; }
    }
}
