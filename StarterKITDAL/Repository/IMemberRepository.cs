using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL.Repository
{
    public interface IMemberRepository
    {
        int Save(Member member);
        List<Member> GetList();
        Member GetById(int id);
        int Delete(int id);
    }

    public class MemberRepository : IMemberRepository
    {
        ApplicationDbContext _context;
        public MemberRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public int Delete(int id)
        {
            var data = _context.Members.Where(a => a.Id == id).FirstOrDefault();
            _context.Members.Remove(data);
            return _context.SaveChanges();
        }

        public Member GetById(int id)
        {
            return _context.Members.Find(id);
        }

        public List<Member> GetList()
        {
           return _context.Members.ToList();
        }

        public int Save(Member member)
        {
            if (member.Id > 0)
            {
                _context.Members.Attach(member);
                _context.Entry(member).State = EntityState.Modified;
            }
            else
            {
                _context.Members.Add(member);
            }
            _context.SaveChanges();
            return member.Id;
        }
    }
}
