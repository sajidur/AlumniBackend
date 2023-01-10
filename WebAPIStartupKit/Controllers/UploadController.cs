
using StarterKITDAL;
using StartKitBLL;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace WebAPIStartupKit.Controllers
{
    public class UploadController : ApiController
    {

        public string Post()
        {
            var newguid=Guid.NewGuid();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/Upload/" + newguid+postedFile.FileName.Trim());
                    postedFile.SaveAs(filePath);
                    return newguid+postedFile.FileName;
                }
                return "";
            }
            else
            {
                return "";
            }


        }
    }
}
