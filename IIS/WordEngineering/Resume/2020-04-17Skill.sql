SELECT        
	--Minor + ' ' + Commentary AS SkillSet
	'<tr><td data-since="' +  Commentary + '">' + Minor + '</td></tr>'                           
FROM  WordEngineering..ActToGod
where major like '%Skill%'
ORDER BY Minor
