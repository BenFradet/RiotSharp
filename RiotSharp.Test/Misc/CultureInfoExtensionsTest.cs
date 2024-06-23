using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.Misc;

namespace RiotSharp.Test.Misc
{
    [TestClass]
    public class CultureInfoExtensionsTest
    {
        private static Dictionary<Language, CultureInfo> supportedNeutralCultureInfos = new Dictionary<Language, CultureInfo>
        {
            { Language.cs_CZ, new CultureInfo("cs") }, { Language.de_DE, new CultureInfo("de") },
            { Language.el_GR, new CultureInfo("el") }, { Language.en_US, new CultureInfo("en") },
            { Language.es_ES, new CultureInfo("es") }, { Language.fr_FR, new CultureInfo("fr") },
            { Language.hu_HU, new CultureInfo("hu") }, { Language.id_ID, new CultureInfo("id") },
            { Language.it_IT, new CultureInfo("it") }, { Language.ja_JP, new CultureInfo("ja") },
            { Language.ko_KR, new CultureInfo("ko") }, { Language.ms_MY, new CultureInfo("ms") },
            { Language.pl_PL, new CultureInfo("pl") }, { Language.pt_BR, new CultureInfo("pt") },
            { Language.ro_RO, new CultureInfo("ro") }, { Language.ru_RU, new CultureInfo("ru") },
            { Language.th_TH, new CultureInfo("th") }, { Language.tr_TR, new CultureInfo("tr") },
            { Language.vn_VN, new CultureInfo("vn") }, { Language.zh_CN, new CultureInfo("zh") },
           
        };
        private static Dictionary<Language, CultureInfo> directlySupportedCultureInfos = new Dictionary<Language, CultureInfo>
        {
            { Language.cs_CZ, new CultureInfo("cs-CZ") }, { Language.de_DE, new CultureInfo("de-DE") },
            { Language.el_GR, new CultureInfo("el-GR") }, { Language.en_AU, new CultureInfo("en-AU") },
            { Language.en_GB, new CultureInfo("en-GB") }, { Language.en_PH, new CultureInfo("en-PH") },
            { Language.en_PL, new CultureInfo("en-PL") }, { Language.en_SG, new CultureInfo("en-SG") },
            { Language.en_US, new CultureInfo("en-US") }, { Language.es_AR, new CultureInfo("es-AR") },
            { Language.es_ES, new CultureInfo("es-ES") }, { Language.es_MX, new CultureInfo("es-MX") },
            { Language.fr_FR, new CultureInfo("fr-FR") }, { Language.hu_HU, new CultureInfo("hu-HU") },
            { Language.id_ID, new CultureInfo("id-ID") }, { Language.it_IT, new CultureInfo("it-IT") },
            { Language.ja_JP, new CultureInfo("ja-JP") }, { Language.ko_KR, new CultureInfo("ko-KR") },
            { Language.ms_MY, new CultureInfo("ms-MY") }, { Language.pl_PL, new CultureInfo("pl-PL") },
            { Language.pt_BR, new CultureInfo("pt-BR") }, { Language.ro_RO, new CultureInfo("ro-RO") },
            { Language.ru_RU, new CultureInfo("ru-RU") }, { Language.th_TH, new CultureInfo("th-TH") },
            { Language.tr_TR, new CultureInfo("tr-TR") }, { Language.vn_VN, new CultureInfo("vn-VN") },
            { Language.zh_CN, new CultureInfo("zh-CN") }, { Language.zh_MY, new CultureInfo("zh-MY") },
            { Language.zh_TW, new CultureInfo("zh-TW") }
        };
        private static CultureInfo unsupportedNeutralCultureInfo = new CultureInfo("et");
        private static CultureInfo unsupportedCultureInfo = new CultureInfo("et-ET");

        [TestMethod]
        public void ToLanguage_SupportedNeutralCultureInfo_ReturnLanguage()
        {
            foreach(var supportedNeutralCulture in supportedNeutralCultureInfos)
            {               
                // Act
                var language = supportedNeutralCulture.Value.ToLanguage();

                // Assert
                Assert.AreEqual(supportedNeutralCulture.Key, language);
            }
        }

        [TestMethod]
        public void ToLanguage_DirectlySupportedCultureInfo_ReturnLanguage()
        {
            foreach (var directlySupportedCulture in directlySupportedCultureInfos)
            {
                // Act
                var language = directlySupportedCulture.Value.ToLanguage();

                // Assert
                Assert.AreEqual(directlySupportedCulture.Key, language);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToLanguage_UnsupportedNeutralCultureInfo_ReturnThrowsArgumentException()
        {
            // Act and Assert - Expects exception
            var language = unsupportedNeutralCultureInfo.ToLanguage();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToLanguage_UnsupportedCultureInfo_ReturnThrowsArgumentExcepion()
        {
            // Act and Assert - Expects exception
            var language = unsupportedNeutralCultureInfo.ToLanguage();
        }
    }
}
