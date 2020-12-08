/*
	2015-10-11	Created.	shop.oreilly.com/product/9780596805531.do
*/
var DeleteOperator =
{
	stub: function() {
var o = { x: 1, y: 2}; // Start with an object
delete o.x;            // Delete one of its properties
"x" in o               // => false: the property does not exist anymore
var a = [1,2,3];       // Start with an array
delete a[2];           // Delete the last element of the array
a.length               // => 2: array only has two elements now		
	}	
}

DeleteOperator.stub();
