using iHire.InvestecApi.SDK.Contracts;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace iHire.InvestecApi.SDK.Tests
{
    public class GetTransactionsTests
    {
        #region Constructors

        public GetTransactionsTests()
        {
            _investecSdk = new InvestecSDK(_investecHttpClient.Object);
        }

        #endregion

        #region Test Methods

        [Fact]
        public void GetTransactions_Success()
        {
            // ARRANGE
            var mockResponseObject = new BaseResponse
            {
                data = new BaseResponse_Data
                {
                    transactions = new List<BaseResponse_Data_TransactionDto>()
                    {
                        new BaseResponse_Data_TransactionDto
                        {
                            type = "CREDIT",
                            status = "POSTED",
                            description = "IHIRE SOLUTIONS",
                            transactionDate = "2020-09-03",
                            amount = 600M
                        },
                        new BaseResponse_Data_TransactionDto
                        {
                            type = "CREDIT",
                            status = "POSTED",
                            description = "IHIRE SOLUTIONS",
                            transactionDate = "2020-09-10",
                            amount = 600M
                        }
                    }.ToArray()
                }
            };

            

            string mockResponseString = JsonConvert.SerializeObject(mockResponseObject);
            _investecHttpClient.Setup(x => x.GetTransactions()).Returns(mockResponseString);

            // ACT
            var result = _investecSdk.GetTransactions();

            // ASSERT
            Assert.NotNull(result);
            Assert.True(result.Any());
        }

        #endregion

        #region Fields

        private readonly InvestecSDK _investecSdk;
        private readonly Mock<IInvestecHttpClient> _investecHttpClient = new Mock<IInvestecHttpClient>();
        private readonly IConfiguration _configuration = new TestConfiguration();

        #endregion

        #region Helper Classes

        private class TestConfiguration : IConfiguration
        {
            public string ClientId => "test";

            public string Secret => "test";

            public string AccountNumber => "test";

            public string BaseUrl => "test";
        }

        private class BaseResponse
        {
            public BaseResponse_Data data { get; set; }
        }

        private class BaseResponse_Data
        {
            public BaseResponse_Data_TransactionDto[] transactions { get; set; }
        }

        private class BaseResponse_Data_TransactionDto
        {
            public string type { get; set; }
            public string status { get; set; }
            public string description { get; set; }
            public string transactionDate { get; set; }
            public decimal amount { get; set; }
        }

        #endregion
    }
}
