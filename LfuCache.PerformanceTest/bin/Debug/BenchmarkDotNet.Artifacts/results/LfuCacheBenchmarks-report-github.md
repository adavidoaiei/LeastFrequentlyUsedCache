```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-4790 CPU 3.60GHz, ProcessorCount=8
Frequency=3507503 ticks, Resolution=285.1031 ns, Timer=ACPI
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE [AttachedDebugger]
JitModules=clrjit-v4.6.1080.0

Type=LfuCacheBenchmarks  Mode=Throughput  

```
                       Method | ElementsCount | OperationsCount | CacheSize |    Median |    StdDev | Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
----------------------------- |-------------- |---------------- |---------- |---------- |---------- |------ |------ |------ |------------------- |
 BenchmarkLfuCachePerformance |        100000 |          200000 |     90000 | 7.6411 ms | 0.0510 ms |  1.00 |  1.00 |     - |         139,535.09 |
