using System;

namespace RiotSharp
{
    static class DateTimeUtil
    {
        public static DateTime ToDateTimeFromMilliSeconds(this long millis)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddMilliseconds(millis);
            return dateTime;
        }

        public static long ToLong(this DateTime dateTime)
        {
            var span = dateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (long)span.TotalMilliseconds;
        }
    }
}
