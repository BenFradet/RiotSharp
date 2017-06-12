namespace RiotSharp.AspNetCore
{
    public class ApiKeyOptions
    {
        internal ApiKeyOptions() { }

        public string ApiKey { get; set; }
        public int RateLimitPer10S { get; set; }
        public int RateLimitPer10M { get; set; }
    }
}
