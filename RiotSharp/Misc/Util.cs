using System;
using System.Collections.Generic;
using System.Linq;
using RiotSharp.Endpoints.MatchEndpoint.Enums;

namespace RiotSharp.Misc
{
    internal static class Util
    {

        public static DateTime BaseDateTime = new DateTime(1970, 1, 1);

        public static DateTime ToDateTimeFromMilliSeconds(this long millis)
        {
            return BaseDateTime.AddMilliseconds(millis);
        }

        public static long ToLong(this DateTime dateTime)
        {
            var span = dateTime - BaseDateTime;
            return (long)span.TotalMilliseconds;
        }

        public static string BuildIdsString(List<int> ids)
        {
            return string.Join(",", ids);
        }

        public static string BuildIdsString(List<long> ids)
        {
            return string.Join(",", ids);
        }

        public static string BuildNamesString(List<string> names)
        {
            return string.Join(",", names.Select(Uri.EscapeDataString));
        }
      
        public static string BuildQueuesString(List<string> queues)
        {
            return string.Join(",", queues);
        }
      
        public static string BuildSeasonString(List<Season> seasons)
        {
            return string.Join(",", seasons.Select(s => s.ToCustomString()));
        }
    }
}
