# http://goalkicker.com/PythonBook/PythonNotesForProfessionals.pdf
# pip install flask
# http://jinja.palletsprojects.com/en/stable
# pip install Jinja2
# http://127.0.0.1:5000
from datetime import datetime, timedelta, timezone
# Imports the Flask class
from flask import Flask
from flask import request
# Creates an app and checks if it's the main or imported
app = Flask(__name__)
# Specifies what URL triggers hello_world()
@app.route('/')
# The function run on the index route
def hello_world():
    # Returns the text to be displayed
    return "Hello World!"

@app.route("/visit")
def visit():
    dateOfVisit = datetime.now(timezone.utc)
    from jinja2 import Environment, PackageLoader, select_autoescape
    env = Environment(
        loader=PackageLoader("application"),
        autoescape=select_autoescape()
    )    
    template = env.get_template("visit.html")
    return template.render(dateOfVisit=dateOfVisit)
    
# http://localhost:5000/users/guido-van-rossum?key=pa55w0Rd
@app.route("/users/<username>")
def profile(username):   
    try:
        key = request.args.get("key")
        if key == "pa55w0Rd":
            return f"username: {username} key: {key}"
        else:
            return "Incorrect key"
    # if there is no key parameter
    except KeyError:
        return "No key provided"

# If this script isn't an import
if __name__ == "__main__":
    # Run the app until stopped
    app.run(host="127.0.0.1", port=5000, debug=True)