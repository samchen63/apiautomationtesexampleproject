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
        private readonly string Base_URL = "http://localhost:3001/booking/";
        private readonly string Auth_Key = "Authorization";
        private readonly string Auth_Value = "Basic YWRtaW46cGFzc3dvcmQxMjM=";

        // Delete a booking object from endpoint by passing booking id
        public int DeleteBookingObjectFromEndpoint(int bookingid)
        {
            var request = CreateHttpWebRequestObject("DELETE", Base_URL + bookingid);
            request.Headers.Add(Auth_Key, Auth_Value);
            var response = (HttpWebResponse)request.GetResponse();
            return (int)response.StatusCode;
        }

        // Put a booking object to endpoint by passing booking id
        public int PutJsonStringToEndpoint(int bookingid, string json)
        {
            var request = CreateHttpWebRequestObject("PUT", Base_URL + bookingid);
            request.Headers.Add(Auth_Key, Auth_Value);
            WriteJsonStringIntoRequestBody(request, json);
            var response = (HttpWebResponse)request.GetResponse();
            return (int)response.StatusCode;
        }

        // Post json string to endpoint
        public string PostJsonStringToEndpoint(string json)
        {
            var request = CreateHttpWebRequestObject("POST", Base_URL);
            WriteJsonStringIntoRequestBody(request, json);
            var response = (HttpWebResponse)request.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            return streamReader.ReadToEnd();
        }

        // Get json string from endpoint by passing booking id
        public string GetJsonStringFromEndpointForSpecificBooking(int bookingid)
        {
            var request = CreateHttpWebRequestObject("GET", Base_URL + bookingid);
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var steamReader = new StreamReader(stream, Encoding.UTF8);
            return steamReader.ReadToEnd();
        }

        // Get json string from endpoint for all booking id result objects
        public string GetJsonStringFromEndpointForAllBookingIdObjects()
        {
            var request = CreateHttpWebRequestObject("GET", Base_URL);
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var steamReader = new StreamReader(stream, Encoding.UTF8);
            return steamReader.ReadToEnd();
        }

        // Help method to create http web request
        private HttpWebRequest CreateHttpWebRequestObject(string methodName, string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = methodName;
            request.ContentType = "application/json; charset=utf-8";
            request.Accept = "application/json";
            return request;
        }

        // Help method to write json string into request body
        private void WriteJsonStringIntoRequestBody(HttpWebRequest request, string json)
        {
            var streamWriter = new StreamWriter(request.GetRequestStream());
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
