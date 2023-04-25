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

# Example
I transfer the file `server.py` to my Linux host and execute it with the following command:
```
python3 -m flask -A server.py run --host=0.0.0.0
```

On my Windows host, I create a new file called `data` which contains `text`:
```
echo text > data
```

Then I navigate to the directory containing the project files. I set the value of the `filePath` variable to the path of the file I just created:
```cs
var filePath = @"C:\Users\windows\data";
```

I change the value of the `url` variable to the URL of my Flask application:
```cs
var url = "http://192.168.1.2:5000"
```

Now I build the project:
```
dotnet build
```

And run it:
```
dotnet run
```

The file is now on my Linux host in the same directory as the `server.py` script.
