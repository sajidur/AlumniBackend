using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public ICollection<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public List<Category> GetByMenuId(int menuId)
        {
            return _context.Categories.Where(a => a.MenuId == menuId).ToList();
        }

        public int Save(Category category)
        {
            _context.Categories.Add(category);
            return _context.SaveChanges();
        }
    }

    public interface ICategoryRepository
    {
        ICollection<Category> GetAll();
        List<Category> GetByMenuId(int menuId);
        int Save(Category category);
    }
}
