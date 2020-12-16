#2019-12-06T16:00	https://www.thegeekstuff.com/2019/04/rest-basic-concepts
#2019-12-06T17:20	curl -XGET http://127.0.0.1:5000/title/Genesis
#2019-12-06T19:15	curl -XPOST http://127.0.0.1:5000/title/Deuteronomy -H "Content-Type: application/json"  --data '{"title":"Deuteronomy","ID":5,"chapters":34}'
#2019-12-06T18:25	curl -XPUT http://127.0.0.1:5000/title/Genesis -H "Content-Type: application/json"  --data '{ "title": "Genesis", "ID": 1, "chapters": 50 }'
#2019-12-06T19:10	curl -XDELETE http://127.0.0.1:5000/title/Genesis
from flask import Flask
from flask_restful import Resource, reqparse, Api

TGS = Flask(__name__)
api = Api(TGS)

bibleBooks = [
    {
        "title": "Genesis",
        "ID": 1,
        "chapters": 50
    },
    {
        "title": "Exodus",
        "ID": 2,
        "chapters": 40
    },
    {
        "title": "Leviticus",
        "ID": 3,
        "chapters": 27
    }
]

class BibleBook(Resource):
    def get(self, title):
        for bibleBook in bibleBooks:
            if(title == bibleBook["title"]):
                return bibleBook, 200
        return "Title not found", 404

    def post(self, title):
        parser = reqparse.RequestParser()
        
        parser.add_argument("ID")
        parser.add_argument("chapters")

        #args = parser.parse_args()

        for bibleBook in bibleBooks:
            if(title == bibleBook["title"]):
                return "title  {} already exists".format(title), 400

        bibleBook = {
            "title":title,
            "ID":-1, #args["ID"],
            "chapters":-1 #args["chapters"]
        }

        bibleBooks.append(bibleBook)
        return bibleBook, 201

    def put(self, title):
        parser = reqparse.RequestParser()
        parser.add_argument("ID")
        parser.add_argument("chapters")
        #args = parser.parse_args()

        for bibleBook in bibleBooks:
            if(title == bibleBook["title"]):
                bibleBook["ID"] = -1#args["ID"]
                bibleBook["chapters"] = -1#args["chapters"]
                return bibleBook, 200

        bibleBook = {
            "title": title,
            "ID": -1, #args["ID"],
            "chapters": -1 #args["chapters"]
        }
        bibleBooks.append(bibleBook)
        return bibleBook, 201

    def delete(self, title):
        global bibleBooks
        bibleBooks = [bibleBook for bibleBook in bibleBooks if bibleBook["title"] != title]
        return "{} is deleted.".format(title), 200

api.add_resource(BibleBook, "/title/<string:title>")

TGS.run(debug=True,port=8080)
