using SearchConsoleApp.Interfaces;
using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;


namespace SearchConsoleApp
{
    public class BingSearch :  ISearch
    {
        const string accessKey = "61c4794fb19c49129b01e3a87d43f0a8"; 
        const string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/search";


        public int Search(string query)
        {
            var uriQuery = uriBase + "?q=" + Uri.EscapeDataString(query);
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = accessKey;
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;

            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var jsonDic = JObject.Parse(json);

            var webPages = jsonDic["webPages"];
            var totalEstimatedMatches = JObject.Parse(webPages.ToString())["totalEstimatedMatches"].ToString();
            return Int32.Parse(totalEstimatedMatches);
        }

    }
}
