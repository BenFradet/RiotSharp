using System;

namespace RiotSharp.Caching
{

    /// <summary>
    /// Wrapper for file cache
    /// </summary>
    /// <typeparam name="T">Type of the data</typeparam>
    [Serializable]
    public class CacheData<T>
    {

        /// <summary>
        /// Initializes a CacheData class
        /// </summary>
        /// <param name="ttlMins">Minutes for cache to live</param>
        /// <param name="data">Data to store in cache</param>
        public CacheData(long ttlMins, T data)
        {
            TtlMinutes = ttlMins;
            Data = data;
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Minutes for cache to live
        /// </summary>
        public long TtlMinutes { get; set; }

        /// <summary>
        /// Data to store in cache
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// To decide on if cache is expired or not, store created time
        /// </summary>
        public DateTime CreatedAt { get; set; }

    }
}