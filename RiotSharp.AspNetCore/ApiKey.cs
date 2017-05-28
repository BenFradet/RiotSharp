namespace RiotSharp.AspNetCore
{
    public class ApiKey
    {
        public string Key { get; set; }
        public int RateLimitPer10S { get; set; }
        public int RateLimitPer10M { get; set; }
    }
}
