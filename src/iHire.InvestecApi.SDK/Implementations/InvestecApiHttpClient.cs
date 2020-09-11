using IdentityModel.Client;
using iHire.InvestecApi.SDK.Contracts;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace iHire.InvestecApi.SDK.Implementations
{
    internal class InvestecHttpClient : HttpClient, IInvestecHttpClient
    {
        #region Constructors

        public InvestecHttpClient(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentException("Configuration cannot be null");
            this.DefaultRequestHeaders.Add("accept", "application/json");
            _configuration = configuration;
            _token = new Token(configuration);
        }

        #endregion

        #region Methods

        public string GetTransactions()
        {
            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token.TokenValue);
            return GetStringAsync(string.Format("{0}/accounts/{1}/transactions", _configuration.BaseUrl, _configuration.AccountNumber)).GetAwaiter().GetResult();
        }

        #endregion

        #region Private Helper Classes

        private class Token
        {
            #region Constructors
            internal Token(IConfiguration configuration)
            {
                _configuration = configuration;
                _tokenString = string.Empty;
                _expiry = DateTime.MinValue;
            }
            #endregion

            #region Properties
            internal string TokenValue 
            {
                get
                {
                    if (string.IsNullOrEmpty(_tokenString) || _expiry.Equals(DateTime.MinValue) || isTokenExpired)
                    {
                        GetAccessToken();
                        return _tokenString;
                    }

                    return _tokenString;
                }
            }

            private bool isTokenExpired
            {
                get
                {
                    if (_expiry.Equals(DateTime.MinValue))
                        return true;

                    return DateTime.Now > _expiry;
                }
            }
            #endregion

            #region Helper Methods

            private void GetAccessToken()
            {
                var client = new HttpClient();

                var response = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = OAUTH_TOKEN_URL,
                    ClientId = _configuration.ClientId,
                    ClientSecret = _configuration.Secret
                }).GetAwaiter().GetResult();

                _tokenString = response.AccessToken;
                _expiry = DateTime.Now.AddSeconds(response.ExpiresIn);
            }

            #endregion

            #region Fields

            private DateTime _expiry;
            private string _tokenString;
            private readonly IConfiguration _configuration;

            #endregion
        }

        #endregion

        #region Fields

        private readonly IConfiguration _configuration;
        private const string OAUTH_TOKEN_URL = "https://openapi.investec.com/identity/v2/oauth2/token";
        private Token _token;

        #endregion
    }
}
