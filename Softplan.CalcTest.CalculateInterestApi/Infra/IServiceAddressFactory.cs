using System;
using System.ComponentModel;

namespace Softplan.CalcTest.CalculateInterestApi.Infra
{
    /// <summary>
    /// TODO: já sabe né
    /// </summary>
    public interface IServiceAddressFactory
    {
        /// <summary>
        /// TODO:
        /// </summary>
        /// <returns></returns>
        Uri Build(ConsumedServicesEnum service);
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ConsumedServicesEnum
    {
        /// <summary>
        /// Variável de ambiente que representa o endereço da api de taxa de juros.
        /// </summary>
        [Description("INTEREST_RATE_API_BASE_ADDRESS")]
        InterestRateApi
    }
}