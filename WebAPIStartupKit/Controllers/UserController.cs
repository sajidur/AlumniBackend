
using StarterKITDAL;
using StartKitBLL;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPIStartupKit.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public User Login(User contact)
        {
            return _userService.Login(contact);
        }

        [HttpPost]
        [Route("Signup")]
        public User Signup(User contact)
        {
            return _userService.Signup(contact);
        }
    }
}
