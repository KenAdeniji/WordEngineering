#"""
#2019-10-24  Created.
#            https://nbviewer.jupyter.org/github/jrjohansson/numerical-python-book-code/blob/master/ch01-code-listing.ipynb
#            https://scipy.org/install.html
#                 python -m pip install --user numpy scipy matplotlib ipython jupyter pandas sympy nose
#            c:\Users\kadeniji\AppData\Roaming\Python\Python37\Scripts
#"""

class HTMLDisplayer(object):
    def __init__(self, code):
        self.code = code
    
    def _repr_html_(self):
        return self.code
    
from IPython.display import display, Image, HTML, Math
Image(url='http://python.org/images/python-logo.gif')

from IPython.core.display import display, HTML
display(HTML('<h1>Hello, world!</h1>'))

import scipy, numpy, matplotlib
modules = [numpy, matplotlib, scipy]
row = "<tr> <td>%s</td> <td>%s</td> </tr>"
rows = "\n".join([row % (module.__name__, module.__version__) for module in modules])
s = "<table> <tr><th>Library</th><th>Version</th> </tr> %s</table>" % rows
HTML(s)
#print(s)
#HTMLDisplayer(s)

