#2026-08-17    http://pymotw.com/3/collections/chainmap.html
"""
    2026-08-17T23:01:00 Created.
    2026-08-17T23:51:00 Notice the duplicate... Apocalyptic
"""
import collections

old_testament = {"Pentateuch": "Genesis, Exodus, Leviticus, Numbers, Deuteronomy", "Apocalyptic": "Daniel"}

new_testament = {"Gospel": "Matthew, Mark, Luke, John", "Apocalyptic": "Revelation"}

bible = collections.ChainMap(old_testament, new_testament)

print("Individual values")
print("Pentateuch: {}".format(bible["Pentateuch"])) #Pentateuch: Genesis, Exodus, Leviticus, Numbers, Deuteronomy
print("Gospel: {}".format(bible["Gospel"])) #Gospel: Matthew, Mark, Luke, John
print("Apocalyptic: {}".format(bible["Apocalyptic"])) #Keys: ['Gospel', 'Apocalyptic', 'Pentateuch']
print()

print("Keys: {}".format(list(bible.keys()))) #Keys: ['Gospel', 'Apocalyptic', 'Pentateuch']
print("Values: {}".format(list(bible.values()))) #Values: ['Matthew, Mark, Luke, John', 'Daniel', 'Genesis, Exodus, Leviticus, Numbers, Deuteronomy']
print()

print("Items:")
for k, v in bible.items():
    print("{} = {}".format(k, v))
print()

#2026-08-18T05:56:03.4646693-07:00 Faeces. Check for key... not value.
print("'Revelation' in bible: {}".format(("Revelation" in bible))) #False
print("'Daniel' in bible: {}".format(("Daniel" in bible))) #False
print("'Apocalyptic' in bible: {}".format(("Apocalyptic" in bible))) #True

print("bible.maps")
print(bible.maps)
