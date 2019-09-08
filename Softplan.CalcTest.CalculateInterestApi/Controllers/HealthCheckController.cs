using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Softplan.CalcTest.CalculateInterestApi.Infra;

namespace Softplan.CalcTest.CalculateInterestApi.Controllers
{
    public class HealthCheckController : IHealthCheck
    {
        private readonly IServiceAddressFactory _serviceAddressFactory;

        public HealthCheckController(IServiceAddressFactory serviceAddressFactory)
        {
            _serviceAddressFactory = serviceAddressFactory;
        }

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
                        throw new Exception("Url not responding with 200 OK");
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
