"""
2019-04-23 Created.	goalkicker.com/PythonBook
2019-04-23 https://stackoverflow.com/questions/466345/converting-string-into-datetime
2019-04-23 http://book.pythontips.com/en/latest/ternary_operators.html
"""
def dateDiff(datedFrom, datedUntil):
    #datedFrom = datetime.strptime(datedFrom, "%Y-%m-%dT%H:%M:%S%z")
    #datedUntil = datetime.strptime(datedUntil, "%Y-%m-%dT%H:%M:%S%z")
    datedFrom = datetime.fromisoformat(datedFrom)
    datedUntil = datetime.fromisoformat(datedUntil)
    delta = datedUntil-datedFrom
    print(delta.days, "days")
    biblicalYear = int(delta.days / 360)
    biblicalMonth = int((delta.days - biblicalYear * 360) / 30)
    biblicalDay = (delta.days - biblicalYear * 360) % 30
    biblicalDuration = ""
    biblicalDuration = daysUnit(biblicalDuration, biblicalYear, " Biblical Year")
    biblicalDuration = daysUnit(biblicalDuration, biblicalMonth, " Biblical Month")
    biblicalDuration = daysUnit(biblicalDuration, biblicalDay, " Day")
    print(biblicalDuration)    
    return

def daysUnit(biblicalDuration, figure, unit):
    if (figure > 0):
        biblicalDuration += ("" if (biblicalDuration == "") else ", ") + str(figure) + unit + ("s" if (figure > 1) else "")
    return biblicalDuration

def get_n_days_after_date(date_format="%d %B %Y", add_days=120):
    date_n_days_after = datetime.datetime.now() + timedelta(days=add_days)
    return date_n_days_after.strftime(date_format)
		
if __name__ == '__main__':
    from datetime import datetime, timedelta, date, time
    import sys
    datedFrom = datetime.now()
    if ( len(sys.argv) <= 1 ):
        datedFrom = "2016-04-15T08:27:18" #"2016-04-15T08:27:18-0700"
    else:
        datedFrom = sys.argv[1]
    datedUntil = datetime.now()
    if ( len(sys.argv) <= 2 ):
        datedUntil = "2019-04-23T08:27:18" #"2019-04-23T08:27:18-0700"
    else:
        datedUntil = sys.argv[2]
    print(datedFrom, datedUntil)	
    datedSpan = dateDiff(datedFrom, datedUntil)
