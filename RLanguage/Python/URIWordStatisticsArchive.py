"""
2019-04-23 Created.	http://greenteapress.com/thinkpython/thinkpython.pdf
2019-04-23 https://stackoverflow.com/questions/15138614/how-can-i-read-the-contents-of-an-url-with-python
2019-04-23 https://s3.amazonaws.com/udacity-hosted-downloads/ud036/movie_quotes.txt
"""
def uriWordStats(uri):
    print(uri)
    f = urlopen(uri)
    fileContent = f.read().decode('utf-8').lower()
    print(fileContent)
    words = re.findall(r"\w+|[^\w\s]", fileContent, re.UNICODE)
    wordStat = dict()
    for word in words:
        occurrence = word in wordStat
        if (occurrence == False):
            wordStat[word] = 1
        else:    
            wordStat[word] += 1
    keys = wordStat.keys()
    for keyCurrent in keys:
        print(keyCurrent, wordStat[keyCurrent])
        
if __name__ == '__main__':
    import re
    import string
    import sys
    from urllib.request import urlopen
    for i in range(1, len(sys.argv)):
        uriWordStats(sys.argv[i])
