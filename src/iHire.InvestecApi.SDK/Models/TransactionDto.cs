using iHire.InvestecApi.SDK.Enumerations;
using System;

namespace iHire.InvestecApi.SDK.Models
{
    public class TransactionDto
    {
        public TransactionType TransactionType { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
    }
}
