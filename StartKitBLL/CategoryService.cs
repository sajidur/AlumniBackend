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
   public  class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;
        public CategoryService(ICategoryRepository sliderImageRepository, IMapper mapper)
        {
            this._categoryRepository = sliderImageRepository;
            this._mapper = mapper;
        }

        public List<Category> GetAll()
        {
            var salaryItems = _categoryRepository.GetAll().ToList();
            return salaryItems;
        }
        public List<Category> GetByMenuId(int menuId)
        {
            var salaryItems = _categoryRepository.GetByMenuId(menuId).ToList();
            return salaryItems;
        }

        public int Save(Category product)
        {
            return _categoryRepository.Save(product);
        }
    }

    public interface ICategoryService
    {
        int Save(Category product);
        List<Category> GetByMenuId(int menuId);
        List<Category> GetAll();
    }
}
