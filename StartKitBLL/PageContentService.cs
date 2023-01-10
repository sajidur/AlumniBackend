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
    public class ImageConfigService : IImageConfigService
    {
        private IImageConfigRepository _contentRepository;
        private IMapper _mapper;
        public ImageConfigService(IImageConfigRepository contentRepository, IMapper mapper)
        {
            this._contentRepository = contentRepository;
            this._mapper = mapper;
        }
        public int Save(ImageConfiguration newsContent)
        {
           return _contentRepository.Save(newsContent);

        }

        public ImageConfiguration GetById(int id)
        {
            return _contentRepository.GetById(id);
        }

        public int Delete(int id)
        {
            return _contentRepository.Delete(id);
        }

        public IEnumerable<ImageConfiguration> GetAll(string type)
        {
            return _contentRepository.GetAll(type).ToList();
        }
    }

    public interface IImageConfigService
    {
        IEnumerable<ImageConfiguration> GetAll(string type);
        ImageConfiguration GetById(int id);
        int Save(ImageConfiguration rules);
        int Delete(int id);
    }
}
