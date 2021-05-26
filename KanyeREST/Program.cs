using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeREST
{
    class Program
    {
        static void Main(string[] args)
        {
            var uriRonSwanso = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var uriKanyeRest = "https://api.kanye.rest";

            var clientRon = new HttpClient();
            var clientKanye = new HttpClient();

            for (int i = 0; i < 5; i++)
            {
                var resultKanye = clientKanye.GetStringAsync(uriKanyeRest).Result;
                var resultRon = clientRon.GetStringAsync(uriRonSwanso).Result;
            
                Console.WriteLine($"Ron Says: { JArray.Parse(resultRon).ToString().Replace("[","").Replace("]", "").Trim()}");
                Console.WriteLine("");
                Console.WriteLine($"Kanye Says: {JObject.Parse(resultKanye).GetValue("quote").ToString()}");
                Console.WriteLine("");
                }
        }
    }
}
