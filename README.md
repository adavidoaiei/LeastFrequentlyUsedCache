# Least Frequently Used Cache

A Least Frequently Cache algorithm implementation which has logarithmic complexity, it's using a binary tree where nodes are linked list of cached elements with the same use count, this binary tree sorts this linked lists by use count.

<b>Performance benchmark</b><br>

500.000 add/get operations from a list with 100.000 in a cache of size 90.000 with  in 201ms
<img src="https://lh3.googleusercontent.com/s8-BdObj5CZEcmxI5YrabPgIWcWiYsmoZ70K4Zf7FpLDjAMN7SGQe_wRqjtcm7W05mdtLcCQkxvoCUAO2crzVjI_u4icR71x8zXIEY-nNpqxOv9reyx9jIazbIMouyL1q3rha25AgvJhH5xsjngSeq9PCqyq_8It00_Al2sJpnoFb9krsV47fOnY8qMIUOKcSZlOth2jtgKUdSnnFQrpksbQlskYG_fTLqenr8YKTMmgcWUJ4-n-BFk4fmbU29MHhbGuWuZDq1tANphWYBboSZpc-8HsnWDHCrYjHuI1XH9PJ8mQ-u2YxIudfjTFvt8t7T7QK8FbuoNTAX5PAuScf8YamFsUPqBDXpdp9cfYSWw5fv4Nzn0OYPQw7xI4aag_m95dQK1payicU-uw6zuyDARl-ZMjsw31eUt6JJBtc83spS4_f1TTZma5GLG03QC7c6VofUrwqVhNDPhYH7w9ZDc4u0oAlbVbwfEOvnFV7E3qt6gqvgKaOMjne3Ya1GzqAaa70XPYFOJUvWZF-hAQgLyPhnjbsU5MukLoADLzkA2outhMnmaOJrcaNRZwyRdgJFUrrO4PpF1fiBRYKvoNNTQbyXSBGGg=w1077-h208-no" />

