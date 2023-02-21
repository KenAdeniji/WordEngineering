"""
2022-11-05T18:00:00 Created. https://allendowney.github.io/ElementsOfDataScience/03_arrays.html
"""
if __name__ == '__main__':
    import sys;
    import pandas as pd;
    import numpy as np;
    major_prophets_chapters_list = [66, 52, 48, 12];
    major_prophets_chapters_array = np.array(major_prophets_chapters_list);
    gospel_chapters_list = [28, 16, 24, 21];
    gospel_chapters_array = np.array(gospel_chapters_list);
    difference_chapters_array = major_prophets_chapters_array - gospel_chapters_array;
    print(f'major_prophets_chapters_array {major_prophets_chapters_array} gospel_chapters_array {gospel_chapters_array} difference_chapters_array {difference_chapters_array}');
    print(f'major_prophets_chapters_array mean {np.mean(major_prophets_chapters_array)} gospel_chapters_array meab {np.mean(gospel_chapters_array)}');	