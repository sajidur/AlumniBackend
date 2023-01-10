using StarterKITDAL;
using StartKitBLL;
using StartKitBLL.Request;
using StartKitBLL.Response;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPIStartupKit.Controllers
{
    [RoutePrefix("api/NewsContent")]
    public class NewsContentController : ApiController
    {
        // GET: SalaryItem
        private readonly INewsContentService _newsContent;
        public NewsContentController(INewsContentService newsContent)
        {
            _newsContent = newsContent;
        }

        [HttpPost]
        public bool Post(NewsContent request)
        {
            _newsContent.Save(request);
            return true;
        }

        [Route("Delete"), HttpPost]
        public bool Delete(int id)
        {
            _newsContent.Delete(id);
            return true;
        }

        [HttpGet]
        public List<NewsContent> GetAll()
        {
           return _newsContent.GetList("");
        }
    }
}