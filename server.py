from flask import Flask, request
app = Flask(__name__)
@app.route('/', methods=['POST'])
def result():
    f = request.files['data']
    f.save(f.filename)
    return 'Received !' # response to your request.

   