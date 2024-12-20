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
	//2024-12-19T17:28:00	We are coming to a time... after ourself.
	//2024-12-19T10:00:00 	phoebe.hsukeim@promab.com My daughter is Jewish.
	//businessinsider.com/bill-gates-internet-predictions-2015-12#content-created-for-the-internet-would-be-just-as-big-a-moneymaker-as-tv-1 On January 3, 1996, Microsoft CEO Bill Gates wrote an essay titled "Content is King" in which he made a number of bold predictions for what the internet would look like in the future.
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
