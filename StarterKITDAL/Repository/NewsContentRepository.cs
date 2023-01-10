using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL.Repository
{
    public class NewsContentRepository : INewsContentRepository
    {
        ApplicationDbContext _context;
        public NewsContentRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public int Delete(int id)
        {
            var data= _context.NewsContents.Where(a => a.Id == id).FirstOrDefault();
            _context.NewsContents.Remove(data);
            return _context.SaveChanges();
        }

        public NewsContent GetById(int id)
        {
            return _context.NewsContents.Where(a=>a.Id==id).FirstOrDefault();

        }

        public int Save(NewsContent newsContent)
        {
            _context.NewsContents.Add(newsContent);
           return _context.SaveChanges();
        }

        ICollection<NewsContent> INewsContentRepository.GetAll(string type)
        {
           return _context.NewsContents.ToList();
        }
    }
}
