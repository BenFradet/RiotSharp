using RiotSharp.Core.Caching;

namespace RiotSharp.Core.Tests.CacheTests
{
    public class InMemoryCacheTest
    {
        private readonly ICache _cache;

        public InMemoryCacheTest()
        {
            _cache = new InMemoryCache();
        }

        // Test class for object-based tests
        private class TestObject
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public DateTime CreatedAt { get; set; }

            public override bool Equals(object? obj)
            {
                if (obj is TestObject other)
                {
                    return Id == other.Id && Name == other.Name && CreatedAt == other.CreatedAt;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Id, Name, CreatedAt);
            }
        }

        [Fact]
        public void Add_WithSlidingExpiration_ShouldAddToCache()
        {
            var key = "testKey";
            var value = "testValue";
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key, value, slidingExpiration);

            var valueFound = _cache.TryGet<string, string>(key, out var returnedValue);

            Assert.True(valueFound);
            Assert.Equal(value, returnedValue);
        }

        [Fact]
        public void Add_WithAbsoluteExpiration_ShouldAddToCache()
        {
            var key = "testKey";
            var value = "testValue";
            var absoluteExpiration = DateTime.Now.AddMinutes(5);

            _cache.Add(key, value, absoluteExpiration);

            var valueFound = _cache.TryGet<string, string>(key, out var cachedValue);
            Assert.True(valueFound);
            Assert.Equal(value, cachedValue);
        }

        [Fact]
        public void Get_WithNonExistentKey_ShouldReturnNull()
        {
            var key = "nonExistentKey";

            var valueFound = _cache.TryGet<string, string>(key, out var cachedValue);
            Assert.False(valueFound);
            Assert.Null(cachedValue);
        }

        [Fact]
        public void Remove_ShouldRemoveFromCache()
        {
            var key = "testKey";
            var value = "testValue";
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key, value, slidingExpiration);
            _cache.Remove(key);

            var valueFound = _cache.TryGet<string, string>(key, out var cachedValue);
            Assert.False(valueFound);
            Assert.Null(cachedValue);
        }

        [Fact]
        public void Clear_ShouldRemoveAllItemsFromCache()
        {
            var key1 = "testKey1";
            var value1 = "testValue1";
            var key2 = "testKey2";
            var value2 = "testValue2";
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key1, value1, slidingExpiration);
            _cache.Add(key2, value2, slidingExpiration);
            _cache.Clear();

            var value1Found = _cache.TryGet<string, string>(key1, out var cachedValue1);
            var value2Found = _cache.TryGet<string, string>(key2, out var cachedValue2);
            Assert.False(value1Found);
            Assert.False(value2Found);
            Assert.Null(cachedValue1);
            Assert.Null(cachedValue2);
        }

        [Fact]
        public void Add_WithSlidingExpiration_ShouldExpire()
        {
            var key = "testKey";
            var value = "testValue";
            var slidingExpiration = TimeSpan.FromSeconds(1);

            _cache.Add(key, value, slidingExpiration);
            Thread.Sleep(2000);

            var valueFound = _cache.TryGet<string, string>(key, out var cachedValue);
            Assert.False(valueFound);
            Assert.Null(cachedValue);
        }

        [Fact]
        public void Add_WithAbsoluteExpiration_ShouldExpire()
        {
            var key = "testKey";
            var value = "testValue";
            var absoluteExpiration = DateTime.Now.AddSeconds(1);

            _cache.Add(key, value, absoluteExpiration);
            Thread.Sleep(2000);

            var valueFound = _cache.TryGet<string, string>(key, out var cachedValue);
            Assert.False(valueFound);
            Assert.Null(cachedValue);
        }

        [Fact]
        public void Count_ShouldReturnCorrectNumberOfItems()
        {
            var key1 = "testKey1";
            var value1 = "testValue1";
            var key2 = "testKey2";
            var value2 = "testValue2";
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key1, value1, slidingExpiration);
            _cache.Add(key2, value2, slidingExpiration);

            var count = _cache.Count();
            Assert.Equal(2, count);
        }

        #region Integer Tests

        [Fact]
        public void Add_WithIntKeyAndValue_ShouldAddToCache()
        {
            var key = 42;
            var value = 100;
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key, value, slidingExpiration);

            var valueFound = _cache.TryGet<int, int>(key, out var returnedValue);

            Assert.True(valueFound);
            Assert.Equal(value, returnedValue);
        }

        [Fact]
        public void Add_WithStringKeyAndIntValue_ShouldAddToCache()
        {
            var key = "numberKey";
            var value = 12345;
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key, value, slidingExpiration);

            var valueFound = _cache.TryGet<string, int>(key, out var returnedValue);

            Assert.True(valueFound);
            Assert.Equal(value, returnedValue);
        }

        [Fact]
        public void Add_WithIntKey_ShouldExpire()
        {
            var key = 999;
            var value = 777;
            var slidingExpiration = TimeSpan.FromSeconds(1);

            _cache.Add(key, value, slidingExpiration);
            Thread.Sleep(2000);

            var valueFound = _cache.TryGet<int, int>(key, out var cachedValue);
            Assert.False(valueFound);
            Assert.Equal(0, cachedValue); // default(int) is 0
        }

        [Fact]
        public void Remove_WithIntKey_ShouldRemoveFromCache()
        {
            var key = 55;
            var value = 88;
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key, value, slidingExpiration);
            _cache.Remove(key);

            var valueFound = _cache.TryGet<int, int>(key, out var cachedValue);
            Assert.False(valueFound);
        }

        #endregion

        #region Object Tests

        [Fact]
        public void Add_WithObjectValue_ShouldAddToCache()
        {
            var key = "objectKey";
            var value = new TestObject
            {
                Id = 1,
                Name = "Test Object",
                CreatedAt = new DateTime(2024, 1, 1, 12, 0, 0)
            };
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key, value, slidingExpiration);

            var valueFound = _cache.TryGet<string, TestObject>(key, out var returnedValue);

            Assert.True(valueFound);
            Assert.NotNull(returnedValue);
            Assert.Equal(value.Id, returnedValue.Id);
            Assert.Equal(value.Name, returnedValue.Name);
            Assert.Equal(value.CreatedAt, returnedValue.CreatedAt);
        }

        [Fact]
        public void Add_WithObjectKeyAndValue_ShouldAddToCache()
        {
            var key = new TestObject
            {
                Id = 10,
                Name = "Key Object",
                CreatedAt = DateTime.Now
            };
            var value = new TestObject
            {
                Id = 20,
                Name = "Value Object",
                CreatedAt = DateTime.Now
            };
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key, value, slidingExpiration);

            var valueFound = _cache.TryGet<TestObject, TestObject>(key, out var returnedValue);

            Assert.True(valueFound);
            Assert.NotNull(returnedValue);
            Assert.Equal(value, returnedValue);
        }

        [Fact]
        public void Add_WithObjectValue_AbsoluteExpiration_ShouldAddToCache()
        {
            var key = "objectKey2";
            var value = new TestObject
            {
                Id = 2,
                Name = "Another Test Object",
                CreatedAt = new DateTime(2024, 6, 15, 10, 30, 0)
            };
            var absoluteExpiration = DateTime.Now.AddMinutes(5);

            _cache.Add(key, value, absoluteExpiration);

            var valueFound = _cache.TryGet<string, TestObject>(key, out var returnedValue);

            Assert.True(valueFound);
            Assert.NotNull(returnedValue);
            Assert.Equal(value.Id, returnedValue.Id);
            Assert.Equal(value.Name, returnedValue.Name);
            Assert.Equal(value.CreatedAt, returnedValue.CreatedAt);
        }

        [Fact]
        public void Add_WithObjectValue_ShouldExpire()
        {
            var key = "expiringObjectKey";
            var value = new TestObject
            {
                Id = 3,
                Name = "Expiring Object",
                CreatedAt = DateTime.Now
            };
            var slidingExpiration = TimeSpan.FromSeconds(1);

            _cache.Add(key, value, slidingExpiration);
            Thread.Sleep(2000);

            var valueFound = _cache.TryGet<string, TestObject>(key, out var cachedValue);
            Assert.False(valueFound);
            Assert.Null(cachedValue);
        }

        [Fact]
        public void Remove_WithObjectKey_ShouldRemoveFromCache()
        {
            var key = new TestObject
            {
                Id = 100,
                Name = "Remove Key",
                CreatedAt = new DateTime(2024, 1, 1)
            };
            var value = "Some Value";
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key, value, slidingExpiration);
            _cache.Remove(key);

            var valueFound = _cache.TryGet<TestObject, string>(key, out var cachedValue);
            Assert.False(valueFound);
            Assert.Null(cachedValue);
        }

        [Fact]
        public void Count_WithMixedTypes_ShouldReturnCorrectCount()
        {
            _cache.Clear(); // Start fresh

            _cache.Add("stringKey", "stringValue", TimeSpan.FromMinutes(5));
            _cache.Add(42, 100, TimeSpan.FromMinutes(5));
            _cache.Add("objectKey", new TestObject { Id = 1, Name = "Test" }, TimeSpan.FromMinutes(5));

            var count = _cache.Count();
            Assert.Equal(3, count);
        }

        #endregion
    }
}

