# Least Frequently Used Cache

A Least Frequently Cache algorithm implementation which has logarithmic complexity, it's using a binary tree where nodes are linked list of cached elements with the same use count, this binary tree sorts this linked lists by use count.

<b>Performance benchmark</b><br>

1000.000 add/get operations using elements from a list with 100.000 in a LFU Cache of size 90.000 in 411ms
<img src="http://res.cloudinary.com/dbvcampra/image/upload/v1469564560/_Untitled_inmaq9.png" />

