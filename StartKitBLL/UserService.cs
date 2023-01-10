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
    public class UserService:IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }
        public User Login(User user)
        {
            var userObj = _userRepository.Login(user);
            return userObj;
        }

        public User Signup(User user)
        {
            var checkUser=_userRepository.GetByUserName(user.UserName);
            if (checkUser == null)
            {
                _userRepository.Save(user);
            }
            else
            {
                throw new Exception("User already available");
            }
            return user;
        }
    }

    public interface IUserService
    {
        User Login(User user);
        User Signup(User user);

    }
}
