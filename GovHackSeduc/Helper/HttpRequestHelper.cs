using GovHackSeduc.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;


namespace GovHackSeduc.Helper
{
    public class HttpRequestHelper
    {
        public static T GetDataFromUrls<T>(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            var m = JsonConvert.DeserializeObject<T>(responseFromServer);

            reader.Close();
            response.Close();

            return m;
        }

        public static List<SerieColor> GetSerieColor()
        {
            var lista = new List<SerieColor>();

            lista.Add(new SerieColor("rgba(255, 99, 132, 0.2)", "rgba(255,99,132,1)"));
            lista.Add(new SerieColor("rgba(54, 162, 235, 0.2)", "rgba(54, 162, 235, 1)"));
            lista.Add(new SerieColor("rgba(255, 206, 86, 0.2)", "rgba(255, 206, 86, 1)"));
            lista.Add(new SerieColor("rgba(75, 192, 192, 0.2)", "rgba(75, 192, 192, 1)"));
            lista.Add(new SerieColor("rgba(153, 102, 255, 0.2)", "rgba(153, 102, 255, 1)"));
            lista.Add(new SerieColor("rgba(255, 159, 64, 0.2)", "rgba(255, 159, 64, 1)"));

            return lista;
        }
    }
}