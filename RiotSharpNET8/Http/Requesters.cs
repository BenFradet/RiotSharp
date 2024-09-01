namespace RiotSharpNET8.Http
{
    internal static class Requesters
    {
        public static Requester? StaticApiRequester;
        //public static Requester? StatusApiRequester; // obsolete
        public static RateLimitedRequester? RiotApiRequester;
        public static RateLimitedRequester? TournamentApiRequester;
    }
}
