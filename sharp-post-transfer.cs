using System.Net.Http.Headers;

var filePath 	= @"PATH";	// File path
var uri 		= "URL";	// Receiving server

var byteData = File.ReadAllBytes(filePath);

using (var content = new ByteArrayContent(byteData))
{
	content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

	var httpClient = new HttpClient();

	try
	{
		// Send bytes
		var response = await httpClient.PostAsync(uri, content);
	}
	catch (Exception e)
	{
		// Transmission failed
		Console.WriteLine(e);
	}
}