'''
	2023-02-11T09:32:00 Created.
	2023-02-11T18:22:00	http://stackoverflow.com/questions/60208/replacements-for-switch-statement-in-python
	print(firstCensusReuben)
	print(len(censuses))
	Numbers 1:46 six hundred thousand and three thousand and five hundred and fifty 603550
	2023-02-12T12:50:00	http://markheath.net/post/python-equivalents-of-linq-methods
	2023-02-12T12:50:00	http://stackoverflow.com/questions/12734839/linq-like-sum-function-in-python/12734852
	2023-02-12T13:13:00	http://stackoverflow.com/questions/22895791/python-code-for-sum-with-condition
	2023-02-12T18:02:00	https://stackoverflow.com/questions/72883970/how-to-print-the-contents-of-an-array-line-by-line-in-a-text-file
	Numbers 26:51	Second census: six hundred thousand and a thousand seven hundred and thirty 601730
	2023-02-13T12:08:00	http://stackoverflow.com/questions/403421/how-to-sort-a-list-of-objects-based-on-an-attribute-of-the-objects
	2023-02-13T12:09:00	http://wiki.python.org/moin/HowTo/Sorting#Sortingbykeys
	2023-02-13T19:23:00	The author prefers to store the first and second census in 1 array but separated. Because of time differences.
	2023-03-21T17:49:00	... 2023-03-21T18:13:00
						http://github.s3.amazonaws.com/downloads/diveintomark/diveintopython3/dive-into-python3.pdf?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIA5BA2674WEWV2CIOD%2F20230318%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20230318T020658Z&X-Amz-Expires=300&X-Amz-SignedHeaders=host&X-Amz-Signature=efc66dc348eee2db537cd2064f19552950b3c37fd30b1b20b97e94ad20e7220c
						You can use any Python expression in a list comprehension. 3.3. LIST COMPREHENSIONS
						Previous search on google.com and stackoverflow.com futile Language Integrated Query (Linq).
	censusPopulationBetween60000And70000 = [census for census in Census.censuses if census.population > 60000 and census.population < 70000] 
	Census.dumpLog(censusPopulationBetween60000And70000)
'''
import StringHelper

class Census:
    censuses = []
	
    def __init__(self, iteration, sequence, tribe, population, scriptureReference):
        self.iteration = iteration
        self.sequence = sequence
        self.tribe = tribe
        self.population = population
        self.scriptureReference = scriptureReference
        Census.censuses.append(self)

    def __str__(self):
        return StringHelper.positionTitle(self.iteration) + " " + str(self.sequence) + " " + self.tribe + " " + str(self.population) + " (" + (self.scriptureReference) + ")"

    def buildHTML(censusList = censuses):
        resultSet = "<table border='1'><thead><caption>Census</caption>"
        resultSet += "<tr><th>Iteration</th><th>Sequence</th><th>Tribe</th><th>Population</th><th>Scripture Reference</th></tr>"
        resultSet += "</thead><tbody>"
        for census in censusList:
            resultSet += f'<tr><td>{StringHelper.positionTitle(census.iteration)}</td><td>{str(census.sequence)}</td><td>{census.tribe}</td><td>{census.population}</td><td>{census.scriptureReference}</td></tr>'
        resultSet += "</tbody></table>"

        resultSet += "<table border='1'><thead><caption>Summary</caption></thead><tbody>"

        resultSet += f"<tr><td>First Census population (Numbers 1:46)</td><td>{sum(x.population for x in Census.censuses if x.iteration == 1)}</td></tr>"
        resultSet += f"<tr><td>First Census population - Joseph's offsprings (Numbers 1:32-35)</td><td>{sum(x.population for x in Census.censuses if x.iteration == 1 and x.tribe in ('Ephraim', 'Manasseh'))}</td></tr>"

        resultSet += f"<tr><td>Second Census population (Numbers 26:51)</td><td>{sum(x.population for x in Census.censuses if x.iteration == 2)}</td></tr>"
        resultSet += f"<tr><td>Second Census population - Joseph's offsprings (Numbers 26:28-37)</td><td>{sum(x.population for x in Census.censuses if x.iteration == 2 and x.tribe in ('Ephraim', 'Manasseh'))}</td></tr>"

        resultSet += f"<tr><td>Censuses population (Numbers 1:46, Numbers 26:51)</td><td>{sum(x.population for x in Census.censuses)}</td></tr>"
        resultSet += f"<tr><td>Censuses population - Joseph's offsprings (Numbers 1:32-35, Numbers 26:28-37)</td><td>{sum(x.population for x in Census.censuses if x.tribe in ('Ephraim', 'Manasseh'))}</td></tr>"

        resultSet += "</tbody></table>"
        return resultSet
		
    def dumpLog(censusList = censuses):
        for census in censusList:
            print(str(census))
			
    def populate():			
        firstCensusReuben = Census(1, 1, "Reuben", 46500, "Numbers 1:21")
        firstCensusSimeon = Census(1, 2, "Simeon", 59300, "Numbers 1:23")
        firstCensusGad = Census(1, 3, "Gad", 45650, "Numbers 1:25")
        firstCensusJudah = Census(1, 4, "Judah", 74600, "Numbers 1:27")
        firstCensusIssachar = Census(1, 5, "Issachar", 54400, "Numbers 1:29")
        firstCensusZebulun = Census(1, 6, "Zebulun", 57400, "Numbers 1:31")
        firstCensusEphraim = Census(1, 7, "Ephraim", 40500, "Numbers 1:33")
        firstCensusManasseh = Census(1, 8, "Manasseh", 32200, "Numbers 1:35")
        firstCensusBenjamin = Census(1, 9, "Benjamin", 35400, "Numbers 1:37")
        firstCensusDan = Census(1, 10, "Dan", 62700, "Numbers 1:39")
        firstCensusAsher = Census(1, 11, "Asher", 41500, "Numbers 1:39")
        firstCensusNaphtali = Census(1, 12, "Naphtali", 53400, "Numbers 1:41")

        secondCensusReuben = Census(2, 1, "Reuben", 43730, "Numbers 26:7")
        secondCensusSimeon = Census(2, 2, "Simeon", 22200, "Numbers 26:14")
        secondCensusGad = Census(2, 3, "Gad", 40500, "Numbers 26:18")
        secondCensusJudah = Census(2, 4, "Judah", 76500, "Numbers 26:22")
        secondCensusIssachar = Census(2, 5, "Issachar", 64300, "Numbers 26:25")
        secondCensusZebulun = Census(2, 6, "Zebulun", 60500, "Numbers 26:27")
        secondCensusManasseh = Census(2, 7, "Manasseh", 52700, "Numbers 26:34")
        secondCensusEphraim = Census(2, 8, "Ephraim", 32500, "Numbers 26:37")
        secondCensusBenjamin = Census(2, 9, "Benjamin", 45600, "Numbers 26:41")
        secondCensusDan = Census(2, 10, "Dan", 64400, "Numbers 26:43")
        secondCensusAsher = Census(2, 11, "Asher", 53400, "Numbers 26:47")
        secondCensusNaphtali = Census(2, 12, "Naphtali", 45400, "Numbers 26:50")
		
if __name__ == '__main__':
	Census.populate()
	newlist = sorted(Census.censuses, key=lambda x: x.population, reverse=True)
	#Census.dumpLog(newlist)
	censusPopulationBetween60000And70000 = [census for census in Census.censuses if census.population > 60000 and census.population < 70000] 
	Census.dumpLog(censusPopulationBetween60000And70000)