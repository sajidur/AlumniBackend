using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL.Repository
{
    public interface IProductRepository
    {
        ICollection<Product> GetAll(int categoryId);
        Product GetByProduct(int productId);
        ICollection<ProductImage> GetProductImages(int productId);
        int Save(Product sliderImage);
        int Delete(int id);
        ProductImage ProductImageDelete(int id);
        List<ProductImage> ProductImageDeleteByProductId(int productId);
        int SaveProductImage(ProductImage sliderImage);
        List<Product> Search(string search);
    }
}
