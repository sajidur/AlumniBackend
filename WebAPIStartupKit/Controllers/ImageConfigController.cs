using StarterKITDAL;
using StartKitBLL;
using StartKitBLL.Request;
using StartKitBLL.Response;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPIStartupKit.Controllers
{
    [RoutePrefix("api/ImageConfig")]
    public class ImageConfigController : ApiController
    {
        // GET: SalaryItem
        private readonly IImageConfigService _newsContent;
        public ImageConfigController(IImageConfigService newsContent)
        {
            _newsContent = newsContent;
        }

        [HttpPost]
        [Route("Post")]
        public bool Post(ImageConfiguration request)
        {
            _newsContent.Save(request);
            return true;
        }

        [HttpPost]
        [Route("Edit")]
        public bool Edit(ImageConfiguration request)
        {
            _newsContent.Save(request);
            return true;
        }

        [HttpPost]
        [Route("Delete")]
        public bool Delete(int id)
        {
            _newsContent.Delete(id);
            return true;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<ImageConfiguration> GetAll()
        {
           return _newsContent.GetAll("");
        }
    }
}