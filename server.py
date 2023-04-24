from flask import Flask, request

app = Flask(__name__)

@app.route('/', methods=['POST'])
def result():
    with open("data", "wb") as file:
        file.write(request.data)

    return 'Received!' # Response.