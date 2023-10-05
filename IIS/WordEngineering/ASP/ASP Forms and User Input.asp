<!DOCTYPE html>
<html>
<!--
	2017-12-31	https://www.w3schools.com/asp/asp_looping.asp
-->
<head>
</head>

<body>
<p>
<%
For i = 0 To 5
  response.write("The number is " & i & "<br />")
Next
For i=2 To 10 Step 2
  response.write("The number is " & i & "<br />")
Next 
For i=1 To 10
  If i=5 Then Exit For
  response.write("The number is " & i & "<br />")
Next 
Dim cars(2)
cars(0)="Volvo"
cars(1)="Saab"
cars(2)="BMW"

For Each x In cars
  response.write(x & "<br />")
Next

i = 9
Do While i>10
  response.write("The number is " & i & "<br />")
Loop

Do
  response.write("The number is " & i & "<br />")
Loop While i>10 
%>
</p>
</body>

</html>
