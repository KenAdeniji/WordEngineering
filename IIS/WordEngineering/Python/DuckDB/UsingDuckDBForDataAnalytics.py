"""
2023-05-15T07:50:00 ... 2023-05-15T08:23:00
http://codemag.com/Article/2305071/Using-DuckDB-for-Data-Analytics

Using DuckDB for Data Analytics

By Wei-Meng Lee
Published in: CODE Magazine: 2023 - May/Jun
Last updated: May 3, 2023
http://www.kaggle.com/datasets/teertha/ushealthinsurancedataset?resource=download

pip install duckdb
pip install seaborn

2023-05-16T18:23:00 SQL, database engine.
2023-05-16T18:23:00 ... 2023-05-16T19:04:00 Change from querying http://www.kaggle.com/datasets/teertha/ushealthinsurancedataset?resource=download to BibleBook.csv
"""

import pandas as pd

import duckdb

df_BibleBook = pd.read_csv("BibleBook.csv")
print(df_BibleBook)

conn = duckdb.connect()
conn.register("BibleBook", df_BibleBook)

conn = duckdb.connect()

df = conn.execute(''' 
    SELECT 
      * 
    FROM read_csv_auto('BibleBook.csv') 
''').df()

conn.register("BibleBook", df)

print(conn.execute('SHOW TABLES').df())

df = conn.execute(
         "SELECT * FROM BibleBook").df()
print(df)

import seaborn as sns
import matplotlib.pyplot as plt
f, ax = plt.subplots(1, 1, figsize=(5, 3))
df = conn.execute('''
    SELECT 
        *        
    FROM BibleBook
''').df()

ax = sns.barplot(x = 'bookTitle', 
                 y = 'chapters', 
                 hue = 'testament', 
                 data = df, 
                 palette = 'cool', 
                 errorbar = None)

plt.show()

