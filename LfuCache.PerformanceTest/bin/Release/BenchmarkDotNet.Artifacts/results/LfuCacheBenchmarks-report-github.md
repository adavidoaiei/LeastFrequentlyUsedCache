```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-4790 CPU 3.60GHz, ProcessorCount=8
Frequency=3507499 ticks, Resolution=285.1034 ns, Timer=ACPI
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1080.0

Type=LfuCacheBenchmarks  Mode=Throughput  

```
                       Method | ProcessingElementsCount | OperationsCount | CacheSize |     Median |    StdDev |  Gen 0 |  Gen 1 | Gen 2 | Bytes Allocated/Op |
----------------------------- |------------------------ |---------------- |---------- |----------- |---------- |------- |------- |------ |------------------- |
 BenchmarkLfuCachePerformance |                  100000 |          200000 |     90000 | 62.0024 ms | 0.7934 ms | 163.00 | 324.00 |  2.00 |       3,164,170.66 |
