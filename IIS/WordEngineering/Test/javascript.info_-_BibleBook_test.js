/*
https://javascript.info/testing-mocha
*/
describe("bibleBookTitle", function() {

  describe("retrieve bibleBookTitle", function() {

	var firstBookTitle = "Genesis";

    function makeTest(x) {
      let expected = "Genesis";
      it(`${x} in the firstBookTitle is ${expected}`, function() {
        assert.equal(firstBookTitle, expected);
      });
    }

    makeTest(1);
  });

  it("if n is negative, the result is NaN", function() {
    assert.isNaN(bibleBookTitle(1));
  });

  it("if n is not integer, the result is NaN", function() {
    assert.isNaN(bibleBookTitle(1.5));
  });

});