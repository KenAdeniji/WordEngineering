/*
	2015-10-08	Created.	shop.oreilly.com/product/9780596805531.do
*/
var ArrayLibrary =
{
	copyArray: function(a, b) {
		for(var i = 0; i < a.length; i++)		// For each index of a[]
			b[i] = a[i];						// Copy an element of a into b
	},
	
	equalArrays: function(a, b) {
		if (a.length != b.length) return false; // Different-size arrays not equal
		for(var i = 0; i < a.length; i++)       // Loop through all elements
			if (a[i] !== b[i]) return false;    // If any differ, arrays not equal
		return true;                            // Otherwise they are equal
	},

	stub: function() {
		var firstArray = [3, 5, 2];
		var secondArray = [3, 5, 1];
		var checkEqual = this.equalArrays(firstArray, secondArray);
		console.log(checkEqual);
		
		this.copyArray(firstArray, secondArray);
		var checkEqual = this.equalArrays(firstArray, secondArray);
		console.log(checkEqual);
	}		
}

ArrayLibrary.stub();
