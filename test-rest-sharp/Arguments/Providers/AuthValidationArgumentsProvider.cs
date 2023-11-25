using RestSharp;
using System.Collections;
using test_rest_sharp.Const;
using test_rest_sharp.Arguments.Holders;

namespace test_rest_sharp.Arguments.Providers
{
    public class AuthValidationArgumentsProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new AuthValidationArgumentsHolder()
                {
                    AuthParams = new[]
                    {
                        Parameter.CreateParameter("key", ParamValues.ValidKey, ParameterType.QueryString)
                    },
                    ErrorMessage = "unauthorized permission requested"
                }
            };
            yield return new object[]
            {
                new AuthValidationArgumentsHolder()
                {
                    AuthParams = new[]
                    {
                        Parameter.CreateParameter("token", ParamValues.ValidToken, ParameterType.QueryString)
                    },
                    ErrorMessage = "invalid key"
                }
            };
            yield return new object[]
            {
                new AuthValidationArgumentsHolder()
                {
                    AuthParams = ArraySegment<Parameter>.Empty,
                    ErrorMessage = "invalid key"
                }
            };
        }
    }
}
