#!/bin/bash
#2022-09-02 Created.
#2022-09-02     http://stackoverflow.com/questions/255898/how-to-iterate-over-arguments-in-a-bash-script
#2022-09-02     https://stackoverflow.com/questions/10551981/how-to-perform-a-for-loop-on-each-character-in-a-string-in-bash
#2022-09-02     https://stackoverflow.com/questions/13700632/convert-to-uppercase-in-shell
#chmod 777 2022-09-02ArgumentIterator.sh
#./2022-09-02ArgumentIterator.sh
#2022-09-02		Active Directory
#adinfo
#adjoin
#2022-09-04T16:58:00 	dos2unix.exe 2022-09-02ArgumentIterator.sh
#2022-09-04T17:17:00	https://stackoverflow.com/questions/6348902/how-can-i-add-numbers-in-a-bash-script
for var in "$@"
do
    word="${var^^}"
    wordValue=0
	for (( i=0; i<${#word}; i++ ))
	do
		characterValue="${foo:$i:1}"
		ascValue=$( printf "%d" "'${characterValue}" )
		wordLiteral="$wordValue+$ascValue-64"
		wordValue=$((wordValue+$ascValue-64))
	done
	echo "${word}${wordValue}"
done
