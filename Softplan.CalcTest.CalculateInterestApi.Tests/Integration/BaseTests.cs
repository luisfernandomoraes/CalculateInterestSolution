using Microsoft.AspNetCore.Http;

namespace Softplan.CalcTest.CalculateInterestApi.Tests.Integration
{
    public class BaseTests
    {
        public string CreateQueryString(string presentValue, string periods)
        {
            QueryString query = new QueryString();

            if (presentValue != null)
            {
                query = query.Add("valorinicial", presentValue);
            }

            if (periods != null)
            {
                query = query.Add("meses", periods);
            }

            return query.ToUriComponent();
        }
    }
}