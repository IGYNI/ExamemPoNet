//Код с урока
using System.Net;
using System.Text;

string serverUrl = "http://localhost:5000";

var server = new HttpListener();

server.Prefixes.Add(serverUrl + "/create/");
server.Prefixes.Add(serverUrl + "/get-all/");
server.Prefixes.Add(serverUrl + "/get-later/");
server.Prefixes.Add(serverUrl + "/delete/");
server.Start();

while (true)
{
    var context = server.GetContext();
    var request = context.Request;
    var response = context.Response; 

    if (request.Url.AbsoluteUri == (serverUrl + "/create/"))
    {
        byte[] buffer = new byte[request.ContentLength64];
        request.InputStream.Read(buffer, 0, buffer.Length);

        string requestBody = Encoding.UTF8.GetString(buffer);

        Console.WriteLine(requestBody);
    }


}



