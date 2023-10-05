#!/bin/bash
#2022-09-07T18:14:00 Created.
#chmod 777 2022-09-02BookTitle.sh
#./2022-09-027BookTitle.sh
#2022-09-04T16:58:00 dos2unix.exe 2022-09-02BookTitle.sh
#2022-09-07T18:14:00 http://stackoverflow.com/questions/8880603/loop-through-an-array-of-strings-in-bash
declare -a bookTitlesPentateuch=("Genesis" "Exodus" "Leviticus" "Numbers" "Deuteronomy")
for (( i=0; i<${#bookTitlesPentateuch[@]}; i++ ))
do
	echo "Book Index: $i Title: ${bookTitlesPentateuch[$i]}"	
done
