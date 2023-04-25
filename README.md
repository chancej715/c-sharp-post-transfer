# C# HTTP POST File Transfer
Use C# to send files via an HTTP POST request.

# Dependencies
- [.NET SDK](https://dotnet.microsoft.com/en-us/download) on the Windows host.
- [Python 3](https://www.python.org/downloads/) on the receiving host.

# Usage
Transfer `server.py` to the receiving host. It's a simple Flask application that accepts the incoming POST request and saves the file.

Run `server.py` to listen for incoming requests:
```
python3 -m flask -A server.py run --host=0.0.0.0
```

Change `PATH` in the following line to the path of the file you would like to transfer:
```cs
var filePath = @"PATH";
```

Change `URL` in the following line to the URL of the receiving application:
```cs
var url = "URL";
```
Build the project:
```
dotnet build
```

Run:
```
dotnet run
```
The file will be transferred via an HTTP POST request to the Flask application on the receiving host where it will be saved locally.
