'''
	2023-02-11T09:32:00 Created.
	2023-02-11T18:22:00	http://stackoverflow.com/questions/60208/replacements-for-switch-statement-in-python
	print(firstCensusReuben)
	print(len(censuses))
	Numbers 1:46 six hundred thousand and three thousand and five hundred and fifty 603550
	2023-02-12T12:50:00	http://markheath.net/post/python-equivalents-of-linq-methods
	2023-02-12T12:50:00	http://stackoverflow.com/questions/12734839/linq-like-sum-function-in-python/12734852
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
	firstCensusZebulun = Census(1, "Zebulun", 57400, "Numbers 1:31")
	firstCensusEphraim = Census(1, "Ephraim", 40500, "Numbers 1:33")
	firstCensusManasseh = Census(1, "Manasseh", 32200, "Numbers 1:35")
	firstCensusBenjamin = Census(1, "Benjamin", 35400, "Numbers 1:37")
	firstCensusDan = Census(1, "Dan", 62700, "Numbers 1:39")
	firstCensusAsher = Census(1, "Asher", 41500, "Numbers 1:39")
	firstCensusNaphtali = Census(1, "Naphtali", 53400, "Numbers 1:41")
	
	censusPopulation = sum(x.population for x in censuses)
	print("Census Population: ", censusPopulation)
