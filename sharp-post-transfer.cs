using System.Net.Http.Headers;

var filePath 	= @"PATH";						// File to transfer
var url 		= "URL";						// Receiving URL

var fileName 	= Path.GetFileName(filePath);

using (var multipartFormContent = new MultipartFormDataContent())
{
	// Read file
	var fileStreamContent = new StreamContent(File.OpenRead(filePath));

	// Add file
	multipartFormContent.Add(fileStreamContent, name: fileName, fileName: fileName);

	try
	{
		// Send POST request
    	var httpClient = new HttpClient();
		var response = await httpClient.PostAsync(url, multipartFormContent);
	}
	catch (Exception e)
	{
		Console.WriteLine(e);
	}
}