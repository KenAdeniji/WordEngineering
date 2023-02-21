"""
2019-07-19  Created.  https://numpy.org/devdocs/user/quickstart.html
"""
if __name__ == '__main__':
    import numpy as np
    a = np.arange(1, 67, 1).reshape(6, 11)
    print(a)
    print(np.mean(a))

