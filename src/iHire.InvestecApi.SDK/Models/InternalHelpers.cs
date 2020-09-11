namespace iHire.InvestecApi.SDK.Models
{
    internal class BaseResponse
    {
        public BaseResponse_Data data { get; set; }
    }

    internal class BaseResponse_Data
    {
        public BaseResponse_Data_TransactionDto[] transactions { get; set; }
    }

    internal class BaseResponse_Data_TransactionDto
    {
        public string type { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string transactionDate { get; set; }
        public decimal amount { get; set; }
    }
}
