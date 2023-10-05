/*
define({
    title: "My Sister's Keeper",
    publisher: "Atria"
});
*/

define(function() {
    var Book = function(title, publisher) {
        this.title = title;
        this.publisher = publisher;
    };
    return Book;
});
