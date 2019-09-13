using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Polly;
using Softplan.CalcTest.CalculateInterestApi.Domain;

namespace Softplan.CalcTest.CalculateInterestApi.Infra
{
    /// <inheritdoc />
    public class InterestRateRepository : IInterestRateRepository
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly ILogger<InterestRateRepository> _logger;

        /// <summary>
        /// Inicializa uma instância de InterestRateRepository.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="addressFactory"></param>
        public InterestRateRepository(IServiceAddressFactory addressFactory, ILogger<InterestRateRepository> logger)
        {
            _logger = logger;
            _httpClient.BaseAddress = addressFactory.Build(ConsumedServicesEnum.InterestRateApi);
        }


        /// <inheritdoc />
        public async Task<InterestRate> FetchCurrentInterestRate()
        {

            // Implementando resiliência na aplicação utilizando retry pattern com Polly.
            var response = await Policy
                .Handle<Exception>()
                .OrResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(2), (result, timeSpan, retryCount, context) =>
                {
                    _logger.LogWarning($"Request falhou e retornou o código: {result.Result?.StatusCode}. Aguardando {timeSpan} antes da próxima tentativa. Numero da tentativa: {retryCount}");
                })
                .ExecuteAsync(() => _httpClient.GetAsync("/taxajuros"));


            _logger.LogInformation("Response was successful.");
            var content = await response.Content.ReadAsStringAsync();


            try
            {
                var value = Convert.ToDecimal(content, new CultureInfo("pt-BR"));

                return new InterestRate(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter resposta do serviço. Código do status: {response.StatusCode}");

                throw new ArgumentValueException(content, $"A api retornou um valor incomum que não pode ser convertido em decimal {content}.", ex);
            }
        }
    }
}
