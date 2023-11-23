using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using System.Net;
using test_rest_sharp.Const;

namespace test_rest_sharp.Tests.Get
{
    public class GetBoardTest : BaseTest
    {
        [Test]
        public async Task CheckGetBoards()
        {
            var request = RequestWithAuth(BoardEndpoints.GetAllBoardsUrl, Method.Get)
            //    .AddQueryParameter("field", "id,name")
                .AddUrlSegment("member", ParamValues.telloUserName);
                            
            if (_client != null)
            {
                var response = await _client.ExecuteAsync(request);

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                var responseContent = JToken.Parse(response.Content);
                var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_boards.json"));
                Assert.That(responseContent.IsValid(jsonSchema), Is.True);

            }
        }
    }
}
