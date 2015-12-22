namespace RiotSharp
{
    internal static class Requesters
    {
        public static Requester StaticRequester;
        public static Requester StatusRequester;
        public static RateLimitedRequester GameRequester;
        public static RateLimitedRequester TournamentRequester;
    }
}
