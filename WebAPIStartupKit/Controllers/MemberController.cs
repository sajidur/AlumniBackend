
using StarterKITDAL;
using StartKitBLL;
using StartKitBLL.Response;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace WebAPIStartupKit.Controllers
{
    [RoutePrefix("api/Member")]
    public class MemberController : ApiController
    {
        private readonly IMemberService _memberService;
        private readonly IUploadService _uploadService;
        public MemberController(IMemberService memberService, IUploadService uploadService)
        {
            _memberService = memberService;
            _uploadService = uploadService;
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Member> GetAll()
        {
            return _memberService.GetList();
        }

        [HttpGet]
        [Route("GetById")]
        public Member GetById(int id)
        {
            return _memberService.GetById(id);
        }

        [HttpPost]
        [Route("Delete")]
        public bool Delete(int id)
        {
            _memberService.Delete(id);
            return true;
        }

        [HttpPost]
        [Route("Save")]
        public int Save(Member member)
        {
            var httpRequest = HttpContext.Current.Request;
            if (string.IsNullOrEmpty(member.ProfilePicture))
            {
                var fileUrl = _uploadService.UploadImage(httpRequest.Files);
                member.ProfilePicture = fileUrl;
            }
            var i =_memberService.Save(member);

            return i;
        }

        [HttpPost]
        [Route("Update")]
        public int Update(Member member)
        {
            var httpRequest = HttpContext.Current.Request;
            var i = _memberService.Save(member);

            return i;
        }

    }
}
