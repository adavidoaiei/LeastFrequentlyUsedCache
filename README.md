# Least Frequently Used Cache

<b>Overview</b>

The idea behind least frequently cache policy is that for each item from cache it keeps a use count which increments each time when the item is accessed, when cache exceed the limit this evicts(removes) the element with minimum use count freeing memory for a new element.

<b>Implementation</b>

It's needed a data structure to store elements from cache sorted by use count, the current implementation uses a SortedList where key is use count and Value is LinkedList of elements from cache with the same use count, SortedList sorts LinkedLists by use count using a binary tree.
This data structure allows to run Add/Get operations in O(log n) time.

<b>Performance benchmark</b><br>

1000.000 add/get operations on implemented Least Frequently Used Cache of size 90.000 using elements from a list with 100.000 takes 466ms.

<img src="http://res.cloudinary.com/dbvcampra/image/upload/v1469634935/lfu_syqnac.png" />

This cache runs faster than MemoryCache from .NET Framework and consumes less memory than this on the same benchmark.

<img src="http://res.cloudinary.com/dbvcampra/image/upload/v1469634935/mc_ikzrsm.png" />

The Add/Get operations sequence is generated random in an operations array of size OperationsCount, this operations process elements from a list of size EelementsCount using selected cache.


<b>Applications</b><br><br>
This has applications in browsers, operating systems, and all over in computer system where you should do memory management because memory in computer science is limited and doesn't exist infinite concept like in mathematics.
The component is used in real life projects.

## License
```
The MIT License (MIT)

Copyright (c) Adavidoaiei Dumitru-Cornel

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
