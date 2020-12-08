/*
	2018-08-17	Created.	http://goalkicker.com/JavaScriptBook
*/

var goalKickerJavascript =
{
	addWorkDays: function(startDate, days)
	{
		//Get the day of the week as a number (0 = Sunday, 1 = Monday, 6 = Saturday
		var dow = startDate.getDay();
		var daysToAdd = days;
		//If the current day is Sunday, add one day
		if (dow == 0)
		{	
			daysToAdd++;
		}	
		//If the start date plus the additional days falls on or after the closest calculate weekends
		if (dow + daysToAdd >= 6)
		{
			//Subtract days in current working week from work days
			var remainingWorkDays = daysToAdd - (5 - dow);
			//Add current working week's weekend
			daysToAdd += 2;
			if (remainingWorkDays > 5)
			{
				//Add two days for each working week by calculating how many weeks are included
				daysToAdd += 2 * Math.floor(remainingWorkDays / 5);
				//Exclude final weekend if remainingWorkDays resolves to an exact number of weeks
				if (remainingWorkDays % 5 == 0)
				{
					daysToAdd -= 2;
				}	
			}	
		}	
		startDate.setDate(startDate.getDate() + daysToAdd);
		return startDate;
	},

	deepReverse: function(arr)
	{  
		arr.reverse().forEach
		(
			elem => 
			{
				if(Array.isArray(elem)) 
				{ 
					goalKickerJavascript.deepReverse(elem);
				}
			}
		);
		return arr; 
	},

	fileExists: function(dir, successCallback, errorCallback) 
	{    
		var xhttp = new XMLHttpRequest;
		/* Check the status code of the request */
		xhttp.onreadystatechange = function()
		{ 
			return (xhttp.status !== 404) ? successCallback : errorCallback;    
		};
		/* Open and send the request */   
		xhttp.open('head', dir, false);
		xhttp.send(); 
	}, 
	
	mergeTwoArrayAsKeyValuePair: function(rows, columns)
	{
		var result =  rows.reduce
		(
			function(result, field, index) 
			{  
				result[columns[index]] = field;
				return result; 
			},
			{}
		);
		return result;	
	},	

	power: function(leftOperand, rightOperand)
	{
		return (leftOperand ** rightOperand);
	},
	
	randomBetween: function(min, max)
	{    
		return Math.floor(Math.random() * (max - min + 1) + min); 
	},
	
	sortCompare: function(entries, sortOrder)
	{
		entries.sort(function(a, b) 
		{    
			return a.localeCompare(b);
		});
		if (sortOrder == 1)
		{	
			entries.reverse();
		}	
		return entries;
	},	
	strcmp: function(a, b) 
	{
		if(a === b) { return 0; }
		if (a > b) { return 1; }
		return -1; 
	}
};

