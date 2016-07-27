using System;
using System.Runtime.Caching;

namespace LfuCache.PerformanceTest
{
    public class MemoryCache<T> : ICache<string, T>
    {
        private readonly MemoryCache _memoryCache;

        public MemoryCache()
        {
            var cacheName = Guid.NewGuid().ToString();
            _memoryCache = new MemoryCache(cacheName);
        }

        public void Add(string key, T item)
        {
            _memoryCache[key] = item;
        }

        public T Get(string key)
        {
            if (_memoryCache.Contains(key))
                return (T)_memoryCache[key];

            return default(T);
        }
    }
}
