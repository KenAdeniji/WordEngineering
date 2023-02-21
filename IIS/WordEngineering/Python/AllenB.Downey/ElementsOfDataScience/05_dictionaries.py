"""
2022-11-08T10:45:00 Created. https://allendowney.github.io/ElementsOfDataScience/05_dictionaries.html
"""
if __name__ == '__main__':
    import sys;
    bibleBookTitlesPentateuch = {'Genesis': 50, 'Exodus': 40, 'Leviticus': 27, 'Numbers':36, 'Deuteronomy':34}
    for key, value in bibleBookTitlesPentateuch.items():
        print(key, value)
