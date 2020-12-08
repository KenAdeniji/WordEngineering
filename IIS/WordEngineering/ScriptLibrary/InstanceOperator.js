/*
	2015-10-11	Created.	shop.oreilly.com/product/9780596805531.do
*/
var InstanceOfOperator =
{
	stub: function() {
		var d = new Date();  // Create a new object with the Date() constructor
		d instanceof Date;   // Evaluates to true; d was created with Date()
		d instanceof Object; // Evaluates to true; all objects are instances of Object
		d instanceof Number; // Evaluates to false; d is not a Number object
		var a = [1, 2, 3];   // Create an array with array literal syntax
		a instanceof Array;  // Evaluates to true; a is an array
		a instanceof Object; // Evaluates to true; all arrays are objects
		a instanceof RegExp; // Evaluates to false; arrays are not regular expressions
	}	
}

InstanceOfOperator.stub();
