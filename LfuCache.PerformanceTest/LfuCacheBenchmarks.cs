using System;
using System.Collections;
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
        public int ElementsCount { get; set; }

        [Params(200000)]
        public int OperationsCount { get; set; }

        [Params(90000)]
        public int CacheSize { get; set; }

        private BitArray _operations;

        private class OperationType
        {
            public const bool Read = false;
            public const bool Write = true;
        }

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
            _operations = new BitArray(OperationsCount);

            var random = new Random();

            for (int i = 0; i < ElementsCount; i++)
            {
                ListElement listElement = new ListElement();
                var element = random.Next(1, ElementsCount).ToString();
                listElement.Key = element;
                listElement.Value = element;
                _cacheElements.Add(listElement);
            }

            for (int i = 0; i < OperationsCount; i++)
            {
                _operations[i] = Convert.ToBoolean(random.Next(Convert.ToInt32(OperationType.Read), Convert.ToInt32(OperationType.Write)));
            }
        }

        [Benchmark]
        public void BenchmarkLfuCachePerformance()
        {
            int index = 0;
            for (int i = 0; i < OperationsCount; i++)
            {
                if (index >= _cacheElements.Count)
                    index = index % _cacheElements.Count;

                if (_operations[i] == OperationType.Read)
                {
                    _lfuCache.Get(_cacheElements[index].Key);
                }
                else if (_operations[i] == OperationType.Write)
                {
                    _lfuCache.Add(_cacheElements[index].Key, _cacheElements[index].Value);
                }

                index++;
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
