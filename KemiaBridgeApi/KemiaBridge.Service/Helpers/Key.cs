using DotNetEnv;

namespace KemiaBridge.Service.Helpers
{
    public class Key
    {
        public static string Secret()
        {
            //Env.Load();
            //return Environment.GetEnvironmentVariable("SECRET_KEY_JWT")!;
            return "1ab4956d08996a20712a65839f1f239caf00909001b15474430faf39cbb00a27";
        }
    }
}
