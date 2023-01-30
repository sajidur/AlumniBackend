using RestSharp;
using StarterKITDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StartKitBLL
{
    public interface ISMSSender
    {
        Task Send(string mobileNumber, string smsText, string campaign);
    }
    public class SMSSender : ISMSSender
    {
        public async Task Send(string mobileNumber, string smsText, string campaign)
        {
            HttpClient client =new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            await ProcessRepositoriesAsync(client,mobileNumber,smsText,campaign);
            //RestClient client = new RestClient(string.Concat("http://bulksmsbd.net/api/smsapi?api_key=VHmXiN5uA6Qk9HzeiTNn&type=text&number="+mobileNumber+"&senderid=8809617611061&message="+smsText+""));
            //RestClientExtensions.AddDefaultParameter(client, "msg", smsText);
            //RestRequest request = new RestRequest();
            //request.AddHeader("accept", "application/json");
            //request.AddHeader("content-type", "application/json");
            //var content = client.ExecuteGet(request).Content;
            //return content;
        }

        static async Task ProcessRepositoriesAsync(HttpClient client, string mobileNumber, string smsText, string campaign)
        {
            var json = await client.GetAsync("http://bulksmsbd.net/api/smsapi?api_key=VHmXiN5uA6Qk9HzeiTNn&type=text&number=" + mobileNumber + "&senderid=8809617611061&message=" + smsText + "");

            Console.Write(json);
        }
    }

}
