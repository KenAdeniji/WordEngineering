/*
export word = "word";

export function nullishCoalescing(first, second)
{
	return first ?? second;
}
*/

var module20241219 =	//2024-12-19T09:30:00
{
	//Return first value, or second value if first value is null or undefined.
	nullishCoalescing: function(first, second)
	{
		return first ?? second;
	}
	,
	
	//Operators to assign a value to a variable based on its own truthy/falsy status.
	logicalAssignment: function
	(
		willTargetTuesdayDecemberThirtyFirst
	)
	{
		willTargetTuesdayDecemberThirtyFirst ||= new Date(2024, 11, 31);
		return willTargetTuesdayDecemberThirtyFirst;
	},
	
	//2024-12-19T16:48:00 	replace all instance of a string http://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/replaceAll
	//2024-12-19T17:03:00	How will I replicate whom?
	replaceAllInstancesOfAString: function
	(
		original,
		pattern,
		replacement
	)
	{
		return original.replaceAll(pattern, replacement);
	},
	
}	
