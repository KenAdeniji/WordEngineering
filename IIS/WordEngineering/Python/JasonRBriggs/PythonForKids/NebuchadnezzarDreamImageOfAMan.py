#2022-07-03T19:18:00 http://nostarch.com/download/samples/PFK_ch4.pdf
import turtle
t = turtle.Pen()
t.forward(50) #Draw head
t.left(90)
t.forward(50)
t.left(90)
t.forward(50)
t.left(90)
t.forward(50)
t.penup()
t.goto(25, 0) #Draw body
t.pendown()
t.forward(50)
t.right(45) #Draw leg
t.forward(50)
t.penup()
t.goto(50, -10)
t.forward(50)
t.pendown()
t.left(45) #Draw other leg
t.forward(50)
input("Press Enter to continue...")

