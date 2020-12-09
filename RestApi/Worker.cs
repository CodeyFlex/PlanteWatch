using System;
using System.Net;
using ModelLib.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestApi
{
    public class Worker
    {
        private static Token token = new Token();
        private static string GetPlantURI =
            "https://trefle.io/api/v1/plants?token=" + token.TokenValueApi + "&filter[common_name]=";
        /* doesn't return some values for some reason
        public static TrefleModel GetOnePlantAsync(String name)
        {

            using (WebClient client = new WebClient())
            {
                string uri = GetPlantURI + name;
                string content = client.DownloadString(uri);
                TrefleModel cList = JsonConvert.DeserializeObject<TrefleModel>(content);
                return cList;
            }
        }
        */

        public static string GetOnePlantAsync(string name)
        {
            string uri = GetPlantURI + name;
            using (WebClient client = new WebClient())
            {
                string content = client.DownloadString(uri);
                return content;
            }
        }
    }
}
