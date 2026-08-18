#2026-08-17    http://pymotw.com/3/collections/chainmap.html
"""
    2026-08-17T23:01:00 Created.
"""
import collections

old_testament = {"Pentateuch": "Genesis, Exodus, Leviticus, Numbers, Deuteronomy", "Apocalyptic": "Daniel"}

new_testament = {"Gospel": "Matthew, Mark, Luke, John", "Apocalyptic": "Revelation"}

bible = collections.ChainMap(old_testament, new_testament)

print("Individual values")
print("Pentateuch: {}".format(bible["Pentateuch"]))
print("Gospel: {}".format(bible["Gospel"]))
print("Apocalyptic: {}".format(bible["Apocalyptic"])) #Only Old Testament printed.
print()
