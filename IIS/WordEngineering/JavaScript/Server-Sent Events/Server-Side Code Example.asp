<%
//2016-07-04 	Created.	http://www.w3schools.com/html/html5_serversentevents.asp
//2016-07-04				http://stackoverflow.com/questions/35631938/server-sent-events-eventsource-with-standard-asp-net-mvc-causing-error
Response.ContentType = "text/event-stream"
Response.Expires = -1
Response.Write("data: The server time is: " & now())
Response.Flush()
%>
