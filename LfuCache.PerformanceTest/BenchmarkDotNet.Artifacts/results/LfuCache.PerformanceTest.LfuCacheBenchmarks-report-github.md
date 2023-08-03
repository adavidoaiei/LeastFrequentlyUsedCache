```

BenchmarkDotNet v0.13.6, Ubuntu 22.04.2 LTS (Jammy Jellyfish)
Intel Core i3-6006U CPU 2.00GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 7.0.109
  [Host]     : .NET 7.0.9 (7.0.923.32301), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32301), X64 RyuJIT AVX2


```
|                       Method | ProcessingElementsCount | OperationsCount | CacheSize |    Mean |    Error |   StdDev |      Gen0 |      Gen1 | Allocated |
|----------------------------- |------------------------ |---------------- |---------- |--------:|---------:|---------:|----------:|----------:|----------:|
| BenchmarkLfuCachePerformance |                  100000 |         1000000 |     90000 | 1.580 s | 0.0958 s | 0.2639 s | 8000.0000 | 7000.0000 |  45.84 MB |
