SELECT Dated, Word, Commentary FROM AlphabetSequence WHERE Word LIKE '%Donut%' OR Commentary LIKE '%Donut%'
SELECT Dated, Commentary FROM Dream WHERE Commentary LIKE '%Donut%'
SELECT Dated, Commentary FROM Event WHERE Commentary LIKE '%Donut%'

/*
2004-11-21 00:00:00.000 Entenmann's P.O. Box 535 Totowa NJ 07511-0535 quality since 1898 CT Lic. 3119 E495N1-GDH E-E495N1-GDH-01343-05 RACH3197 Little Bites Donut Holes Glazed 5 Pouches Net WT 9.2 OZ (261g) 0 71030 01343 5
*/
SELECT Dated, Commentary FROM CaseBasedReasoning WHERE Commentary LIKE '%Donut%'

/*
2003-07-23 00:00:00.000
*/
--SELECT MIN(Dated) FROM TheWord

/*
2002-12-03 00:00:00.00
*/
--SELECT MIN(Dated) FROM AlphabetSequence

--INSERT Event(Dated,Commentary) VALUES('20030101','The only serving at a restaurant are 2 chicken wings, when I asked the waiteress for the corn bread, the waiteress says the Italians have already the donut, and only the chicken wings are available') 
--INSERT CaseBasedReasoning(Dated,Commentary) VALUES('20030101','The only serving at a restaurant are 2 chicken wings, when I asked the waiteress for the corn bread, the waiteress says the Italians have already the donut, and only the chicken wings are available') 
--INSERT Dream(Dated,Commentary) VALUES('20030101','The only serving at a restaurant are 2 chicken wings, when I asked the waiteress for the corn bread, the waiteress says the Italians have already the donut, and only the chicken wings are available') 