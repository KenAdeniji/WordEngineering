#!/perl64/bin/perl -wT
use CGI qw(:standard);
use CGI::Carp qw(warningsToBrowser fatalsToBrowser);
use strict;

#2016-01-07	http://www.cgi101.com/book/ch3/text.html

print header;
print start_html("Referring Page");
print "Welcome, I see you've just come from 
$ENV{HTTP_REFERER}!<p>\n";
print end_html;
