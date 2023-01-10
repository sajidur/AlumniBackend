using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL.Repository
{
    public class UserRepository:IUserRepository
    {
        ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public User GetByUserName(string userName)
        {
            return _context.Users.Where(a => a.UserName == userName).FirstOrDefault();
        }

        public User Login(User user)
        {
            return _context.Users.Where(a => a.UserName == user.UserName&&a.Password==user.Password).FirstOrDefault();
        }
        public int Save(User user)
        {
            if (user.Id > 0)
            {
                _context.Users.Attach(user);
                _context.Entry(user).State = EntityState.Modified;
            }
            else
            {
                _context.Users.Add(user);
            }
            _context.SaveChanges();
            return user.Id;
        }

    }
}
