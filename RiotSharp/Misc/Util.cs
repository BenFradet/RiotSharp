// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Util.cs" company="">
//
// </copyright>
// <summary>
//   The util.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace RiotSharp
{
    /// <summary>
    /// The util.
    /// </summary>
    static class Util
    {
        /// <summary>
        /// The to date time from milli seconds.
        /// </summary>
        /// <param name="millis">
        /// The millis.
        /// </param>
        /// <returns>
        /// The <see cref="DateTime"/>.
        /// </returns>
        public static DateTime ToDateTimeFromMilliSeconds(this long millis)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddMilliseconds(millis);
            return dateTime;
        }

        /// <summary>
        /// The to long.
        /// </summary>
        /// <param name="dateTime">
        /// The date time.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        public static long ToLong(this DateTime dateTime)
        {
            var span = dateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (long)span.TotalMilliseconds;
        }

        /// <summary>
        /// The build ids string.
        /// </summary>
        /// <param name="ids">
        /// The ids.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string BuildIdsString(List<int> ids)
        {
            string concatenatedIds = string.Empty;
            for (int i = 0; i < ids.Count - 1; i++)
            {
                concatenatedIds += ids[i] + ",";
            }

            return concatenatedIds + ids[ids.Count - 1];
        }

        /// <summary>
        /// The build names string.
        /// </summary>
        /// <param name="names">
        /// The names.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string BuildNamesString(List<string> names)
        {
            string concatenatedNames = string.Empty;
            for (int i = 0; i < names.Count - 1; i++)
            {
                concatenatedNames += Uri.EscapeDataString(names[i]) + ",";
            }

            return concatenatedNames + Uri.EscapeDataString(names[names.Count - 1]);
        }

        /// <summary>
        /// The build queues string.
        /// </summary>
        /// <param name="queues">
        /// The queues.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string BuildQueuesString(List<Queue> queues)
        {
            string concatenatedQueues = string.Empty;
            for (int i = 0; i < queues.Count - 1; i++)
            {
                concatenatedQueues += queues[i].ToCustomString();
            }

            return concatenatedQueues + queues[queues.Count - 1].ToCustomString();
        }
    }
}
