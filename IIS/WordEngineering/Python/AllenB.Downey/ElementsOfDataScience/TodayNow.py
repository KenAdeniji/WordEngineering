"""
2022-11-04T07:36:00 Created. http://allendowney.github.io/ElementsOfDataScience/02_times.html
2022-11-04T07:42:00 http://stackoverflow.com/questions/32490629/getting-todays-date-in-yyyy-mm-dd-in-python
"""
if __name__ == '__main__':
    import sys; from datetime import datetime; print(datetime.today().strftime('%Y-%m-%d %H:%M:%S'))
