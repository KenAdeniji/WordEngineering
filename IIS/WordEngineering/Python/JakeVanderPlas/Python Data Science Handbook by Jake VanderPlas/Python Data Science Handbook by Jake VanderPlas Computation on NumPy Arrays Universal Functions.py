"""
    http://jakevdp.github.io/PythonDataScienceHandbook/02.03-computation-on-arrays-ufuncs.html
    Numbers 26:4                Take the sum of the people, from twenty years old and upward; as the Lord commanded Moses and the children of Israel, which went forth out of the land of Egypt.
    Numbers 4:30, Luke 3:23     From thirty years old and upward even unto fifty years old shalt thou number them, every one that entereth into the service, to do the work of the tabernacle of the congregation.
    pip install numpy
    2026-07-21T16:56:00         Initialize a numpy array?
        http://stackoverflow.com/questions/5891410/numpy-array-initialization-fill-with-identical-values
            numpyArrayOfIntegersBetweenTwentyAndThirty = np.full(2, [20, 30])
    http://github.com/KenAdeniji/WordEngineering/blob/main/IIS/WordEngineering/Python/JakeVanderPlas/Python%20Data%20Science%20Handbook%20by%20Jake%20VanderPlas/Python%20Data%20Science%20Handbook%20by%20Jake%20VanderPlas%20Computation%20on%20NumPy%20Arrays%20Universal%20Functions.py
"""
import numpy as np
from scipy import special

Array_Size = 2

Military_Census_Age_Index = 0
Military_Census_Age = 20

Priesthood_Commencement_Age_Index = 1
Priesthood_Training_Age = 25
Priesthood_Commencement_Age = 30
Priesthood_Retirement_Age = 55

numpyArrayOfIntegersBetweenTwentyAndThirty = np.full(Array_Size, [Military_Census_Age, Priesthood_Commencement_Age])

print(f"numpyArrayOfIntegersBetweenTwentyAndThirty military census age? {numpyArrayOfIntegersBetweenTwentyAndThirty[Military_Census_Age_Index]} years. Priesthood commencement age? {numpyArrayOfIntegersBetweenTwentyAndThirty[Priesthood_Commencement_Age_Index]} years.")

print(f"2026-07-21T17:18:00 numpyArrayOfIntegersBetweenTwentyAndThirty: How long do priests serve for? {Priesthood_Retirement_Age - numpyArrayOfIntegersBetweenTwentyAndThirty[Priesthood_Commencement_Age_Index]} years (Numbers 8:25)")

print(f"2026-07-21T17:18:00 numpyArrayOfIntegersBetweenTwentyAndThirty: Priesthood training commence? {Priesthood_Training_Age} years. Priesthood training period? {Priesthood_Commencement_Age - Priesthood_Training_Age} years (Numbers 8:24)")

print(f"2026-07-21T21:31:00 numpyArrayOfIntegersBetweenTwentyAndThirty: Minimum age? {np.min(numpyArrayOfIntegersBetweenTwentyAndThirty)}")
assert numpyArrayOfIntegersBetweenTwentyAndThirty[0] == np.min(numpyArrayOfIntegersBetweenTwentyAndThirty)

print(f"2026-07-21T21:31:00 numpyArrayOfIntegersBetweenTwentyAndThirty: Maximum age? {np.max(numpyArrayOfIntegersBetweenTwentyAndThirty)}")
assert numpyArrayOfIntegersBetweenTwentyAndThirty[np.size(numpyArrayOfIntegersBetweenTwentyAndThirty) - 1] == np.max(numpyArrayOfIntegersBetweenTwentyAndThirty)