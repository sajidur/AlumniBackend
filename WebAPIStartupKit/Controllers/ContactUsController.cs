
using StarterKITDAL;
using StartKitBLL;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPIStartupKit.Controllers
{
    public class ContactUsController : ApiController
    {
        private readonly IEmailer _emailer;
        public ContactUsController(IEmailer emailer)
        {
            _emailer = emailer;
        }

        [HttpPost]
        public async Task<bool> Contact(Contact contact)
        {
            return await Task.Run(() => _emailer.SendEmail(contact));
        }
    }
}
