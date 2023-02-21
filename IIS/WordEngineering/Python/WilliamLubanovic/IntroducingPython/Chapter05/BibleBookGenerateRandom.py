def get_description():# see the docstring below?
	"""Return random book"""
	from random import choice
	possibilities=['John','1 John','2 John','3 John','Revelation']
	return choice(possibilities)