using System.Net;
using System.Text;
using System.Text.Json;

const string serverUrl = "http://localhost:5000";

var server = new HttpListener();

List<CoffeeOrder> CoffeOrderList = new List<CoffeeOrder>();

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
        
        
    }

    switch(request.Url.AbsoluteUri)
    {
        case serverUrl + "/create/":
            byte[] buffer = new byte[request.ContentLength64];
            request.InputStream.Read(buffer, 0, buffer.Length);

            string jsonstring = Encoding.UTF8.GetString(buffer);

            try
            {
                CoffeeOrder _order = JsonSerializer.Deserialize<CoffeeOrder>(jsonstring);
                _order.PrintOrderInfo();
                CoffeOrderList.Add(_order);

            }
            catch (Exception ex)
            {  
                Console.WriteLine($"ERROR \n TEXT TYPE:{jsonstring} IS NOT JSON DESERIALIZEBLE FORMAT");
            }
            break;

        case serverUrl + "/get-all/":
            foreach (var order in CoffeOrderList)
            {
                string jsonResponse = JsonSerializer.Serialize(order, new JsonSerializerOptions { WriteIndented = true });
                byte[] res = Encoding.UTF8.GetBytes(jsonResponse);
                await response.OutputStream.WriteAsync(res, 0, res.Length);
            }
            response.OutputStream.Close();
            break;
        case serverUrl + "/get-later/":
            byte[] tx = new byte[request.ContentLength64];
            request.InputStream.Read(tx, 0, tx.Length);

            string jsondata = Encoding.UTF8.GetString(tx);

            JsonDocument jsonDoc = JsonDocument.Parse(jsondata);
            JsonElement root = jsonDoc.RootElement;

            DateTime date = Convert.ToDateTime(root.GetProperty("date").ToString());

            foreach (var order in CoffeOrderList)
            {
                if(order.OrderDate > date)
                {
                    string jsonResponse = JsonSerializer.Serialize(order, new JsonSerializerOptions { WriteIndented = true });
                    byte[] res = Encoding.UTF8.GetBytes(jsonResponse);
                    await response.OutputStream.WriteAsync(res, 0, res.Length);
                }
                
            }


            break;


    }


}





