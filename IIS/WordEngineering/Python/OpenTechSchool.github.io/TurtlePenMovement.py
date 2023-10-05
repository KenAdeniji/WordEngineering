#2019-10-23 http://opentechschool.github.io/python-beginners/en/simple_drawing.html
import turtle
turtle.reset() #turtle.undo()
#turtle.color("violet")
turtle.colormode(255)
turtle.color(215, 100, 170)
turtle.shape("turtle")

for outer in range(10):
	turtle.pendown()
	turtle.forward(outer * 5)
	turtle.penup()
	turtle.forward(5)
	
turtle.exitonclick()	