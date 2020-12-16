#!/perl64/bin/perl -wT
use CGI qw(:standard);
use CGI::Carp qw(warningsToBrowser fatalsToBrowser);
use strict;
use Socket;

#2016-01-07	http://www.cgi101.com/book/ch3/text.html

print header;
print start_html("Remote Host");

my $hostname = gethostbyaddr(inet_aton($ENV{REMOTE_ADDR}), AF_INET);

print "Remote address $ENV{REMOTE_ADDR}<p>\n";
print "Welcome, visitor from $hostname!<p>\n";

print end_html;
