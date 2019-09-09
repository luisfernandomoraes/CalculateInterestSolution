using System;
using System.ComponentModel;

namespace Softplan.CalcTest.CalculateInterestApi.Infra
{
    /// <summary>
    /// Factory para retornar um objeto System.Uri contendo o endereço base do serviço requisitado.
    /// </summary>
    public interface IServiceAddressFactory
    {
        /// <summary>
        /// Constrói um objeto System.Uri com o endereço do serviço requisitado.:
        /// </summary>
        /// <returns></returns>
        Uri Build(ConsumedServicesEnum service);
    }

    /// <summary>
    /// Enumeração dos serviços consumidos pela aplicação.
    /// Sua descrição representa a variável de ambiente correspondente.
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