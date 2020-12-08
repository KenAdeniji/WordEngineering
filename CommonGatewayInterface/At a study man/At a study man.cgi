#!/perl64/bin/perl -wT
use CGI qw(:standard);
use CGI::Carp qw(warningsToBrowser fatalsToBrowser);
use strict;

#2016-01-07	At a study man.	http://www.cgi101.com/book/ch3/text.html

print header;
print start_html("At a study man");

my %form;
foreach my $p (param()) {
    $form{$p} = param($p);
#    print "$p = $form{$p}<br>\n";
}

my $bookIDFrom = param('bookIDFrom');
my $bookIDUntil = param('bookIDUntil');
my $bookTitle = param('bookTitle');

my @bibleBooks = 
(
"Genesis",
"Exodus",
"Leviticus",
"Numbers",
"Deuteronomy",
"Joshua",
"Judges",
"Ruth",
"1 Samuel",
"2 Samuel",
"1 Kings",
"2 Kings",
"1 Chronicles",
"2 Chronicles",
"Ezra",
"Nehemiah",
"Esther",
"Job",
"Psalms",
"Proverbs",
"Ecclesiastes",
"Song of Solomon",
"Isaiah",
"Jeremiah",
"Lamentations",
"Ezekiel",
"Daniel",
"Hosea",
"Joel",
"Amos",
"Obadiah",
"Jonah",
"Micah",
"Nahum",
"Habakkuk",
"Zephaniah",
"Haggai",
"Zechariah",
"Malachi",
"Matthew",
"Mark",
"Luke",
"John",
"Acts",
"Romans",
"1 Corinthians",
"2 Corinthians",
"Galatians",
"Ephesians",
"Philippians",
"Colossians",
"1 Thessalonians",
"2 Thessalonians",
"1 Timothy",
"2 Timothy",
"Titus",
"Philemon",
"Hebrews",
"James",
"1 Peter",
"2 Peter",
"1 John",
"2 John",
"3 John",
"Jude",
"Revelation"
);

my $booksCount = @bibleBooks;

my @results = grep(/$bookTitle/,@bibleBooks);

for (my $bookID = $bookIDFrom; $bookID <= $booksCount; $bookID++)
{
	if ($bookID < $bookIDFrom) { next; } #continue
	if ($bookID > $bookIDUntil) { last; } #break
	my $currentBook = @bibleBooks[$bookID - 1];
	if (index(uc $currentBook, uc $bookTitle) == -1) { next; } #continue
	print "[", $bookID, "] ", $currentBook, "<br>\n";
}

print end_html;
