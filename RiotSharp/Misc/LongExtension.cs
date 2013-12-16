using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    public static class LongExtension
    {
        public static DateTime ToDateTimeFromMillis(this long millis)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddMilliseconds(millis);
            return dateTime;
        }

        public static TimeSpan ToTimeSpanFromMillis(this long millis)
        {
            return TimeSpan.FromMilliseconds(millis);
        }
    }
}
