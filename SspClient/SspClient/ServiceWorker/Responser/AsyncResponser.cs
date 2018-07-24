using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SspClient.ServiceWorker
{
    public class AsyncResponser : IDisposable
    {
        private Dictionary<string, object> _parameters;

        public AsyncResponser()
        {
            _parameters = new Dictionary<string, object>();
        }

        public void SetParameter(string paramName, object paramValue)
        {
            if (_parameters.ContainsKey(paramName))
            {
                _parameters.Remove(paramName);
            }
            _parameters.Add(paramName, paramValue);
        }

        public void Dispose()
        {
            _parameters.Clear();
        }

        public async Task<ResultBody<T>> Execute<T>(string responseString)
        {
            if (_parameters == null)
            {
                throw new Exception("parameters is null");
            }
            if (_parameters.Count != 1)
            {
                throw new Exception("parameters count != 1");
            }
            string sd = JsonConvert.SerializeObject(_parameters.Single().Value);

            var webResponse = await GetWebResponseWithSerializedData(responseString, "POST", "application/json", sd);
            return CreateReturnPackage<T>(webResponse);
        }

        private static ResultBody<T> CreateReturnPackage<T>(HttpWebResponse webResponse)
        {
            using (var stream = webResponse.GetResponseStream())
            {
                var reader = new StreamReader(stream);
                var serializedResponse = reader.ReadToEnd();
                var package = JsonConvert.DeserializeObject<ResultBody<T>>(serializedResponse);
                return package;
            }
        }

        public static async Task<HttpWebResponse> GetWebResponse(string uri, string requestMethod, string contentType)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.Method = requestMethod;
            webRequest.ContentType = contentType;
            webRequest.AllowWriteStreamBuffering = false;
            return (HttpWebResponse)await webRequest.GetResponseAsync();
        }

        public static async Task<HttpWebResponse> GetWebResponseWithSerializedData(string uri, string requestMethod,
            string contentType, string serializedData)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.Method = requestMethod;
            webRequest.AllowWriteStreamBuffering = false;
            byte[] byteArray = Encoding.UTF8.GetBytes(serializedData);
            webRequest.ContentLength = byteArray.Length;
            webRequest.ContentType = contentType;

            Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            return (HttpWebResponse)await webRequest.GetResponseAsync();

        }
    }
}
