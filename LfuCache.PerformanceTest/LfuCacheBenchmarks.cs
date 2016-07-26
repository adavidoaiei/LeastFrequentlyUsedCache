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
        public int ProcessingElementsCount { get; set; }

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

        private IList<ListElement> _processingElements;

        [Setup]
        public void BeforeEach()
        {
            _lfuCache = new LfuCache<string, string>(CacheSize);
            _processingElements = new List<ListElement>();
            _operations = new BitArray(OperationsCount);

            var random = new Random();

            for (int i = 0; i < ProcessingElementsCount; i++)
            {
                ListElement listElement = new ListElement();
                var element = random.Next(1, ProcessingElementsCount).ToString();
                listElement.Key = element;
                listElement.Value = element;
                _processingElements.Add(listElement);
            }

            for (int i = 0; i < OperationsCount; i++)
            {
                _operations[i] = random.Next(100) < 50 ? OperationType.Read : OperationType.Write;
            }
        }

        [Benchmark]
        public void BenchmarkLfuCachePerformance()
        {
            int index = 0;
            for (int i = 0; i < OperationsCount; i++)
            {
                if (index >= _processingElements.Count)
                    index = index % _processingElements.Count;

                if (_operations[i] == OperationType.Read)
                {
                    _lfuCache.Get(_processingElements[index].Key);
                }
                else if (_operations[i] == OperationType.Write)
                {
                    _lfuCache.Add(_processingElements[index].Key, _processingElements[index].Value);
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
