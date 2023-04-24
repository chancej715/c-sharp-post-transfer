using System.Net.Http.Headers;

var filePath = @"data";					// File path
var uri = "http://192.168.10.3:5000";	// Receiving server URI

var byteData = File.ReadAllBytes(filePath);

using (var content = new ByteArrayContent(byteData))
{
	content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

	var httpClient = new HttpClient();
	var response = await httpClient.PostAsync(uri, content);

	var responseContent = await response.Content.ReadAsStringAsync();

	Console.WriteLine(responseContent);
}