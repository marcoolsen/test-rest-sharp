using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework.Internal;
using RestSharp;
using System.Net;
using test_rest_sharp.Const;
using Microsoft.Extensions.Logging;

namespace test_rest_sharp.Tests.Get
{
    public class GetBoardTest : BaseTest
    {
        [Test]
        public async Task CheckGetBoards()
        {
            var request = RequestWithAuth(BoardEndpoints.GetAllBoardsUrl, Method.Get)
                .AddUrlSegment("member", ParamValues.telloUserName);

            if (_client != null)
            {
                var response = await _client.ExecuteAsync(request);
                if (response.Content != null)
                {
                    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                    var responseContent = JToken.Parse(response.Content);
                    var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_boards.json"));
                    Assert.That(responseContent.IsValid(jsonSchema), Is.True);
                }
                else
                {
                    Logger.LogWarning("Should check why the api response or response.Content is null");
                    throw new InvalidOperationException("Received a response or response.Content null.");
                }
            }
            else
            {
                Logger.LogWarning("Should check why _client is null");
                throw new InvalidOperationException("Received a _client null");
            }
        }

        [Test]
        public async Task CheckGetBoard()
        {
            var request = RequestWithAuth(BoardEndpoints.GetBoardUrl, Method.Get)
                .AddQueryParameter("field", "id,name")
                .AddUrlSegment("id", ParamValues.ExistingBoardId);
            if (_client != null)
            {
                var response = await _client.ExecuteAsync(request);
                if (response != null && response.Content != null)
                {
                    var responseContent = JToken.Parse(response.Content);
                    var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_board.json"));
                    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                    Assert.That(responseContent.IsValid(jsonSchema));

                    var nameToken = responseContent.SelectToken("name");
                    Assert.That(nameToken?.ToString(), Is.EqualTo(ParamValues.ExistingBoardName));
                }
                else
                {
                    Logger.LogWarning("Should check why the api response or response.Content is null");
                    throw new InvalidOperationException("Received a response or response.Content null.");
                }
            }
            else
            {
                Logger.LogWarning("Should check why _client is null");
                throw new InvalidOperationException("Received a _client null");
            }
        }
    }
}
