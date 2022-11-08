"""
2022-11-07T04:50:00 Created. https://allendowney.github.io/ElementsOfDataScience/04_loops.html
2022-11-07T08:04:00	https://stackoverflow.com/questions/493386/how-to-print-without-a-newline-or-space/493399#493399
"""
if __name__ == '__main__':
    import sys;
    pentateuch = "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy"
    for bibleBook in pentateuch:
       print(bibleBook)
    for bibleBook in pentateuch:
       for titleLetter in bibleBook:
           print(titleLetter + " ", end='')
       print()