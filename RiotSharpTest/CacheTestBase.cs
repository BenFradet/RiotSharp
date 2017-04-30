using System.Configuration;

namespace RiotSharpTest
{
    public class CacheTestBase : CommonTestBase
    {
        public static string TestKey = ConfigurationManager.AppSettings["TestKey"];
        public static string TestValue = ConfigurationManager.AppSettings["TestValue"];
    }
}
