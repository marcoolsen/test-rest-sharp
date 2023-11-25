using RestSharp;
using System.Net;

namespace test_rest_sharp.Arguments.Holders
{
    public class BoardIdValidationArgumentsHolder
    {
        public IEnumerable<Parameter>? PathParams { get; set; }
        public string? ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
