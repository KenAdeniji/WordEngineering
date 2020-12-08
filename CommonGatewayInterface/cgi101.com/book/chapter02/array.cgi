#!/perl64/bin/perl -wT
use CGI qw(:standard);
use CGI::Carp qw(warningsToBrowser fatalsToBrowser);
use strict;

#2016-01-07	http://www.cgi101.com/book/ch2/text.html
my @colors = ("red", "green", "blue");

print header;
print start_html("Arrays");
print <<EndHTML;
<h2>Hello</h2>
<p>
	$colors[0]
	$colors[1]
	$colors[2]
</p>
EndHTML

foreach my $i (@colors) {
	print $i;
}

my @people = ();
push(@people, "Howard");
push(@people, ("Sara", "Ken", "Josh"));
my $who = shift(@people);
my $who = pop(@people);

my $linelen = scalar(@people);

print "The last person in line is $people[$linelen-1].\n";
print "The last person in line is $people[$#people].\n";

my @colors = ("cyan", "magenta", "yellow", "black");
foreach my $i (0..$#colors) {
   print "color $i is $colors[$i]\n";
}

my @colors = ("cyan", "magenta", "yellow", "black");
my @slice = @colors[1..2];

#http://www.tutorialspoint.com/perl/perl_grep.htm
my @list = (1,"Test", 0, "foo", 20 );

my @has_digit = grep ( /\d/, @list );

print "@has_digit\n";

my @colors = ("cyan", "magenta", "yellow", "black");
my @colors2 = sort(@colors);

my @colors = ("cyan", "magenta", "yellow", "black");
@colors = reverse(sort(@colors));

my @colors = ("cyan", "magenta", "yellow", "black");
my $colorstring = join(", ",@colors);

#   Hash Name        key     value

    my %colors = (  "red",   "#ff0000",
                    "green", "#00ff00",
                    "blue",  "#0000ff",
                    "black", "#000000",
                    "white", "#ffffff" );
print end_html;
