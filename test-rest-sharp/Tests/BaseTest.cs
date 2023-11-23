using NUnit.Framework;
using RestSharp;
using test_rest_sharp.Const;

namespace test_rest_sharp.Tests
{
    public class BaseTest
    {
        protected static IRestClient? _client;

        [OneTimeSetUp]
        public static void InitializeRestClient() => _client = new RestClient("https://api.trello.com");

        protected RestRequest RequestWithAuth(string url, Method method) => RequestWithoutAuth(url, method).AddOrUpdateParameters(ParamValues.AuthQueryParams);

        protected RestRequest RequestWithoutAuth(string url, Method method) => new RestRequest(url, method);

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Dispose of the _client instance directly
            _client.Dispose();
        }

    }
}
