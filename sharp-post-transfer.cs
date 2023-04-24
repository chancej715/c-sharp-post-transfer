// // File
// string file = @"data";

// // Read contents of a file into a byte array
// byte[] bytes = File.ReadAllBytes(file);

// // Print binary array value of the file contents
// foreach(byte s in bytes)
// {
//     Console.WriteLine(s);
// }

// https://makolyte.com/csharp-how-to-send-a-file-with-httpclient/

using System.Net.Http.Headers;

var filePath = @"data";

using (var multipartFormContent = new MultipartFormDataContent())
{
	//Load the file and set the file's Content-Type header
	var fileStreamContent = new StreamContent(File.OpenRead(filePath));
	fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

	//Add the file
	multipartFormContent.Add(fileStreamContent, name: "data", fileName: "data");

    var httpClient = new HttpClient();

	//Send it
	var response = await httpClient.PostAsync("http://192.168.10.3:5000", multipartFormContent);
	response.EnsureSuccessStatusCode();
	var responseContent = await response.Content.ReadAsStringAsync();
}