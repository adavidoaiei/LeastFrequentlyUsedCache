using Microsoft.Extensions.Caching.Memory;

namespace LfuCache.PerformanceTest
{
    public class MemoryCache<T> : ICache<string, T>
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCache()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        public void Add(string key, T item)
        {
            _memoryCache.Set(key, item);
        }

        public T Get(string key)
        {
            object value = null;
            if (_memoryCache.TryGetValue(key, out value))
                return (T)value;

            return default(T);
        }
    }
}
