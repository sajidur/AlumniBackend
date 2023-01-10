using AutoMapper;
using StarterKITDAL;
using StarterKITDAL.Repository;
using StartKitBLL.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartKitBLL
{
    public class PageContentService: IPageContentService
    {
        private IPageContentRepository _contentRepository;
        private IMapper _mapper;
        public PageContentService(IPageContentRepository contentRepository, IMapper mapper)
        {
            this._contentRepository = contentRepository;
            this._mapper = mapper;
        }
        public int Save(PageContent newsContent)
        {
           return _contentRepository.Save(newsContent);

        }

        public PageContent GetById(int id)
        {
            return _contentRepository.GetById(id);
        }

        public int Delete(int id)
        {
            return _contentRepository.Delete(id);
        }

        public IEnumerable<PageContent> GetAll(string type)
        {
            return _contentRepository.GetAll(type).ToList();
        }
    }

    public interface IPageContentService
    {
        IEnumerable<PageContent> GetAll(string type);
        PageContent GetById(int id);
        int Save(PageContent rules);
        int Delete(int id);
    }
}
