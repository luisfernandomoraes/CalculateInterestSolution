using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Softplan.CalcTest.CalculateInterestApi.Infra;

namespace Softplan.CalcTest.CalculateInterestApi.Controllers
{
    /// <summary>
    /// Controller de healthcheck
    /// </summary>
    public class HealthCheckController : IHealthCheck
    {
        private readonly IServiceAddressFactory _serviceAddressFactory;
        private readonly ILogger<HealthCheckController> _logger;

        /// <summary>
        /// Inicializa uma instância da classe HealthCheckController.
        /// </summary>
        /// <param name="serviceAddressFactory"></param>
        public HealthCheckController(IServiceAddressFactory serviceAddressFactory, ILogger<HealthCheckController> logger)
        {
            _serviceAddressFactory = serviceAddressFactory;
            _logger = logger;
        }

        /// <summary>
        /// Realiza a verificação da disponibilidade das dependências de outros microserviço (http).
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var serviceAddress = _serviceAddressFactory.Build(ConsumedServicesEnum.InterestRateApi);
                    client.BaseAddress = serviceAddress;

                    var response = await client.GetAsync("/healthcheck", cancellationToken);
                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError($"Url do microserviço {ConsumedServicesEnum.InterestRateApi} não respondeu com status 200 OK");

                        throw new Exception($"Url do microsserviço {ConsumedServicesEnum.InterestRateApi} não respondeu com status 200 OK");
                    }
                }
                catch (Exception)
                {
                    return await Task.FromResult(HealthCheckResult.Unhealthy());
                }
            }
            return await Task.FromResult(HealthCheckResult.Healthy());
        }
    }
}
