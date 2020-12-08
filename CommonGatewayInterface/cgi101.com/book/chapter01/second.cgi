#!/perl64/bin/perl -wT
print "Content-type: text/html\n\n";
print "<html><head><title>Hello World</title></head>\n";
print "<body>\n";
print "<h2>Hello, world!</h2>\n";

print <<endmarker;
line1
line2
line3
etc.
endmarker

print "</body></html>\n";