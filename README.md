# investec-api-csharp-sdk
C# wrapper for the Investec Programmable Banking Api.

https://www.offerzen.com/community/investec/

![.NET Core](https://github.com/ihiresolutions/investec-api-csharp-sdk/workflows/.NET%20Core/badge.svg?branch=master)

## Usage
Download the iHire.InvestecApi.SDK from nuget.org. Create an implementation of the IConfiguration interface and pass that in as a parameter to the InvestecSDK.
```
IConfiguration configuration = new MyCustomConfiguration();
var sdk = new InvestecSDK(configuration);
```
You can then access all the available methods. There is currently only one available: GetTransactions(). More will be added as I find a need for them on other projects or if you would like to contribute and add them as well.

Disclaimer: I only created the methods I require at present. This does not cover all the operations available on the API
