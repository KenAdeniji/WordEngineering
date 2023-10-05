"""
2022-11-04T06:17:00 Created. https://allendowney.github.io/ElementsOfDataScience/01_variables.html
2022-11-04T06:36:00	TabError: inconsistent use of tabs and spaces in indentation
2022-11-04T06:39:00
    print(f'Radius {radius} Area {22.0 / 7.0 * radius ** 2}')
                                                             ^
IndentationError: unindent does not match any outer indentation level
equatorial radius of Earth =
6378.1 kilometers. 
"""
if __name__ == '__main__':
    import sys
    for i in range(1, len(sys.argv)):
	    radius = float(sys.argv[i]); print(f'Radius {radius} Area {22.0 / 7.0 * radius ** 2} Circumference { (2 * (22.0 / 7.0)) * radius}')