#2026-08-16    http://pymotw.com/3/enum/index.html
"""
    2026-08-16T13:24:00 WordEngineering database, Software table? Not original work.
    2026-08-16T13:24:00 Now... the Devil... was more subtil...
        Genesis 3:1, 2 Samuel 13:3
    2026-08-16T13:45:00 urine
    2026-08-16T13:52:00...2026-08-16T13:56:00
Processed 30280 pages for database 'WordEngineering', file 'WordEngineering_Data' on file 1.
Processed 104 pages for database 'WordEngineering', file 'WordEngineering_Index' on file 1.
Processed 16 pages for database 'WordEngineering', file 'WordEngineering_Text' on file 1.
Processed 16 pages for database 'WordEngineering', file 'WordEngineering_Xml' on file 1.
Processed 16 pages for database 'WordEngineering', file 'WordEngineering_Image' on file 1.
Processed 2 pages for database 'WordEngineering', file 'WordEngineering_Log' on file 1.
BACKUP DATABASE successfully processed 30434 pages in 1.491 seconds (159.464 MB/sec).
Processed 30224 pages for database 'WordEngineering', file 'WordEngineering_Data' on file 1.
Processed 104 pages for database 'WordEngineering', file 'WordEngineering_Index' on file 1.
Processed 16 pages for database 'WordEngineering', file 'WordEngineering_Text' on file 1.
Processed 16 pages for database 'WordEngineering', file 'WordEngineering_Xml' on file 1.
Processed 16 pages for database 'WordEngineering', file 'WordEngineering_Image' on file 1.
Processed 2 pages for database 'WordEngineering', file 'WordEngineering_Log' on file 1.
Msg 3009, Level 16, State 1, Line 2
Could not insert a backup or restore history/detail record in the msdb database. This may indicate a problem with the msdb database. The backup/restore operation was still successful.
BACKUP DATABASE successfully processed 30378 pages in 1.814 seconds (130.829 MB/sec).
Msg 802, Level 17, State 2, Line 2
There is insufficient memory available in the buffer pool.

Completion time: 2026-08-16T13:56:16.0899391-07:00
    
"""
import enum

class BibleBook(enum.IntEnum): #BibleBook(enum.Enum):
    genesis = 1
    matthew = 40
    revelation = 66
    
print("Genesis member name: {} value: {}".format(BibleBook.genesis.name,BibleBook.genesis.value))

for bibleBook in BibleBook:
    print("name: {:15} value {:2}".format(bibleBook.name, bibleBook.value))

print("Ordered by value:")
print("\n".join("  name:" + bibleBook.name + "  value:  " + str(bibleBook.value) for bibleBook in sorted(BibleBook)))