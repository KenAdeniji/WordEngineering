<html>
<!--
	2017-12-31	https://www.w3schools.com/asp/asp_variables.asp
-->
<body>

<%
Dim x(2,2)
x(0,0)="Volvo"
x(0,1)="BMW"
x(0,2)="Ford"
x(1,0)="Apple"
x(1,1)="Orange"
x(1,2)="Banana"
x(2,0)="Coke"
x(2,1)="Pepsi"
x(2,2)="Sprite"
for i=0 to 2
    response.write("<p>")
    for j=0 to 2
        response.write(x(i,j) & "<br />")
    next
    response.write("</p>")
next
%>

</body>
</html>
