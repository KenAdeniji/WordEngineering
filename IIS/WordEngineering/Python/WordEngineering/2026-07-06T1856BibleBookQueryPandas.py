'''
2026-07-06T18:51:00 http://www.w3schools.com/python/pandas/ref_df_query.asp
http://github.com/KenAdeniji/WordEngineering/blob/main/IIS/WordEngineering/Python/WordEngineering/2026-07-06T1856BibleBookQueryPandas.py
2026-07-06T19:40:00 Technology... where are you?
    Technology will have to use artificial intelligence in-house, and build data centers.
    Daniel 11:32
    Urine, downstairs restroom, south-west.
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
