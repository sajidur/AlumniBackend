using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public ICollection<Product> GetAll(int categoryId)
        {
            return _context.Products.Where(a => a.CategoryId == categoryId).ToList();
        }

        public Product GetByProduct(int productId)
        {
            return _context.Products.Where(a => a.Id == productId).FirstOrDefault();
        }
        public List<Product> Search(string search)
        {
            return _context.Products.Where(a => a.Name.Contains(search)||a.ShortText.Contains(search)).ToList();
        }

        public ICollection<ProductImage> GetProductImages(int productId)
        {
            return _context.ProductImages.Where(a => a.ProductId==productId).ToList();
        }

        public int Save(Product sliderImage)
        {
            if (sliderImage.Id>0)
            {
                _context.Products.Attach(sliderImage);
                _context.Entry(sliderImage).State = EntityState.Modified;
            }
            else
            {
                _context.Products.Add(sliderImage);
            }
            _context.SaveChanges();
            return sliderImage.Id;   
        }

        public int SaveProductImage(ProductImage sliderImage)
        {
            _context.ProductImages.Add(sliderImage);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var data = _context.Products.Where(a => a.Id == id).FirstOrDefault();
            _context.Products.Remove(data);
            return _context.SaveChanges();
        }
        public List<ProductImage> ProductImageDeleteByProductId(int productId)
        {
            try
            {
                var data = _context.ProductImages.Where(a => a.ProductId == productId).ToList();
                foreach (var item in data)
                {
                    _context.ProductImages.Remove(item);
                }
                _context.SaveChanges();
                return data;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ProductImage ProductImageDelete(int id)
        {
            var data = _context.ProductImages.Where(a => a.Id == id).FirstOrDefault();
            _context.ProductImages.Remove(data);
            _context.SaveChanges();
            return data;
        }
    }
}
