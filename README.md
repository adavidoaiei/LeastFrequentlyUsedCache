# Least Frequently Used Cache

A Least Frequently Used Cache algorithm implementation which has logarithmic complexity, it's using a binary tree where nodes are linked list of cached elements with the same use count, this binary tree sorts this linked lists by use count.

<b>Performance benchmark</b><br>

1000.000 add/get operations on implemented Least Frequently Used Cache of size 90.000 using elements from a list with 100.000 takes 411ms.

<img src="http://res.cloudinary.com/dbvcampra/image/upload/v1469564560/_Untitled_inmaq9.png" />

This cache runs two times faster than MemoryCache from .NET Framework and consumes half of memory consumed by MemoryCache on the same benchmark.



