
using StarterKITDAL;
using StartKitBLL;
using StartKitBLL.Response;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace WebAPIStartupKit.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService sliderImage)
        {
            _productService= sliderImage;
        }

        [HttpGet]
        public List<Product> GetAll(int categoryId)
        {
            return _productService.GetAll(categoryId);
        }

        [HttpGet]
        [Route("GetTopList")]
        public List<ProductResponse> GetTopList(int categoryId)
        {
            return _productService.GetTopList(categoryId);
        }
        [HttpGet]
        [Route("Search")]
        public List<ProductResponse> Search(string search)
        {
            return _productService.Search(search);
        }

        [HttpGet]
        [Route("GetByProductId")]
        public ProductResponse GetByProductId(int productId)
        {
            return _productService.GetByProduct(productId);
        }

        [HttpPost]
        [Route("Save")]
        public int Save(Product request)
        {
            var i=_productService.Save(request);
            return i;
        }

        [HttpPost]
        [Route("ProductEdit")]
        public bool ProductEdit(Product request)
        {
            var i = _productService.Save(request);
            return true;
        }

        [HttpPost]
        [Route("ProductDelete")]
        public bool ProductDelete(int Id)
        {
            var i = _productService.ProductDelete(Id);
            return true;
        }

        [HttpPost]
        [Route("ProductImageDelete")]
        public bool ProductImageDelete(int Id)
        {
            var i = _productService.DeleteProductImage(Id);
            return true;
        }

        [HttpPost]
        [Route("SaveProductImage")]
        public bool SaveProductImage(ProductImage request)
        {
            var i = _productService.SaveProductImage(request);
            return true;
        }

    }
}
