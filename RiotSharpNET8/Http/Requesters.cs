using RiotSharpNET8.Http.Interfaces;

namespace RiotSharpNET8.Http
{
    internal static class Requesters
    {
        public static Requester? StaticApiRequester;
		//public static Requester? StatusApiRequester; // obsolete
		public static RiotRiotRateLimitedRequester? RiotApiRequester;
        public static RiotRiotRateLimitedRequester? TournamentApiRequester;
    }
}
