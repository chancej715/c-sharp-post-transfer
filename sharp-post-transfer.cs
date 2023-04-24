// File
string file = @"data";

// Read contents of a file into a byte array
byte[] bytes = File.ReadAllBytes(file);

// Print binary array value of the file contents
foreach(byte s in bytes)
{
    Console.WriteLine(s);
}