using DotNetEnv;

namespace KemiaBridge.Service.Helpers
{
    public class Key
    {
        public static string Secret()
        {
            Env.Load();
            return Environment.GetEnvironmentVariable("SECRET_KEY_JWT")!;
        }
    }
}
