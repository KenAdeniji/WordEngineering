import numpy as np

my_arr = np.arange(1000000)
my_list = list(range(1000000))

#NumPy-based algorithms are generally 10 to 100 times faster (or more) than their pure Python counterparts and use significantly less memory.
#%time for _ in range(10): my_arr2 = my_arr * 2
#%time for _ in range(10): my_list2 = [x * 2 for x in my_list]

data = np.random.randn(2, 3)
data * 2

data.shape
data.dtype