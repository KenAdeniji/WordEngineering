#https://wesmckinney.com/book/accessing-data.html
import numpy as np
import pandas as pd #pip install pandas

#type wesmckinney.com_-_2022-05-11T2046BibleBookIDTitleChapterVerse.txt
dataframeBibleBookIDTitleChapterVerse = pd.read_csv("wesmckinney.com_-_2022-05-11T2046BibleBookIDTitleChapterVerse.txt")
print(dataframeBibleBookIDTitleChapterVerse)
