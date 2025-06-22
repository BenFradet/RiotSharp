// Questionable if this is ever to be used.
namespace RiotSharp.Core.Misc
{
    public static class Util
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

		// this is outcommented since the Season is a League specific enum(for now)
		/*
        public static string BuildSeasonString(List<Season> seasons)
        {
            return string.Join(",", seasons.Select(s => s.ToCustomString()));
        }
        */
	}
}
