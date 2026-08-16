# 2026-08-16    http://pymotw.com/3/enum/index.html
import enum

class BibleBook(enum.Enum):
    genesis = 1
    matthew = 40
    revelation = 66
    
print("Genesis member name: {} value: {}".format(BibleBook.genesis.name,BibleBook.genesis.value))

for bibleBook in BibleBook:
    print("name: {:15} value {:2}".format(bibleBook.name, bibleBook.value))
    