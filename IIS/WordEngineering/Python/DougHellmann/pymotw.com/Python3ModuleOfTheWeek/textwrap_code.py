#2019-08-19	https://pymotw.com/3/textwrap/index.html
import textwrap
from textwrap_example import sample_text

#The results are something less than desirable. The text is now left justified, but the first line retains its indent and the spaces from the front of each subsequent line are embedded in the paragraph.
print(textwrap.fill(sample_text, width=50))

dedented_text = textwrap.dedent(sample_text)
print('Dedented:')
print(dedented_text)

dedented_text = textwrap.dedent(sample_text).strip()
for width in [45, 60]:
    print('{} Columns:\n'.format(width))
    print(textwrap.fill(dedented_text, width=width))
    print()
	
dedented_text = textwrap.dedent(sample_text)
wrapped = textwrap.fill(dedented_text, width=50)
wrapped += '\n\nSecond paragraph after a blank line.'
final = textwrap.indent(wrapped, '> ')

print('Quoted block:\n')
print(final)
