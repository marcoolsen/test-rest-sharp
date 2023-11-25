using Microsoft.Extensions.Logging;
using RestSharp;
using test_rest_sharp.Arguments.Holders;
using test_rest_sharp.Arguments.Providers;
using test_rest_sharp.Const;

namespace test_rest_sharp.Tests.Get
{
    public class GetBoardValidationsTest : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BoardIdValidationArgumentsProvider))]
        public async Task CheckGetBoardWithInvalidId(BoardIdValidationArgumentsHolder validationArguments)
        {
            if(_client != null)
            {
                var request = RequestWithAuth(BoardEndpoints.GetBoardUrl, Method.Get)
                    .AddOrUpdateParameters(validationArguments.PathParams);

                var response = await _client.ExecuteAsync(request);
                Assert.That(validationArguments.StatusCode, Is.EqualTo(response.StatusCode));
                Assert.That(validationArguments.ErrorMessage, Is.EqualTo(response.Content));
            }
            else
            {
                Logger.LogWarning("Should check why _client is null");
                throw new InvalidOperationException("Received a _client null");
            }

        }
    }
}
