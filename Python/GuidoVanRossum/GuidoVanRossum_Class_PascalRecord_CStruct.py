#   2019-07-18T21:00:00 https://www.cse.unsw.edu.au/~en1811/python-docs/python-3.6.4-docs-pdf/tutorial.pdf
#   2019-07-18T23:00:00 https://stackoverflow.com/questions/1398022/looping-over-all-member-variables-of-a-class-in-python
#   2019-07-18T23:00:00 https://lists.gt.net/python/python/440285
class GuidoVanRossum_Class_PascalRecord_CStruct():
    # Initializer / Instance Attributes
    pass

if __name__ == '__main__':
    import sys
    # Instantiate the GuidoVanRossum_Class_PascalRecord_CStruct object
    john = GuidoVanRossum_Class_PascalRecord_CStruct() # Create an empty record

    # Fill the fields of the record
    john.name='John Doe'
    john.dept='computer lab'
    john.salary=1000

    # print(john.name)
    print('To get attributes of an instance', set(dir(john))-set(dir(GuidoVanRossum_Class_PascalRecord_CStruct))) # you can now loop overprint('To get attributes of an instance', set(dir(emp1))-set(dir(Employee))) # you can now loop over
    
    for key in dir(john):
        if not key.startswith('__'):
            value = getattr(john,key)
            if not callable(value):
                print(key, value) 
