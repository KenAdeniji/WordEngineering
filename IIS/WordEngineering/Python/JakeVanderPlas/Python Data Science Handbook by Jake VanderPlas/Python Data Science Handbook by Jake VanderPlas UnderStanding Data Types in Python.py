"""
    Numbers 26:4                Take the sum of the people, from twenty years old and upward; as the Lord commanded Moses and the children of Israel, which went forth out of the land of Egypt.
    Numbers 4:30, Luke 3:23     From thirty years old and upward even unto fifty years old shalt thou number them, every one that entereth into the service, to do the work of the tabernacle of the congregation.
"""
result = 0
dataFromUntil = 20, 30
for i in range(dataFromUntil[0], dataFromUntil[1] + 1):
    result += i
print (result)

listOfIntegersBetweenTwentyAndThirty = list(range(dataFromUntil[0], dataFromUntil[1] + 1))
print (listOfIntegersBetweenTwentyAndThirty)
