using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Polly;
using Softplan.CalcTest.CalculateInterestApi.Domain;

namespace Softplan.CalcTest.CalculateInterestApi.Infra
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpInterestRateRepository : IHttpInterestRateRepository
    {
        // _httpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly ILogger<HttpInterestRateRepository> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="addressFactory"></param>
        public HttpInterestRateRepository(IServiceAddressFactory addressFactory, ILogger<HttpInterestRateRepository> logger)
        {
            _logger = logger;
            _httpClient.BaseAddress = addressFactory.Build(ConsumedServicesEnum.InterestRateApi);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<InterestRate> FetchCurrentInterestRate()
        {

            var response = await Policy
                .Handle<Exception>()
                .OrResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(2), (result, timeSpan, retryCount, context) =>
                {
                    _logger.LogWarning($"Request failed with {result.Result?.StatusCode}. Waiting {timeSpan} before next retry. Retry attempt {retryCount}");
                })
                .ExecuteAsync(() => _httpClient.GetAsync("/taxajuros"));


            _logger.LogInformation("Response was successful.");
            var content = await response.Content.ReadAsStringAsync();

            if (decimal.TryParse(content, out var value))
            {
                return new InterestRate(value);
            }

            _logger.LogError($"Response failed. Status code {response.StatusCode}");

            throw new ArgumentValueException(content, $"A api retornou um valor incomum que não pode ser convertido em decimal {content}.");
        }
    }
}
