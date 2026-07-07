'''
2026-07-06T18:51:00 http://www.w3schools.com/python/pandas/ref_df_query.asp
'''

import pandas as pd

data = {
    "bookID": [1, 27, 40, 66],
    "bookTitle": ["Genesis", "Daniel", "Matthew", "Revelation"],
    "author": ["Moses", "Daniel", "Matthew", "Apostle John"],
    "genre": ["Pentateuch", "Apocalyptic", "Gospel", "Apocalyptic"]
}

df = pd.DataFrame(data)

print(df.query("genre == 'Apocalyptic'")) 
