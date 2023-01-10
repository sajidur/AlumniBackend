using AutoMapper;
using StarterKITDAL;
using StarterKITDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartKitBLL
{
    public interface IMemberService
    {
        int Save(Member member);
        List<Member> GetList();
        Member GetById(int id);
        int Delete(int id);
    }
    public class MemberService : IMemberService
    {
        private IMemberRepository _memberRepository;
        private IUserRepository _userRepository;
        private IMapper _mapper;
        public MemberService(IMemberRepository memberRepository, IUserRepository userRepository, IMapper mapper)
        {
            this._memberRepository = memberRepository;
            _userRepository= userRepository;
            this._mapper = mapper;
        }

        int IMemberService.Delete(int id)
        {
            return _memberRepository.Delete(id);
        }

        Member IMemberService.GetById(int id)
        {
            return _memberRepository.GetById(id);
        }


        List<Member> IMemberService.GetList()
        {
           return _memberRepository.GetList();
        }

        int IMemberService.Save(Member member)
        {
            var id= _memberRepository.Save(member);
            try
            {
                //check user
                var userCheck=_userRepository.GetByUserName(member.Mobile.ToString());
                if (userCheck==null)
                {
                    User user = new User();
                    user.UserName = member.Mobile.ToString();
                    user.Password = member.Mobile.ToString();
                    user.CompanyId = id;
                    _userRepository.Save(user);
                }
            }
            catch (Exception ex)
            {

            }
            return id;
        }
    }


}
