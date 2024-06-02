"""
	python 2024-06-01T0552UncoveringDatesAndTimes.py
"""
import datetime

def main():
	today = datetime.date.today()
	today_year = today.year
	today_century = (today_year // 100) * 100
	today_year_teen = today_century + 19
	last_of_teens = datetime.date(today_year_teen, 12, 31)
	#print(today_year, today_century, today_year_teen)
	print(f"Today's date: {today}");
	print(f"Last of teens for this century: {last_of_teens}");
	
if __name__ == '__main__':
	main()
	