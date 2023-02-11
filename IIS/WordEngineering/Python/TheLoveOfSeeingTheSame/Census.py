'''
	2023-02-11T09:32:00 Created.
'''
import StringHelper

class Census:
    def __init__(self, iteration, tribe, population):
        self.iteration = iteration
        self.tribe = tribe
        self.population = population

    def __str__(self):
        return StringHelper.positionTitle(self.iteration) + " " + self.tribe + " " + str(self.population)

if __name__ == '__main__':
	firstCensusJudah = Census(1, "Judah", 74600)
	print(firstCensusJudah)
