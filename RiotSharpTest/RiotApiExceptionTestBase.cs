using RiotSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharpTest
{
    public class RiotApiExceptionTestBase : CommonTestBase
    {
        public static string faultyApiKey = ConfigurationManager.AppSettings["FaultyApiKey"];
        public static Region region = (Region)Enum.Parse(typeof(Region), ConfigurationManager.AppSettings["Region"]);
    }
}
