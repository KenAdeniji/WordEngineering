import numpy as np
import pandas as pd #pip install pandas

bibleBooksTitles = ['Genesis', 'Exodus', 'Leviticus', 'Numbers', 'Deuteronomy']
bibleBooksChapters = np.array([50, 40, 27, 36, 34]) #Bible books chapters
bibleBooksVerses = np.array([1533, 1213, 859, 1288, 959]) #Bible books verses

bibleBooksChaptersVerses = np.array([bibleBooksChapters, bibleBooksVerses]) #Bible books chapters and verses

bibleBooksChaptersWithLabels = pd.Series(bibleBooksChapters, index=bibleBooksTitles)
print(bibleBooksChaptersWithLabels['Leviticus'])
print(bibleBooksChaptersWithLabels[bibleBooksChapters >= 40])

averageBibleBooksChaptersVersesWithLabels = pd.Series(bibleBooksChapters / bibleBooksVerses, index=bibleBooksTitles)
print(averageBibleBooksChaptersVersesWithLabels)

bibleBooksData = { 'titles': bibleBooksTitles, 'chapters': bibleBooksChapters, 'verses': bibleBooksVerses }
bibleBooksDataFrame = pd.DataFrame(bibleBooksData)
print(bibleBooksDataFrame)

#2022-05-11T11:00:00 https://stackoverflow.com/questions/41286569/get-total-of-pandas-column
#2022-05-11T11:20:00 Where we overturn?
totalChapters = bibleBooksDataFrame['chapters'].sum()
print("Total Chapters: ", totalChapters, sum(bibleBooksDataFrame['chapters']))
