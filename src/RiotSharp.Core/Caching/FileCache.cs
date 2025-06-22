using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace RiotSharp.Core.Caching
{
    /// <summary>
    /// InMemoryCache implementation which will write the cache to a file.
    /// </summary>
    /// <seealso cref="ICache" />
    public class FileCache : ICache
    {
        private readonly string _directory;
        private readonly bool _hashKeys;

        /// <summary>
        /// Create file cache instance
        /// </summary>
        /// <param name="directory">Directory for the cache to store in</param>
        /// <param name="hashKeys"></param>
        public FileCache(Uri directory, bool hashKeys = false)
        {
            if (string.IsNullOrWhiteSpace(directory.OriginalString))
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
            _hashKeys = hashKeys;
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

        public int Count()
        {
	        throw new NotImplementedException();
        }

        /// <inheritdoc />
        public TV? Get<TK, TV>(TK key) where TV : class
        {
            CacheData<TV>? data;
            try
            {
                var str = key?.ToString();
                data = Load<CacheData<TV>>(str);
            }
            catch (FileNotFoundException)
            {
                data = null;
            }
            return IsExpired(data) ? null : data?.Data;
        }

        /// <inheritdoc />
        public void Remove<TK>(TK key)
        {
            var path = GetPath(key?.ToString());
            File.Delete(path);
        }

        private string GetPath(string? key)
        {
            if (_hashKeys)
            {
                using (SHA1 hasher = SHA1.Create())
                {
	                if (key != null)
	                {
		                byte[] input = Encoding.UTF8.GetBytes(key);
		                byte[] hashBytes = hasher.ComputeHash(input);
		                key = BitConverter.ToString(hashBytes).Replace("-", "");
	                }
                }
            }
            var path = Path.Combine(_directory, key + ".json");
            return path;
        }

        private T? Load<T>(string? path)
        {
            var filePath = GetPath(path);
            var readText = File.ReadAllText(filePath);
            var json = JsonSerializer.Deserialize<T>(readText);
            return json;
        }

        private void Store<TK, TV>(TK key, TV value, long ttlMins = 24 * 60 * 7 * 4) // A month
        {
            CacheData<TV> data = new CacheData<TV>(ttlMins, value);
            var filePath = GetPath(key?.ToString());
            var serialisedJson = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, serialisedJson);
        }

        private bool IsExpired<T>(CacheData<T>? data)
        {
            return data == null || DateTime.Now > data.CreatedAt.AddMinutes(data.TtlMinutes);
        }
    }
}
