
using AspNetCore.Reporting;
using AspNetCore.Reporting.ReportExecutionService;
using StarterKITDAL;
using StartKitBLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebAPIStartupKit.Controllers
{
    [RoutePrefix("api/Download")]
    public class DownloadController : ApiController
    {
        private readonly ICategoryService _categoryService;
        public DownloadController(ICategoryService sliderImage)
        {
            _categoryService = sliderImage;
        }
        [HttpGet]
        [Route("Download")]
        public HttpResponseMessage Download(string transactionNo)
        {
            string mimtype = "";
            int extension = 1;
            var _reportPath = HttpContext.Current.Server.MapPath("~/Report/Report1.rdlc");

            LocalReport localReport = new LocalReport(_reportPath);


            //Dados
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Clear();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(1, "Paulo");
            dt.Rows.Add(2, "Jose");
            localReport.AddDataSource("DataSet1", dt);


            //Parametros do relatório
            var reportParams = new Dictionary<string, string>();
            //reportParams.Add("Key1", "value1");
            //reportParams.Add("Key2", "value2");
            if (reportParams != null && reportParams.Count > 0)// if you use parameter in report
            {
                List<ReportParameter> reportparameter = new List<ReportParameter>();
                foreach (var record in reportParams)
                {
                    reportparameter.Add(new ReportParameter());
                }

            }

            //Geração do arquivo
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters: reportParams);
            byte[] file = result.MainStream;

            Stream stream = new MemoryStream(file);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = transactionNo+".pdf";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }
    }
}
