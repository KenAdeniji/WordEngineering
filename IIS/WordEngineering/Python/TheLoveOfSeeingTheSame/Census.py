'''
	2023-02-11T09:32:00 Created.
	2023-02-11T18:22:00	http://stackoverflow.com/questions/60208/replacements-for-switch-statement-in-python
	print(firstCensusReuben)
	print(len(censuses))
'''
import StringHelper

class Census:
    def __init__(self, iteration, tribe, population, scriptureReference):
        self.iteration = iteration
        self.tribe = tribe
        self.population = population
        self.scriptureReference = scriptureReference
        censuses.append(self)

    def __str__(self):
        return StringHelper.positionTitle(self.iteration) + " " + self.tribe + " " + str(self.population) + " (" + str(self.scriptureReference) + ")"

if __name__ == '__main__':
	censuses = []
	firstCensusReuben = Census(1, "Reuben", 46500, "Numbers 1:21")
	firstCensusSimeon = Census(1, "Simeon", 59300, "Numbers 1:23")
	firstCensusGad = Census(1, "Gad", 45650, "Numbers 1:25")
	firstCensusJudah = Census(1, "Judah", 74600, "Numbers 1:27")
	firstCensusIssachar = Census(1, "Issachar", 54400, "Numbers 1:29")
	