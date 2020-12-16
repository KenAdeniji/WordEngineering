#!/bin/bash
#pscp -pw password -r kadeniji@adriel:/home/kadeniji e:/wordEngineering/Linux/Adriel/home/
#http://stackoverflow.com/questions/15056591/writing-shells-script-to-display-time-in-am-or-pm-notation
clear
cat ~/.bashrc 
nameOfUser="Geeko"
echo "Hello, my name is $nameOfUser"
dated=`date +%Y-%m-%d`
timed=`date +%r`
echo "Today's date is $dated time is $timed"
month=`date +%m`
quarter="Fourth"
if test $month -lt 4
then 
    quarter="First"
elif test $month -lt 7
then
    quarter="Second"
elif test $month -lt 10
then
    quarter="Third"
fi
echo "Today's quarter is $quarter"
ampm=`date +%p`
meridiem=""
case $ampm in
    AM) meridiem="Anti meridiem ($ampm), meaning before midday";;
    PM) meridiem="Post meridiem ($ampm), meaning after noon";;
esac
echo "Time is $ampm $meridiem"
for filename in *
do
  echo "Filename is $filename"
  cat $filename
done
