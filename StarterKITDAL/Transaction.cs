using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL
{
    public class Transaction:BaseEntity
    {
        public Transaction()
        {
            SpouseAmount = 0;
        }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Category { get; set; }
        public decimal MemberAmount { get; set; }
        public int MemberCount { get; set; }
        public int SpouseCount { get; set; }
        public int ChildCount { get; set; }
        public int DriverCount { get; set; }
        public int OtherCount { get; set; }
        public decimal SpouseAmount { get; set; }
        public decimal ChildAmount { get; set; }
        public decimal DriverAmount { get; set; }
        public decimal OtherAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string BkashTransactionId { get; set; }
        public string BkashMobileNo { get; set; }
        public bool IsApproved { get; set; }
        public bool ApprovedBy { get; set; }
    }
}
