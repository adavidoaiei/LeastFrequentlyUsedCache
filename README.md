# Least Frequently Used Cache

A Least Frequently Cache algorithm implementation which has logarithmic complexity, it's using a binary tree where nodes are linked list of cached elements with the same use count, this binary tree sorts this linked lists by use count.

<b>Performance benchmark</b><br>

200.000 operations on a cache of size 90.000 in 62ms
<img src="https://lh3.googleusercontent.com/cF-NcS4A3gpVmoOBwn5v2oAOCI4iqPGHWq4zhQaSaGKgy7s-6R1KUV09m-qFWq7akDgObbZm-QXXNFFE4ORj68iF_7Jh_2L68dCh-6rnu2KXxRYpYHzlaagfF2VRmA4nNgrk7FN0iv2TbLnCeb1LmKnT8upvr5wIHBHyQXHQDQ0h6CkVrZxjV37CjECs-5Sda2dru7V9Y32bLffDW6ueWCWcdKBQUFUHDcVb5W6fTVJq4nocRUh-VOey1jSns9ciOA70TSkWlL4YLAHO4gFsw1DIuFvTubqeKo4d2sOff-H8TipoHQuIHXA36SaiXwwAViLW5AqIq-aoorDFRSfRGs4KRJ7S2xk06nRcIpnVW-8lpG6ZKfMsdgnCmo_0b50lBzH4_DRoJFxfMkqlv9M-5acRuYdYUGC_RxNrbqAsZALZGswqN2O16DteiBBxq7Ixd-sg_ewpGd9eJ2ZfhLJDoUQV5tHEU-iUUbsLbi2TQdktO06iqYoYJ_x-eABycYRWmuB9KCYZpbD6ZHCqqzpNSrDF6vnTDFRFXF0w55tvjiPfP7uw5tADvugU_-hDTyrqkJjBnwCYODzTHmrHvmQmUuXOOqxk074=w1053-h249-no" />

