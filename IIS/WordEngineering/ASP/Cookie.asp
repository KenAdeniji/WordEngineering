<!DOCTYPE html>
<html>
<!--
	2018-01-01	https://www.w3schools.com/asp/asp_cookies.asp
-->
<head>
</head>

<body>
	<%
		Response.Cookies("firstname")="Alex"
		Response.Cookies("firstname").Expires = dateadd("n",+60,now()) REM #2018-01-02#
		
		Response.Cookies("user")("firstname")="John"
		Response.Cookies("user")("lastname")="Smith"
		Response.Cookies("user")("country")="Norway"
		Response.Cookies("user")("age")="25"
		Response.Cookies("user").Expires = dateadd("n",+60,now()) REM #2018-01-02#
		
dim x,y
for each x in Request.Cookies
  response.write("<p>")
  if Request.Cookies(x).HasKeys then
    for each y in Request.Cookies(x)
      response.write(x & ":" & y & "=" & Request.Cookies(x)(y))
      response.write("<br>")
    next
  else
    Response.Write(x & "=" & Request.Cookies(x) & "<br>")
  end if
  response.write "</p>"
next		
	%>
</body>

</html>
