//-----------------------------------------------------------------------------
// <copyright file="JsonResponsor.cs" company="Planit Testing">
//      Copyright © 2019 Planit Testing.
//      All rights reserved.
// </copyright>
// <created>11/04/2019</created>
// <author>Sam Chen</author>
//-----------------------------------------------------------------------------
namespace ApiAutomationTestExampleProject.JsonProcessor
{
    using System.IO;
    using System.Net;
    using System.Text;

    // Send http request to endpoint and retrieve response back
    public class JsonResponsor
    {
        private readonly string Base_URL = "https://jsonplaceholder.typicode.com/users";

        // Get json string from endpoint
        public string GetJsonStringFromEndpoint()
        {
            var request = (HttpWebRequest)WebRequest.Create(Base_URL);
            return ConvertResponseToString(request);
        }
        
        // Get json string from endpoint by passing certain argument
        public string GetJsonStringFromEndpointWithArgument(string argument)
        {
            var request = (HttpWebRequest)WebRequest.Create(Base_URL + "?" + argument);
            return ConvertResponseToString(request);
        }

        // Post json string to endpoint
        public int PostJsonStringToEndpoint(string json)
        {
            var request = (HttpWebRequest)WebRequest.Create(Base_URL);
            request.Method = "POST";
            request.ContentType = "application/json; charset=UTF-8";
            var streamWriter = new StreamWriter(request.GetRequestStream());
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
            var httpResponse = (HttpWebResponse)request.GetResponse();
            return (int)httpResponse.StatusCode;
        }

        // Delete a user object from endpoint
        public int DeleteUserObjectFromEndpoint(string key, string value)
        {
            var request = (HttpWebRequest)WebRequest.Create(Base_URL);
            request.Method = "DELETE";
            request.ContentType = "application/json; charset=UTF-8";
            request.Headers.Add(key, value);
            var httpResponse = (HttpWebResponse)request.GetResponse();
            return (int)httpResponse.StatusCode;
        }

        // Put a user object to endpoint
        public int PutJsonStringToEndpoint(string json)
        {
            var request = (HttpWebRequest)WebRequest.Create(Base_URL);
            request.Method = "PUT";
            request.ContentType = "application/json; charset=UTF-8";
            var streamWriter = new StreamWriter(request.GetRequestStream());
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
            var httpResponse = (HttpWebResponse)request.GetResponse();
            return (int)httpResponse.StatusCode;
        }

        // Help method to convert response to json string
        private string ConvertResponseToString(HttpWebRequest request)
        {
            request.ContentType = "application/json; charset=utf-8";
            var response = request.GetResponse() as HttpWebResponse;
            var stream = response.GetResponseStream();
            var steamReader = new StreamReader(stream, Encoding.UTF8);
            return steamReader.ReadToEnd();
        }
    }
}
