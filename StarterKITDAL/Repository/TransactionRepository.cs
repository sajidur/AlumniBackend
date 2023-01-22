using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL.Repository
{
    public interface ITransactionRepository
    {
        ICollection<Transaction> GetAll(int eventId);
        Transaction GetByTransactionId(string transactionId);
        List<Transaction> GetByMobile(string mobile, int eventId);
        int Save(Transaction transaction);
    }
    public class TransactionRepository : ITransactionRepository
    {
        ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public ICollection<Transaction> GetAll(int eventId)
        {
            return _context.Transactions.Where(a=>a.EventId==eventId).ToList();
        }

        public Transaction GetByTransactionId(string transactionId)
        {
            return _context.Transactions.Where(a => a.BkashTransactionId == transactionId).FirstOrDefault();
        }
        public List<Transaction> GetByMobile(string mobile,int eventId)
        {
            return _context.Transactions.Where(a => a.Mobile ==mobile && a.EventId==eventId).ToList();
        }

        public int Save(Transaction transaction)
        {
            if (transaction.Id >0)
            {
                _context.Transactions.Attach(transaction);
                _context.Entry(transaction).State = EntityState.Modified;
                return _context.SaveChanges();
            }
            else {
                _context.Transactions.Add(transaction);
                return _context.SaveChanges();
            }

        }
        public int Update(Transaction transaction)
        {
            if (transaction.Id > 0)
            {
                _context.Transactions.Attach(transaction);
                _context.Entry(transaction).State = EntityState.Modified;
            }
            else
            {
                return 0;
            }
            return _context.SaveChanges();
        }
    }
}
