#2019-09-03 https://pymotw.com/3/time/index.html

import time

print('The time is:', time.time()) #Unix epoch
print('The time is      :', time.ctime())

later = time.time() + 15
print('15 secs from now :', time.ctime(later))

"""
The start point for the monotonic clock is not defined, 
so return values are only useful for doing calculations
with other clock values.
In this example the duration of the sleep is measured using monotonic().
"""

start = time.monotonic()
time.sleep(0.1)
end = time.monotonic()
print('start : {:>9.2f}'.format(start))
print('end   : {:>9.2f}'.format(end))
print('span  : {:>9.2f}'.format(end - start))

"""
The gmtime() function returns the current time in UTC. 
localtime() returns the current time with the current time zone applied.
mktime() takes a struct_time and converts it to the floating point representation.
"""

def show_struct(s):
    print('  tm_year :', s.tm_year)
    print('  tm_mon  :', s.tm_mon)
    print('  tm_mday :', s.tm_mday)
    print('  tm_hour :', s.tm_hour)
    print('  tm_min  :', s.tm_min)
    print('  tm_sec  :', s.tm_sec)
    print('  tm_wday :', s.tm_wday)
    print('  tm_yday :', s.tm_yday)
    print('  tm_isdst:', s.tm_isdst)


print('gmtime:')
show_struct(time.gmtime())
print('\nlocaltime:')
show_struct(time.localtime())
print('\nmktime:', time.mktime(time.localtime()))
