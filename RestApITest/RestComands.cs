using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace RestApITest
{
    class RestComands
    {
        private string ID = "d76b7205483545bf9d77af4fd0d3a929";
        private string passWord = "f07bd4425e124554a8bdda7c8042869c";
        private string token = "OAuth AQAEA7qiD4PFAADLW9ahiQkE2EUloHuPBCyaU3c";

        private string lastUploadedUrl = "https://cloud-api.yandex.net:443/v1/disk/resources/last-uploaded";
        private string downloadFileUrl = "https://cloud-api.yandex.net:443/v1/disk/public/resources/download";
        private string getFileInfoUrl = "https://cloud-api.yandex.net:443/v1/disk/resources";

        public bool LastUploadedInfo()
        {
            var client = new RestClient(lastUploadedUrl);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", token);
            var response = client.Execute(request);
            JObject obj = JObject.Parse(response.Content);

            if (response.StatusCode.ToString().Equals("OK"))
                return true;
            else return true;
        }

        public string GetSessionToken(string userName, string password)
        {
            var client = new RestClient("https://oauth.yandex.ru/authorize");
            var request = new RestRequest(Method.POST);
            request.AddHeader("client_id", ID);
            request.AddHeader("client_secret", passWord);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine(content);
            return "";
        }

        public bool DownloadFile(string pub_key)
        {
            var client = new RestClient(downloadFileUrl);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", token);
            request.AddParameter("public_key", pub_key);        
            var response = client.Execute(request);

            if (response.StatusCode.ToString().Equals("OK"))
            {
                JObject obj = JObject.Parse(response.Content);
                string href = (string)obj.SelectToken("href");
                string method = (string)obj.SelectToken("method");
                bool templated = (bool)obj.SelectToken("templated");
                return true;
            }
            else
                return false;
        }

        public bool GetFileInfo(string path)
        {
            var client = new RestClient(getFileInfoUrl);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", token);
            request.AddParameter("path", path);
            var response = client.Execute(request);

            if(response.StatusCode.ToString().Equals("OK"))
                return true;
            else
            return false;
        }

    }
}
