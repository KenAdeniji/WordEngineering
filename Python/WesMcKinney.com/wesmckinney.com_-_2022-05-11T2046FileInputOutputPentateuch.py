#https://wesmckinney.com/book/accessing-data.html
import numpy as np
import pandas as pd #pip install pandas

dataframeBibleBookIDTitleChapterVerse = pd.read_csv("wesmckinney.com_-_2022-05-11T2046BibleBookIDTitleChapterVerse.txt")
print(dataframeBibleBookIDTitleChapterVerse) #2022-05-11T20:46:00

dataframeJSON = pd.read_json("BibleBook.Json.txt") #2022-05-12T17:23:00
print(dataframeJSON)