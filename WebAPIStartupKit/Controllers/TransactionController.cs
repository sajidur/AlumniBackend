
using StarterKITDAL;
using StartKitBLL;
using StartKitBLL.Response;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPIStartupKit.Controllers
{
    [RoutePrefix("api/Transaction")]
    public class TransactionController : ApiController
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public List<Transaction> GetAll(int eventId)
        {
            return _transactionService.GetAll(eventId).ToList();
        }


        [HttpGet]
        [Route("GetByMobile")]
        public List<Transaction> GetByMobile(string mobile, int eventId)
        {
            return _transactionService.GetByMobile(mobile, eventId);
        }

        [HttpGet]
        [Route("GetByTransactionId")]
        public Transaction GetByTransactionId(string transactionId)
        {
            return _transactionService.GetByTransactionId(transactionId);
        }

        [HttpPost]
        [Route("Save")]
        public int Save(Transaction transaction)
        {
            var i=_transactionService.Save(transaction);
            return i;
        }

        [HttpPost]
        [Route("Approve")]
        public int Approve(string transactionId)
        {
            var i = _transactionService.GetByTransactionId(transactionId);
            if (i==null)
            {
                throw new System.Exception("Transaction not found!!");
            }
            return _transactionService.Approve(i);
         }

    }
}
