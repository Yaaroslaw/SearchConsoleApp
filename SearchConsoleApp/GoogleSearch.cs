using SearchConsoleApp.Interfaces;
using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;


namespace SearchConsoleApp
{
    public class GoogleSearch :  ISearch
    {
        public int Search(string query)
        {
            string searchQuery = query;
            string cx = "006461571065944352717:p9f6c6saqk8";
            string apiKey = "AIzaSyApsQ4tH6JsP0TxoJkPpUBBgHOs-aThJOs";

            var request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + cx + "&q=" + searchQuery + "& alt = json & fields = queries(request(totalResults))");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            var responseString = reader.ReadToEnd();

            dynamic jsonData = JsonConvert.DeserializeObject(responseString);
            var result = jsonData.searchInformation["totalResults"];
            return Int32.Parse(result.ToString());
        }

    }
}
