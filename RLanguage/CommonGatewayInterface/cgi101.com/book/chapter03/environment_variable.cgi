#!/perl64/bin/perl -wT
use CGI qw(:standard);
use CGI::Carp qw(warningsToBrowser fatalsToBrowser);
use strict;

#2016-01-07	http://www.cgi101.com/book/ch3/text.html

print header;
print start_html("Environment");

foreach my $key (sort(keys(%ENV))) {
    print "$key = $ENV{$key}<br>\n";
}
print end_html;
