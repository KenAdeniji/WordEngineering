/*
define([
    'book'
], function(book) {
    return {
        listBook: function() {
            alert(book.title);
        }
    };
});
*/

define([
    'model/book'
], function(Book) {
    var books = [
        new Book('A Tale of Two Cities', 'Chapman & Hall'),
        new Book('The Good Earth', 'John Day')
    ];

    return {
        // Notice I’ve changed listBook() to listBooks() now that
        // I am dealing with multiple books.  
        listBooks: function() {
            for (var i = 0, ii = books.length; i < ii; i++) {
                alert(books[i].title);
            }
        }
    };
});
