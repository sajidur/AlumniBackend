using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL.Repository
{
    public interface INewsContentRepository
    {
        ICollection<NewsContent> GetAll(string type);
        NewsContent GetById(int id);
        int Save(NewsContent rules);
        int Delete(int id);
    }
}
