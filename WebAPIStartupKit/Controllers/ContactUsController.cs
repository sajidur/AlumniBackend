
using StarterKITDAL;
using StarterKITDAL.Migrations;
using StartKitBLL;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPIStartupKit.Controllers
{
    [RoutePrefix("api/Download")]
    public class ContactUsController : ApiController
    {
        private readonly IEmailer _emailer;
        private readonly ISMSSender _sMSSender;

        public ContactUsController(IEmailer emailer, ISMSSender sMSSender)
        {
            _emailer = emailer;
            _sMSSender = sMSSender;
        }

        [HttpPost]
        public async Task<bool> Contact(Contact contact)
        {
            return await Task.Run(() => _emailer.SendEmail(contact));
        }
        [HttpPost]
        [Route("SMS")]
        public bool SMS(Contact contact)
        {
            var transaction=new Transaction();
            transaction.MemberId = 21;
            transaction.BkashTransactionId = "Txn001";
            var text = "Your Event registration approved. Please click https://alumnibackend.rexsystemsbd.com/api/Download/Download?memberId=" + transaction.MemberId + "&transactionNo=" + transaction.BkashTransactionId + ".";
            var res= _sMSSender.SendOrPostCallback("01719304970", text, "").Status;
            return true;
        }
    }
}
