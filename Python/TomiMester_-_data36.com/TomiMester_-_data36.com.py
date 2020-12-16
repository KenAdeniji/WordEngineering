#2019-10-25 https://data36.com/python-libraries-packages-data-scientists/
import sys
import numpy as np
import matplotlib.pyplot as plt

x = np.array([0.0, 1.0, 2.0, 3.0,  4.0,  5.0])
y = np.array([0.0, 0.8, 0.9, 0.1, -0.8, -1.0])

coefs = np.polyfit(x,y,1)
predict = np.poly1d(coefs)

x_test = np.linspace(0, 16)
y_pred = predict(x_test[:, None])
plt.scatter(x, y)
plt.plot(x_test, y_pred, c='r')
plt.show()
