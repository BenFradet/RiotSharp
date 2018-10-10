using System;
using System.Globalization;

namespace RiotSharp.Misc
{
    /// <summary>
    /// Extensions to use on <see cref="CultureInfo"/>
    /// </summary>
    public static class CultureInfoExtensions
    {
        /// <summary>
        /// Converts the value of this instance to its equivalent Language representation.
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <returns>The Language representation of the value of this instance.</returns>
        /// <exception cref="ArgumentException">Thrown if an unsupported CultureInfo is provided.</exception>
        public static Language ToLanguage(this CultureInfo cultureInfo)
        {
            // Neutral cultures don't have an equivalent in Riot's API, therefore they need to be mapped to a default
            if (cultureInfo.IsNeutralCulture) 
            {
                return ParseNeutralCulture(cultureInfo);
            }
            else
            {
                var riotLanguageName = cultureInfo.Name.Replace('-', '_');
                return Enum.TryParse(riotLanguageName, out Language language) ? language : ParseNeutralCulture(cultureInfo.Parent);
            }
        }

        private static Language ParseNeutralCulture(CultureInfo cultureInfo)
        {
            switch (cultureInfo.TwoLetterISOLanguageName)
            {
                case "cs":
                    return Language.cs_CZ;
                case "de":
                    return Language.de_DE;
                case "el":
                    return Language.el_GR;
                case "en":
                    return Language.en_US;                
                case "es":
                    return Language.es_ES;
                case "fr":
                    return Language.fr_FR;
                case "hu":
                    return Language.hu_HU;
                case "id":
                    return Language.id_ID;
                case "it":
                    return Language.it_IT;
                case "ja":
                    return Language.ja_JP;
                case "ko":
                    return Language.ko_KR;
                case "ms":
                    return Language.ms_MY;
                case "pl":
                    return Language.pl_PL;
                case "pt":
                    return Language.pt_BR;
                case "ro":
                    return Language.ro_RO;
                case "ru":
                    return Language.ru_RU;
                case "th":
                    return Language.th_TH;
                case "tr":
                    return Language.tr_TR;
                case "vn":
                    return Language.vn_VN;
                case "zh":
                    return Language.zh_CN;
                default:
                    throw new ArgumentException("Unsupported language: " + cultureInfo.Name);
            }
        }
    }
}
