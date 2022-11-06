"""
2022-11-05T16:50:00 Created. http://allendowney.github.io/ElementsOfDataScience/02_times.html
2022-11-05T16:50:00 ... 2022-11-05T17:14:00 IndentationError tab error versus (VS) 4 spaces
"""
if __name__ == '__main__':
    import sys;
    import pandas as pd;
    import numpy as np;
    date_file_created = pd.Timestamp('2022-11-04T18:54:00');
    print(date_file_created);
    print(f'Year {date_file_created.year} Month {date_file_created.month} Day {date_file_created.day} Day name {date_file_created.day_name()} Month Name {date_file_created.month_name()}');
    today_now = pd.Timestamp.now();
    print(today_now);
    date_of_birth = pd.Timestamp('1967-10-15');
    dates_difference = today_now - date_of_birth;
    print(f'Age {dates_difference.components}');
    print(f'Age between {np.floor(dates_difference.days / 365.25)} ... {np.ceil(dates_difference.days / 365.25)}');
    birthday_this_year = pd.Timestamp(today_now.year, date_of_birth.month, date_of_birth.day);
    birthday_gone_this_year = today_now > birthday_this_year;
    print(f'Birthday gone this year {birthday_gone_this_year}');
    lat_lon_boston_string = '42.3601° N, 71.0589° W'
    boston_latitude = 42.3601; #Positive latitude for the northern hemisphere, negative latitude for the southern hemisphere, and
    boston_longitude = -71.0589; #Positive longitude for the eastern hemisphere and negative longitude for the western hemisphere.
    boston_latitude_longitude = boston_latitude, boston_longitude; #The type of this variable is tuple, which is a mathematical term for a value that contains a sequence of elements.
    print(f'Boston Latitude Longitude {boston_latitude_longitude}');