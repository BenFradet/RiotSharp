using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace RiotSharp.Caching
{
    /// <summary>
    /// Cache implementation which will write the cache to a file.
    /// </summary>
    /// <seealso cref="RiotSharp.Caching.ICache" />
    public class FileCache : ICache
    {
        private static string _directory;

        /// <summary>
        /// Create file cache instance
        /// </summary>
        /// <param name="dir">Directory for the cache to store in</param>
        public FileCache(Uri directory)
        {
            if (directory == null)
            {
                throw new ArgumentNullException("Input Uri cannot be null.");
            }
            else if (string.IsNullOrWhiteSpace(directory.OriginalString))
            {
                throw new ArgumentNullException("Directory path cannot be null or empty.");
            }

            if (directory.IsAbsoluteUri)
            {
                _directory = directory.LocalPath;
            }
            else
            {
                string baseDir = Directory.GetCurrentDirectory();
                _directory = Path.Combine(baseDir, directory.OriginalString);
            }

            Directory.CreateDirectory(_directory);
        }

        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry) where TV : class
        {
            Store(key, value, (long)slidingExpiry.TotalMinutes);
        }

        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry) where TV : class
        {
            Store(key, value, (long)(absoluteExpiry - DateTime.Now).TotalMinutes);
        }

        /// <inheritdoc />
        public void Clear()
        {
            DirectoryInfo di = new DirectoryInfo(_directory);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        /// <inheritdoc />
        public TV Get<TK, TV>(TK key) where TV : class
        {
            CacheData<TV> data;
            try
            {
                var str = key.ToString();
                data = Load<CacheData<TV>>(str);
            }
            catch (FileNotFoundException)
            {
                data = null;
            }
            return IsExpired(data) ? null : data.Data;
        }

        /// <inheritdoc />
        public void Remove<TK>(TK key)
        {
            var path = GetPath(key.ToString());
            File.Delete(path);
        }

        private string GetPath(string key)
        {
            string keyHashCode;
            using (SHA1 hasher = SHA1.Create())
            {
                byte[] input = Encoding.UTF8.GetBytes(key);
                byte[] hashBytes = hasher.ComputeHash(input);
                keyHashCode = BitConverter.ToString(hashBytes).Replace("-", "");
            }
            var path = Path.Combine(_directory, keyHashCode);
            return path;
        }

        private T Load<T>(string path)
        {
            var hashedFilePath = $"{GetPath(path)}.json";
            var readText = File.ReadAllText(hashedFilePath);
            var json = JsonConvert.DeserializeObject<T>(readText);
            return json;
        }

        private void Store<TK, TV>(TK key, TV value, long ttlMins = 24 * 60 * 7 * 4) // A month
        {
            CacheData<TV> data = new CacheData<TV>(ttlMins, value);
            var hashedFilePath = GetPath(key.ToString());
            var serialisedJson = JsonConvert.SerializeObject(data);
            File.WriteAllText($"{hashedFilePath}.json", serialisedJson);
        }

        private bool IsExpired<T>(CacheData<T> data)
        {
            return data == null || DateTime.Now > data.CreatedAt.AddMinutes(data.TtlMinutes);
        }
    }
}
