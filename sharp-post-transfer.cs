using System.Net.Http.Headers;

var filePath = @"data";					// File path
// var fileName = "data";					// File name
var uri = "http://192.168.10.3:5000";	// Receiving server URL

// using (var multipartFormContent = new MultipartFormDataContent())
// {
// 	//Load file
// 	var fileStreamContent = new StreamContent(File.OpenRead(filePath));
	
// 	// 
// 	fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
// 	multipartFormContent.Add(fileStreamContent, name: fileName, fileName: fileName);

// 	//Send file
//     var httpClient = new HttpClient();

// 	var response = await httpClient.PostAsync(url, multipartFormContent);
// 	response.EnsureSuccessStatusCode();
// 	var responseContent = await response.Content.ReadAsStringAsync();
// }

var byteData = File.ReadAllBytes(filePath);

using (var content = new ByteArrayContent(byteData))
{
	content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

	var httpClient = new HttpClient();
	var response = await httpClient.PostAsync(uri, content);

	var responseContent = await response.Content.ReadAsStringAsync();
}

// TODO: Use "application/octet-stream" MIME type
		// - https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types#applicationoctet-stream
	
	// Currently, it's using the "MultipartFormDataContent" class to encode using "multipart/form-data" MIME type
	// This MIME type is used when sending the values of completed HTML forms from browser to server
		// - https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types#multipartform-data