using StarterKITDAL;
using StarterKITDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartKitBLL
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository;
        private IMemberRepository _memberRepository;
        private IEmailer _emailer;
        public TransactionService(ITransactionRepository transactionRepository, IEmailer emailer, IMemberRepository memberRepository)
        {
            this._transactionRepository = transactionRepository;
            _memberRepository = memberRepository;
            _emailer = emailer;
        }
        public ICollection<Transaction> GetAll(int eventId)
        {
           return _transactionRepository.GetAll(eventId);
        }

        public List<Transaction> GetByMobile(string mobile, int eventId)
        {
            return _transactionRepository.GetByMobile(mobile,eventId);
        }

        public Transaction GetByTransactionId(string transactionId)
        {
            return _transactionRepository.GetByTransactionId(transactionId);
        }

        public int Save(Transaction transaction)
        {
            transaction.IsApproved = false;
            var result=_transactionRepository.Save(transaction);
            if (result != -1)
            {
                try
                {
                    var emal = new Contact();
                    emal.Name = transaction.Name;
                    emal.Message = "Dear Participant, <br/>\n Your Event registration sucessfully done. Please wait we will confirm you soon.<br/> Thanks Organizer team";
                    emal.Subject = "Your Event registration sucessfully";
                    _emailer.SendEmail(emal);
                }
                catch (Exception ex)
                {

                }
            }
            return result;

        }
        public int Approve(Transaction transaction)
        {
            transaction.IsApproved = true;
            var result= _transactionRepository.Save(transaction);
            var member=_memberRepository.GetById(transaction.MemberId);
            if (result != -1)
            {
                try
                {
                    var emal = new Contact();
                    emal.Name = transaction.Name;
                    emal.Email = member.Email;
                    emal.Message = "Dear Participant, <br/>\n Your Event registration sucessfully Verified. Thanks for joining.<br/><br/> Thanks Organizer team";
                    emal.Subject = "Your Event registration Approved";
                    _emailer.SendEmail(emal);
                }
                catch (Exception ex)
                {

                }
                // admin
                try
                {
                    var emal = new Contact();
                    emal.Name = transaction.Name;
                    emal.Email = "nafsobhan@gmail.com";
                    emal.Message = "Dear Admin, <br/>\n A Event registration transaction has been validated Member:"+member.Name+" <br/> Mobile: "+member.Mobile+".<br/><br/> Thanks Organizer team";
                    emal.Subject = "Your Event registration Approved";
                    _emailer.SendEmail(emal);
                }
                catch (Exception ex)
                {

                }
            }
            return result;

        }
    }

    public interface ITransactionService
    {
        ICollection<Transaction> GetAll(int eventId);
        Transaction GetByTransactionId(string transactionId);
        List<Transaction> GetByMobile(string mobile, int eventId);
        int Save(Transaction transaction);
        int Approve(Transaction transaction);
    }
}
