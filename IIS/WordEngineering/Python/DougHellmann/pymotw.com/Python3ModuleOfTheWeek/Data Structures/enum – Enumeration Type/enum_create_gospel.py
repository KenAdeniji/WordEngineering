#2019-08-30 https://pymotw.com/3/enum/index.html
import enum

"""
Members with repeated values trigger a ValueError exception when the Enum class is being interpreted.
@enum.unique
"""
class GospelBook(enum.IntEnum):
	#canonical
	matthew = 40
	mark = 41
	luke = 42
	john = 43
	#alias
	firstBookInTheNewTestament = 40
	firstBookByLuke = 42

print('\nMember name: {}'.format(GospelBook.firstBookInTheNewTestament.name))
print('Member value: {}'.format(GospelBook.firstBookInTheNewTestament.value))
	
for book in GospelBook:
    print('{:15} = {}'.format(book.name, book.value))
	
print('Ordered by value:')
print('\n'.join('  ' + s.name for s in sorted(GospelBook)))	