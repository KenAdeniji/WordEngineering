REM pip install Flask
REM pip install flask_restful
set FLASK_APP=BibleBookRestFlask.py
REM flask run --host=0.0.0.0
python -m flask run
REM curl -XGET http://127.0.0.1:5000/category/python