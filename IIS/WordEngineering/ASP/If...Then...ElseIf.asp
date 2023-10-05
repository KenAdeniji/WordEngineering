<!DOCTYPE html>
<html>
<head>
<%
sub vbproc()
i=hour(time)
If i = 10 Then
response.write("Just started...!")
ElseIf i = 11 Then
response.write("Hungry!")
ElseIf i = 12 Then
response.write("Ah, lunch-time!")
ElseIf i = 16 Then
response.write("Time to go home!")
Else
response.write("Unknown")
End If
End sub
%>
</head>

<body>
<p>
<%call vbproc()%>
</p>
</body>

</html>
