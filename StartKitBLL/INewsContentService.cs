using StarterKITDAL;
using StartKitBLL.Request;
using System.Collections.Generic;

namespace StartKitBLL
{
    public interface INewsContentService
    {
        int Save(NewsContent newsContent);
        List<NewsContent> GetList(string type);
        NewsContent GetById(int id);
        int Delete(int id);
    }
}