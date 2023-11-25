using RestSharp;

namespace test_rest_sharp.Const
{
    public class ParamValues
    {
        public const string ValidKey = "75ff389062e1e2adb732efffbcd79c84";
        public const string ValidToken = "ATTA126b498ccd7a788df923443e6878c665ac0704753460de83ce61fa6e9c8701efC39550E5";
        public const string telloUserName = "marcoolsen10";
        public const string ExistingBoardId = "61140e607c7995335b41a68a";
        public const string ExistingBoardName = "Bretes";

        public static readonly IEnumerable<Parameter> AuthQueryParams = new[]
        {
            Parameter.CreateParameter("key", ValidKey, ParameterType.QueryString),
            Parameter.CreateParameter("token", ValidToken, ParameterType.QueryString),
        };
    }
}
