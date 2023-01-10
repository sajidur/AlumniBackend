using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL.Repository
{
    public interface IPageContentRepository
    {
        IEnumerable<PageContent> GetAll(string type);
        PageContent GetById(int id);
        int Save(PageContent rules);
        int Delete(int id);
    }
    public class PageContentRepository : IPageContentRepository
    {
        ApplicationDbContext _context;
        public PageContentRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public int Delete(int id)
        {
            var data= _context.PageContents.Where(a => a.Id == id).FirstOrDefault();
            _context.PageContents.Remove(data);
            return _context.SaveChanges();
        }

        public IEnumerable<PageContent> GetAll(string type)
        {
            return _context.PageContents.ToList();
        }

        public PageContent GetById(int id)
        {
            return _context.PageContents.Where(a=>a.Id==id).FirstOrDefault();

        }


        public int Save(PageContent newsContent)
        {
            if (newsContent.Id > 0)
            {
                _context.PageContents.Attach(newsContent);
                _context.Entry(newsContent).State = EntityState.Modified;
            }
            else
            {
                _context.PageContents.Add(newsContent);
            }
            _context.SaveChanges();
            return newsContent.Id;
        }

    }
}
