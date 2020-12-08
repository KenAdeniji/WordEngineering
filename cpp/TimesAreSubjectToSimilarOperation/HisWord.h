#include <iostream>
#include <iomanip>
#include <ctime>

#ifndef HisWord_HPP
#define HisWord_HPP
 
class HisWord
{
	private:
		int dated;
		int m_month;
		int m_day;
 
public:
    Date(int year, int month, int day);
 
    void SetDate(int year, int month, int day);
 
    int getYear() { return m_year; }
    int getMonth() { return m_month; }
    int getDay()  { return m_day; }
};
 
#endif
