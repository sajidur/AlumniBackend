using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL
{
    public class ProductImage:BaseEntity
    {
        public bool IsDefault { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageText { get; set; }
    }
}
