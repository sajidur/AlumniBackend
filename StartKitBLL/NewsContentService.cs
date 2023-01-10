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
    public class NewsContentService:INewsContentService
    {
        private INewsContentRepository  _newsContentRepository;
        private IMapper _mapper;
        public NewsContentService(INewsContentRepository rulesRepository, IMapper mapper)
        {
            this._newsContentRepository = rulesRepository;
            this._mapper = mapper;
        }
        public int Save(NewsContent newsContent)
        {
           return  _newsContentRepository.Save(newsContent);

        }
        public List<NewsContent> GetList(string type)
        {
           return  _newsContentRepository.GetAll(type).ToList();
        }

        public NewsContent GetById(int id)
        {
            return _newsContentRepository.GetById(id);
        }

        public int Delete(int id)
        {
            return _newsContentRepository.Delete(id);
        }
    }
}
