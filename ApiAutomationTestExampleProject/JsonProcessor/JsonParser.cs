//-----------------------------------------------------------------------------
// <copyright file="JsonParser.cs" company="Planit Testing">
//      Copyright © 2019 Planit Testing.
//      All rights reserved.
// </copyright>
// <created>11/04/2019</created>
// <author>Sam Chen</author>
//-----------------------------------------------------------------------------
namespace ApiAutomationTestExampleProject.JsonProcessor
{
    using System.Collections.Generic;

    using static ApiAutomationTestExampleProject.JsonProcessor.JsonWrapper;
    using Newtonsoft.Json;

    // Convert between booking object and json string
    public class JsonParser
    {
        // Convert json string into a booking object
        public Booking ConvertJsonStringIntoBookingObject(string json)
        {
            return JsonConvert.DeserializeObject<Booking>(json);
        }

        // Convert a booking object into json string
        public string ConverBookingObjectIntoJsonString(Booking booking)
        {
            return JsonConvert.SerializeObject(booking);
        }

        // Convert json string into booking id result objects
        public List<BookingIdResult> ConvertJsonStringIntoBookingIdResultObjects(string json)
        {
            return JsonConvert.DeserializeObject<List<BookingIdResult>>(json);
        }

        // Convert json string into a single booking id result object
        public BookingIdResult ConvertJsonStringIntoBookingIdResultObject(string json)
        {
            return JsonConvert.DeserializeObject<BookingIdResult>(json);
        }
    }
}
