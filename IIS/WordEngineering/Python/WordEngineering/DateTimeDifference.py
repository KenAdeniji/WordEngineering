"""
2026-07-11  Created.    http://goalkicker.com/PythonBook/PythonNotesForProfessionals.pdf
python DateTimeDifferenceHelper.py "2015-01-01T12:00:00-0500" "2016-04-15T08:27:18-0500"
To get n day's after and n day's before date we could use:
n day's after date:
def get_n_days_after_date(date_format="%d %B %Y", add_days=120):
    date_n_days_after = datetime.datetime.now() + timedelta(days=add_days)
    return date_n_days_after.strftime(date_format)
n day's before date:
def get_n_days_before_date(self, date_format="%d %B %Y", days_before=120):
    date_n_days_ago = datetime.datetime.now() - timedelta(days=days_before)
    return date_n_days_ago.strftime(date_format)
2026-07-12T20:05:00 http://stackoverflow.com/questions/796008/error-cant-subtract-offset-naive-and-offset-aware-datetimes
2026-07-12T20:05:00 http://stackoverflow.com/questions/796008/error-cant-subtract-offset-naive-and-offset-aware-datetimes/25662061#25662061    
"""
import sys
from datetime import datetime, timedelta, timezone
class DateTimeDifference():
    datedFrom: datetime
    datedUntil: datetime
    # Initializer / Instance Attributes
    def __init__(self, datedFrom: str, datedUntil: str):
        self.datedFrom = datetime.strptime(datedFrom, "%Y-%m-%dT%H:%M:%S%z")
        self.datedUntil = datetime.strptime(datedUntil, "%Y-%m-%dT%H:%M:%S%z")

    def __str__(self): #2019-06-11  https://www.brianheinold.net/python/A_Practical_Introduction_to_Python_Programming_Heinold.pdf
        #return "DateTimeDifference datedFrom: {0} datedUntil: {1} days: {2}".format(self.datedFrom, self.datedUntil, self.fromUntil.days)
        return f'DateTimeDifference datedFrom: {self.datedFrom} datedUntil: {self.datedUntil} days: {self.fromUntil.days}'

    @property    
    def fromUntil(self):
        """
            Calculate delta.
        """	
        return self.datedUntil - self.datedFrom
		
if __name__ == '__main__':
    dateTimeDifference = DateTimeDifference(sys.argv[1], sys.argv[2])
    print(dateTimeDifference)
    dateTimeDifference.datedFrom = datetime.now(timezone.utc)
    dateTimeDifference.datedUntil = datetime.now(timezone.utc)
    print(dateTimeDifference)

