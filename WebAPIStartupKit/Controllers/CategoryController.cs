
using StarterKITDAL;
using StartKitBLL;
using StartKitBLL.Response;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace WebAPIStartupKit.Controllers
{
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService sliderImage)
        {
            _categoryService= sliderImage;
        }

        [HttpGet]
        public List<Category> GetAll()
        {
            return _categoryService.GetAll();
        }

        [HttpGet]
        [Route("GetByMenu")]
        public List<Category> GetByMenu(int menuId)
        {
            return _categoryService.GetByMenuId(menuId);
        }
        [HttpPost]
        [Route("Save")]
        public bool Save(Category category)
        {
            var i=_categoryService.Save(category);
            return true;
        }

    }
}
