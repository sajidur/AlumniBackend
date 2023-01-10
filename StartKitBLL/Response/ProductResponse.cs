using StarterKITDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartKitBLL.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string TitleText { get; set; }
        public string InStockText { get; set; }
        public string ShortText { get; set; }
        public decimal Price { get; set; }
        public string DetailText { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
