using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotSharp;

namespace RiotSharpTest
{
    [TestClass]
    public class CultureInfoExtensionsTest
    {
        private static List<CultureInfo> supportedNeutralCultureInfos = new List<CultureInfo>
        {
            new CultureInfo("cs"), new CultureInfo("de"), new CultureInfo("el"), new CultureInfo("en"),
            new CultureInfo("es"), new CultureInfo("fr"), new CultureInfo("hu"), new CultureInfo("id"),
            new CultureInfo("it"), new CultureInfo("ja"), new CultureInfo("ko"), new CultureInfo("ms"), 
            new CultureInfo("pl"), new CultureInfo("pt"), new CultureInfo("ro"), new CultureInfo("ru"), 
            new CultureInfo("th"), new CultureInfo("tr"), new CultureInfo("vn"), new CultureInfo("zh") 
        };
        private static List<CultureInfo> directlySupportedCultureInfos = new List<CultureInfo>
        {
            new CultureInfo("cs-CZ"), new CultureInfo("de-DE"), new CultureInfo("el-GR"), new CultureInfo("en-AU"),
            new CultureInfo("en-GB"), new CultureInfo("en-PH"), new CultureInfo("en-PL"), new CultureInfo("en-SG"),
            new CultureInfo("en-US"), new CultureInfo("es-AR"), new CultureInfo("es-ES"), new CultureInfo("es-MX"),
            new CultureInfo("fr-FR"), new CultureInfo("hu-HU"), new CultureInfo("id-ID"), new CultureInfo("it-IT"),
            new CultureInfo("ja-JP"), new CultureInfo("ko-KR"), new CultureInfo("ms-MY"), new CultureInfo("pl-PL"),
            new CultureInfo("pt-BR"), new CultureInfo("ro-RO"), new CultureInfo("ru-RU"), new CultureInfo("th-TH"),
            new CultureInfo("tr-TR"), new CultureInfo("vn-VN"), new CultureInfo("zh-CN"), new CultureInfo("zh-MY"),
            new CultureInfo("zh-TW")
        };
        private static CultureInfo unsupportedNeutralCultureInfo = new CultureInfo("et");
        private static CultureInfo unsupportedCultureInfo = new CultureInfo("et-ET");

        [TestMethod]
        public void ToLanguage_SupportedNeutralCultureInfo_ReturnsLanguage()
        {
            foreach(var neutralCulture in supportedNeutralCultureInfos)
            {               
                try
                {
                    // Act
                    var language = neutralCulture.ToLanguage();
                }
                catch
                {
                    // Assert
                    Assert.Fail("Conversion of " + neutralCulture.Name + " failed.");
                }
            }
        }

        [TestMethod]
        public void ToLanguage_DirectlySupportedCultureInfo_ReturnsLanguage()
        {
            foreach (var directlySupportedCulture in directlySupportedCultureInfos)
            {
                try
                {
                    // Act
                    var language = directlySupportedCulture.ToLanguage();
                }
                catch
                {
                    // Assert
                    Assert.Fail("Conversion of " + directlySupportedCulture.Name + " failed.");
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToLanguage_UnsupportedNeutralCultureInfo_ThrowsArgumentException()
        {
            // Act and Assert - Expects exception
            var language = unsupportedNeutralCultureInfo.ToLanguage();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToLanguage_UnsupportedCultureInfo_ThrowsArgumentExcepion()
        {
            // Act and Assert - Expects exception
            var language = unsupportedNeutralCultureInfo.ToLanguage();
        }
    }
}
