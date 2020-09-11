using iHire.InvestecApi.SDK.Enumerations;
using iHire.InvestecApi.SDK.Models;
using System;
using System.Linq;

namespace iHire.InvestecApi.SDK.Mappers
{
    internal static class TransactionMappers
    {
        internal static TransactionDto[] Map(this BaseResponse_Data_TransactionDto[] integrationDtos)
        {
            return integrationDtos == null 
                ? new TransactionDto[0] 
                : integrationDtos.Select(t => t.Map()).ToArray();
        }

        internal static TransactionDto Map(this BaseResponse_Data_TransactionDto integrationDto)
        {
            return integrationDto == null
                ? null
                : new TransactionDto
                {
                    TransactionType = MapType(integrationDto.type),
                    Status = integrationDto.status,
                    Description = integrationDto.description,
                    TransactionDate = DateTime.Parse(integrationDto.transactionDate),
                    Amount = integrationDto.amount,
                    Currency = Enumerations.Currency.ZAR
                };
        }

        internal static TransactionType MapType(string integrationDtoType)
        {
            switch (integrationDtoType)
            {
                case "CREDIT":
                    return TransactionType.CREDIT;
                case "DEBIT":
                    return TransactionType.DEBIT;
                default:
                    return TransactionType.None;
            }
        }
    }
}
