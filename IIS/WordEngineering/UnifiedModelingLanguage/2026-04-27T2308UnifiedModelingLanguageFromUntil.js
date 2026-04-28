/*
	2026-04-27T23:08:00 File created.
	2026-01-22T19:38:00	http://www.objectplayground.com
	2026-01-22T21:25:00	http://stackoverflow.com/questions/52377344/javascript-array-of-instances-of-a-class
	2026-04-27T23:53:00
		google.com
		Daniel 9:25
		kjv verse from until messiah nagid
Bible Gateway
http://www.biblegateway.com verse
From the issuing of the decree to restore and rebuild Jerusalem until an Anointed One, the ruler, will be seven weeks and sixty-two weeks.
	2026-04-28T00:45:00
		bibleTimes
*/
class FromUntil {
	constructor(titled, from, until, scriptureReference, url) {
		this.titled = titled;
		this.from = from;
		this.until = until;
		this.scriptureReference = scriptureReference;
		this.url = url;
	}
	get bibleTimes() {
		var daysSpan = Math.round( ( this.until - this.from ) / ( 3600 * 24 * 1000 ) );
		var biblicalYears = Math.round( (daysSpan / 360) );
		var biblicalMonths = Math.round ( ( daysSpan - biblicalYears * 360 ) / 30 );
		var biblicalDays = ( ( daysSpan - biblicalYears * 360 - biblicalMonths * 30 ) % 30 );
		var filler = "";

		switch ( biblicalYears )
		{
			case 0:
				break;
			case 1: 
				filler += "1 Biblical year";
				break;
			default:	
				filler += biblicalYears + " Biblical years";
				break;
		}
		
		if ( filler !== "" && biblicalMonths !== 0 )
		{
			filler += ", ";
		}
		
		{	
			switch ( biblicalMonths )
			{
				case 0: 
					break;
				case 1: 
					filler += "1 Biblical month";
					break;
				default:	
					filler += biblicalMonths + " Biblical months";
					break;
			}
		}

		if ( filler !== "" && biblicalDays !== 0 )
		{
			filler += ", ";
		}
		
		{	
			switch ( biblicalDays )
			{
				case 0: 
					break;
				case 1: 
					filler += "1 Biblical day";
					break;
				default:	
					filler += biblicalDays + " Biblical days";
					break;
			}
		}

		return ( filler );
	}
}

this.fromUntil = [
	new FromUntil
	(
		"Know therefore and understand, that from the going forth of the commandment to restore and build Jerusalem unto Messiah the Prince shall be seven weeks, threescore and two weeks: the street shall be built again, and the wall, even in troublous times.",
		new Date(-445, 02, 14),
		new Date("0032-03-06"),
		"Daniel 9:25",
		"WhatSaithTheScripture.com/Voice/The.Coming.Prince.html"
	),
	new FromUntil
	(
		"Resurrection of Jesus Christ",
		new Date("0032-03-04"),
		new Date("0032-03-06"),
		"Daniel 9:25",
		"WhatSaithTheScripture.com/Voice/The.Coming.Prince.html"
	),
];

console.log(this.fromUntil);
console.log(this.fromUntil[1].bibleTimes);