using iHire.InvestecApi.SDK.Contracts;
using iHire.InvestecApi.SDK.Implementations;
using iHire.InvestecApi.SDK.Mappers;
using iHire.InvestecApi.SDK.Models;
using Newtonsoft.Json;

namespace iHire.InvestecApi.SDK
{
    public sealed class InvestecSDK
    {
        #region Constructors

        public InvestecSDK(IConfiguration configuration)
        {
            _investecHttpClient = new InvestecHttpClient(configuration);
        }

        public InvestecSDK(IInvestecHttpClient investecHttpClient)
        {
            _investecHttpClient = investecHttpClient;
        }

        #endregion

        #region Public Methods

        public TransactionDto[] GetTransactions()
        {
            var httpResponse = _investecHttpClient.GetTransactions();
            if (string.IsNullOrEmpty(httpResponse))
                return new TransactionDto[0];

            var response = JsonConvert.DeserializeObject<BaseResponse>(httpResponse);
            if (response == null || response.data == null || response.data.transactions == null)
                return new TransactionDto[0];

            var transactions = response.data.transactions;
            return transactions.Map();
        }

        #endregion

        #region Fields

        private readonly IInvestecHttpClient _investecHttpClient;

        #endregion
    }
}
