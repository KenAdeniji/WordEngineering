﻿/*
	2015-10-10	Created.	shop.oreilly.com/product/9780596805531.do
*/
var InOperator =
{
	stub: function() {
		var point = { x:1, y:1 };  // Define an object
		console.log(point);
		"x" in point               // => true: object has property named "x"
		"z" in point               // => false: object has no "z" property.
		"toString" in point        // => true: object inherits toString method
		var data = [7,8,9];        // An array with elements 0, 1, and 2
		"0" in data                // => true: array has an element "0"
		1 in data                  // => true: numbers are converted to strings
		3 in data                  // => false: no element 3		
	}	
}

InOperator.stub();
