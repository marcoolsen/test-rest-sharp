using RestSharp;

namespace test_rest_sharp.Arguments.Holders
{
    public class AuthValidationArgumentsHolder
    {
        public IEnumerable<Parameter>? AuthParams { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
