using Microsoft.Extensions.Logging;
using NUnit.Framework;
using RestSharp;
using test_rest_sharp.Const;
using test_rest_sharp.Helpers;

namespace test_rest_sharp.Tests
{
    public class BaseTest
    {
        protected static IRestClient? _client;
        protected static readonly ILogger<BaseTest> Logger = LoggingConfig.CreateLogger<BaseTest>();

        [OneTimeSetUp]
        public static void InitializeRestClient() => _client = new RestClient("https://api.trello.com");

        protected RestRequest RequestWithAuth(string url, Method method) => RequestWithoutAuth(url, method).AddOrUpdateParameters(ParamValues.AuthQueryParams);

        protected RestRequest RequestWithoutAuth(string url, Method method) => new RestRequest(url, method);

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _client?.Dispose();
        }

    }
}
