#2019-08-30 https://pymotw.com/3/enum/index.html
import enum

"""
Members with repeated values trigger a ValueError exception when the Enum class is being interpreted.
@enum.unique
"""
PentateuchBook = enum.IntEnum(
    value='PentateuchBook',
    names=[
		('Genesis', 1),
		('Exodus', 2),
		('Leviticus', 3),
		('Numbers', 4),
		('Deuteronomy', 5),
	],	
)

print('\nMember name: {}'.format(PentateuchBook.Leviticus.name))
print('Member value: {}'.format(PentateuchBook.Leviticus.value))
	
for book in PentateuchBook:
    print('{:15} = {}'.format(book.name, book.value))
	
print('Ordered by value:')
print('\n'.join('  ' + s.name for s in sorted(PentateuchBook)))	
