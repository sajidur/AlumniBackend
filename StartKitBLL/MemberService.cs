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
        private IEmailer _emailer;
        private ISMSSender _sender;

        public MemberService(IMemberRepository memberRepository, ISMSSender sender, IUserRepository userRepository, IMapper mapper, IEmailer emailer)
        {
            this._memberRepository = memberRepository;
            _userRepository= userRepository;
            this._mapper = mapper;
            this._emailer = emailer;
            _sender = sender;
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
            if (id>0)
            {
                //update memberId
                member.Id = id;
                member.MemberNo = id.ToString().PadLeft(6, '0'); ;
                _memberRepository.Save(member);
            }
            try
            {
                //check user
                var userCheck=_userRepository.GetByUserName(member.Mobile);
                if (userCheck==null)
                {
                    User user = new User();
                    user.UserName = member.Mobile.ToString();
                    user.Password = member.Mobile.ToString();
                    user.MemberId = id;
                    _userRepository.Save(user);

                    try
                    {
                        var isSend = _sender.Send(member.Mobile, "Your registration sucessfully done. your username:"+member.Mobile+" & password: "+member.Mobile+". Please login for event", "");
                    }
                    catch (Exception ex)
                    {

                    }

                    try
                    {
                        var emal = new Contact();
                        emal.Name = user.UserName;
                        emal.Email = member.Email;
                        emal.Message = "Dear Participant, <br/>\n Your Membership registration sucessfully done. your username:"+member.Mobile+" & password: "+member.Mobile+".<br/><br/> Thanks Organizer team";
                        emal.Subject = "Your Membership registration sucessfully";
                        _emailer.SendEmail(emal);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return id;
        }
    }


}
