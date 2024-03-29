﻿using StarterKITDAL;
using StarterKITDAL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace StartKitBLL
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository;
        private IMemberRepository _memberRepository;
        private IEmailer _emailer;
        private ISMSSender _sender;
        public TransactionService(ITransactionRepository transactionRepository, IEmailer emailer, ISMSSender sender, IMemberRepository memberRepository)
        {
            this._transactionRepository = transactionRepository;
            _memberRepository = memberRepository;
            _emailer = emailer;
            _sender = sender;
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
                    var isSend = _sender.Send(transaction.Mobile, "Your Event registration is pending for approval.  - cupaesfd.org", "");
                }
                catch (Exception ex)
                {

                }

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
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public int DeApprove(Transaction transaction)
        {
            transaction.IsApproved = false;
            var result = _transactionRepository.Save(transaction);
            var member = _memberRepository.GetById(transaction.MemberId);
            if (result != -1)
            {
                try
                {
                    var isSend = _sender.Send(member.Mobile, "Your Event registration De-approved. Please do it again","");
                }
                catch (Exception ex)
                {

                }
                try
                {
                    var emal = new Contact();
                    emal.Name = transaction.Name;
                    emal.Email = member.Email;
                    emal.Message = "Dear Participant, <br/>\n Your Event registration de-approved <br/>Please do it again<br/> \r\n Thanks for joining.<br/><br/> Thanks Organizer team";
                    emal.Subject = "Your Event registration DeApproved";
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
                    emal.Message = "Dear Admin, <br/>\n A Event registration transaction has been de-activated Member:" + member.Name + " <br/> Mobile: " + member.Mobile + ".<br/><br/> Thanks Organizer team";
                    emal.Subject = "Your Event registration DeApproved";
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
                   var isSend= _sender.Send(member.Mobile, "Your Event registration approved. Please click https://alumnibackend.rexsystemsbd.com/api/Download/Download?memberId="+transaction.MemberId+"&transactionNo="+transaction.BkashTransactionId+".", "");
                }
                catch (Exception ex)
                {

                }
                try
                {
                    var emal = new Contact();
                    emal.Name = transaction.Name;
                    emal.Email = member.Email;
                    emal.Message = "Dear Participant, <br/>\n Your Event registration sucessfully Verified. <br/>Please download your verified token from the below link<br/>" +
                        "<div class=\"button\"><a href=\"https://alumnibackend.rexsystemsbd.com/api/Download/Download?memberId="+transaction.MemberId+"&transactionNo="+transaction.BkashTransactionId+"\r\n\">Please download from here</a></div> \r\n Thanks for joining.<br/><br/> Thanks Organizer team";
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

        public DataTable GetByMobileAndTransactionNo(int memberId, string transactionNo)
        {
           return _transactionRepository.GetByMobileAndTransactionNo(memberId, transactionNo);
        }
    }

    public interface ITransactionService
    {
        ICollection<Transaction> GetAll(int eventId);
        Transaction GetByTransactionId(string transactionId);
        List<Transaction> GetByMobile(string mobile, int eventId);
        int Save(Transaction transaction);
        int Approve(Transaction transaction);
        DataTable GetByMobileAndTransactionNo(int memberId, string transactionNo);
    }
}
