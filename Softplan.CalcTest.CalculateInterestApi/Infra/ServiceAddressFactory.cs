using System;

namespace Softplan.CalcTest.CalculateInterestApi.Infra
{
    /// <inheritdoc />
    public class ServiceAddressFactory : IServiceAddressFactory
    {
        /// <inheritdoc />
        public Uri Build(ConsumedServicesEnum service)
        {
            Uri uri;
            switch (service)
            {
                case ConsumedServicesEnum.InterestRateApi:
                    var address = Environment.GetEnvironmentVariable(service.GetDescription());
                    uri = new Uri(address);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(service), service, null);
            }

            return uri;
        }
    }
}