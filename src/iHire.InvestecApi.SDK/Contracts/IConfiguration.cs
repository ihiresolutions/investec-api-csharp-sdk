namespace iHire.InvestecApi.SDK.Contracts
{
    public interface IConfiguration
    {
        string ClientId { get; }
        string Secret { get; }
        string AccountNumber { get; }
        string BaseUrl { get; }
    }
}
