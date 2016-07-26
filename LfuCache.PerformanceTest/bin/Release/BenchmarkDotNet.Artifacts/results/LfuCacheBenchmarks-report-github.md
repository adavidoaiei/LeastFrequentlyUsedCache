```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-4790 CPU 3.60GHz, ProcessorCount=8
Frequency=3507507 ticks, Resolution=285.1028 ns, Timer=ACPI
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1080.0

Type=LfuCacheBenchmarks  Mode=Throughput  

```
                       Method | ProcessingElementsCount | OperationsCount | CacheSize |      Median |    StdDev | Gen 0 |  Gen 1 | Gen 2 | Bytes Allocated/Op |
----------------------------- |------------------------ |---------------- |---------- |------------ |---------- |------ |------- |------ |------------------- |
 BenchmarkLfuCachePerformance |                  100000 |         1000000 |     90000 | 411.7506 ms | 6.3437 ms | 30.00 | 264.00 |  4.00 |       8,372,169.54 |
