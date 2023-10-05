/*
https://javascript.info/testing-mocha
*/
describe
(
	"validateBibleBook", function() 
	{
		describe
		(
			"retrieve validateBibleBook",
			function()
			{

				function makeTest(bookID) 
				{
					let expected;

					switch (bookID)
					{
						case 1: expected = "Genesis"; break;
						case 2: expected = "Exodus"; break;
						case 3: expected = "Leviticus"; break;
						case 4: expected = "Numbers"; break;
						case 5: expected = "Deuteronomy"; break;
					}		

					it(`${bookID} in the BookTitle is ${expected}`, function()
					{
						assert.equal(validateBibleBook(bookID), expected);
					});
				}
			
				for (let bookIndex = -1; bookIndex <= 6; bookIndex++)
				{
					makeTest(bookIndex);
				}
			}
		);	

		it("if n is negative, the result is NaN", function() 
		{
			assert.isNaN(validateBibleBook(1));
		});

		it("if n is not integer, the result is NaN", function() {
			assert.isNaN(validateBibleBook(1.5));
		});
	}
);
