SELECT  
	ROW_NUMBER() OVER(ORDER BY Dated ASC) AS Row#,
	Dated,
	WorkEmail
FROM  EmailAddress
WHERE workemail like '%Judge.com%'
ORDER BY dated ASC

