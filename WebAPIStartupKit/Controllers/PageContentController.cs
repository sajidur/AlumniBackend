using StarterKITDAL;
using StartKitBLL;
using StartKitBLL.Request;
using StartKitBLL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPIStartupKit.Controllers
{
    [RoutePrefix("api/PageContent")]
    public class PageContentController : ApiController
    {
        // GET: SalaryItem
        private readonly IPageContentService _newsContent;
        public PageContentController(IPageContentService newsContent)
        {
            _newsContent = newsContent;
        }

        [HttpPost]
        [Route("Post")]
        public bool Post(PageContent request)
        {
            _newsContent.Save(request);
            return true;
        }

        [HttpPost]
        [Route("Edit")]
        public bool Edit(PageContent request)
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
        public IEnumerable<PageContent> GetAll()
        {
           return _newsContent.GetAll("");
        }
    }
}