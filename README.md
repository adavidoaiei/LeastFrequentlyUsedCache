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

The Add/Get operations sequence is generated random in operations array of size OperationsCount, this operations process elements from a list of size EelementsCount in used cache.



