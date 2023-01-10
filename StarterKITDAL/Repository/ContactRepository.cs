using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL.Repository
{
    public class ContactRepository : IContactRepository
    {
        ApplicationDbContext _context;
        public ContactRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public ICollection<Contact> GetAll(int isResponse)
        {
            return _context.Contacts.Where(a => a.IsResponse == isResponse).ToList();
        }

        public int Save(Contact salaryItem)
        {
            _context.Contacts.Add(salaryItem);
           return _context.SaveChanges();
        }
    }
}
