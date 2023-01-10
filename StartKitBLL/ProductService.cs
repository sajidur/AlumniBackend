using AutoMapper;
using StarterKITDAL;
using StarterKITDAL.Repository;
using StartKitBLL.Request;
using StartKitBLL.Response;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartKitBLL
{
   public  class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IUploadService _uploadService;
        private IMapper _mapper;
        public ProductService(IProductRepository sliderImageRepository, IUploadService uploadService, IMapper mapper)
        {
            this._productRepository = sliderImageRepository;
            _uploadService = uploadService;
            this._mapper = mapper;
        }

        public List<Product> GetAll(int categoryId)
        {
            var salaryItems = _productRepository.GetAll(categoryId).ToList();
            return salaryItems;
        }
        public List<ProductResponse> Search(string search)
        {
            List<ProductResponse> list = new List<ProductResponse>();

            var products = _productRepository.Search(search);
            foreach (var product in products)
            {
                var productResponse = new ProductResponse()
                {
                    CategoryId = product.CategoryId,
                    DetailText = product.DetailText,
                    InStockText = product.InStockText,
                    Name = product.Name,
                    Price = product.Price,
                    ShortText = product.ShortText,
                    TitleText = product.TitleText,
                    Id = product.Id

                };
                productResponse.Images = _productRepository.GetProductImages(product.Id).ToList();
                list.Add(productResponse);
            }
            return list;
        }
        public List<ProductResponse> GetTopList(int categoryId)
        {
            List<ProductResponse> list = new List<ProductResponse>();
            var products = _productRepository.GetAll(categoryId).ToList();
            foreach (var product in products)
            {
                var productResponse = new ProductResponse()
                {
                    CategoryId=product.CategoryId,
                    DetailText=product.DetailText,
                    InStockText=product.InStockText,
                    Name=product.Name,
                    Price=product.Price,
                    ShortText=product.ShortText,
                    TitleText=product.TitleText,
                    Id=product.Id

                };
                productResponse.Images = _productRepository.GetProductImages(product.Id).ToList();
                list.Add(productResponse);
            }
            return list;
        }

        public ProductResponse GetByProduct(int productId)
        {
            var product = _productRepository.GetByProduct(productId);
            if (product!=null)
            {
                var productResponse = new ProductResponse()
                {
                    CategoryId = product.CategoryId,
                    DetailText = product.DetailText,
                    InStockText = product.InStockText,
                    Name = product.Name,
                    Price = product.Price,
                    ShortText = product.ShortText,
                    TitleText = product.TitleText,
                    Id = product.Id

                };
                productResponse.Images = _productRepository.GetProductImages(productId).ToList();
                return productResponse;
            }
            else
            {
               return new ProductResponse();
            }

        }

        public int Save(Product product)
        {
            return _productRepository.Save(product);
        }
        public int SaveProductImage(ProductImage request)
        {
            return _productRepository.SaveProductImage(request);
        }

        public bool DeleteProductImage(int productId)
        {
            var productImage = _productRepository.ProductImageDelete(productId);
            _uploadService.DeleteImage(productImage.ImageUrl);
            return true;
        }

        public bool ProductDelete(int Id)
        {
            _productRepository.Delete(Id);
            var list = _productRepository.GetProductImages(Id);
            foreach (var item in list)
            {
                _uploadService.DeleteImage(item.ImageUrl);
            }
            return true;
        }
    }
}
