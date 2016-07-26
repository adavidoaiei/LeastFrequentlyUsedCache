using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows;

namespace LfuCache.PerformanceTest
{
    [Config(typeof(MemoryConfig))]
    public class LfuCacheBenchmarks
    {
        [Params(100000)]
        public int NrElements { get; set; }

        [Params(90000)]
        public int CacheSize { get; set; }

        class ListElement
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

        private ICache<string, string> _lfuCache;

        private IList<ListElement> _cacheElements;

        [Setup]
        public void BeforeEach()
        {
            _lfuCache = new LfuCache<string, string>(CacheSize);
            _cacheElements = new List<ListElement>();

            var random = new Random();

            for (int i = 0; i < NrElements; i++)
            {
                ListElement listElement = new ListElement();
                var element = random.Next(1, NrElements).ToString();
                listElement.Key = element;
                listElement.Value = element;
                _cacheElements.Add(listElement);
            }
        }

        [Benchmark]
        public void BenchmarkLfuCachePerformance()
        {
            foreach (ListElement le in _cacheElements)
            {
                _lfuCache.Add(le.Key, le.Value);
            }

            foreach (ListElement le in _cacheElements)
            {
                _lfuCache.Get(le.Key);
            }
        }

        private class MemoryConfig : ManualConfig
        {
            public MemoryConfig()
            {
                Add(new MemoryDiagnoser());
            }
        }
    }
}
