#!/perl64/bin/perl -wT
use CGI qw(:standard);
use CGI::Carp qw(warningsToBrowser fatalsToBrowser);
use strict;
use Socket;

#2016-01-07	http://www.cgi101.com/book/ch3/text.html

print header;
print start_html("Remote Host");

my($ua) = $ENV{HTTP_USER_AGENT};

print "User-agent: $ua<p>\n";
if (index($ua, "MSIE") > -1) {
   print "Your browser is Internet Explorer.<p>\n";
} elsif (index($ua, "Netscape") > -1) {
   print "Your browser is Netscape.<p>\n";
} elsif (index($ua, "Safari") > -1) {
   print "Your browser is Safari.<p>\n";
} elsif (index($ua, "Opera") > -1) {
   print "Your browser is Opera.<p>\n";
} elsif (index($ua, "Mozilla") > -1) {
   print "Your browser is probably Mozilla.<p>\n";
} else {
   print "I give up, I can't tell what browser you're using!<p>\n";
}

print end_html;
