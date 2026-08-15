# 2026-08-14    http://pymotw.com/3/textwrap/index.html
import textwrap

sample_text = '''2004-11-10 
www.JesusInTheLamb.com 
Walking in the Lamb, you shall follow Me. 
    '''
width_priesthood_age = 30

print(textwrap.fill(sample_text, width_priesthood_age))