using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL.Repository
{
    public interface IImageConfigRepository
    {
        IEnumerable<ImageConfiguration> GetAll(string type);
        ImageConfiguration GetById(int id);
        int Save(ImageConfiguration rules);
        int Delete(int id);
    }
    public class ImageConfigRepository : IImageConfigRepository
    {
        ApplicationDbContext _context;
        public ImageConfigRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public int Delete(int id)
        {
            var data= _context.ImageConfigurations.Where(a => a.Id == id).FirstOrDefault();
            _context.ImageConfigurations.Remove(data);
            return _context.SaveChanges();
        }

        public ImageConfiguration GetById(int id)
        {
            return _context.ImageConfigurations.Where(a=>a.Id==id).FirstOrDefault();

        }

        public int Save(ImageConfiguration newsContent)
        {
            if (newsContent.Id > 0)
            {
                _context.ImageConfigurations.Attach(newsContent);
                _context.Entry(newsContent).State = EntityState.Modified;
            }
            else
            {
                _context.ImageConfigurations.Add(newsContent);
            }
            _context.SaveChanges();
            return newsContent.Id;
        }

        IEnumerable<ImageConfiguration> IImageConfigRepository.GetAll(string type)
        {
            return _context.ImageConfigurations.ToList();
        }
    }
}
