from flask import Flask, request

app = Flask(__name__)

@app.route('/', methods=['POST'])
def result():
    for file in request.files:      
        file = request.files[file]
        file.save(file.filename)
    
    return "Success."
