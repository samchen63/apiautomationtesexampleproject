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

    // Convert between user object and json string
    public class JsonParser
    {
        // Convert json string into user object
        public List<User> ConvertJsonStringIntoUserObjects(string json)
        {
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        // Convert user object into json string
        public string ConvertUserObjectsIntoJsonString(List<User> users)
        {
            return JsonConvert.SerializeObject(users);
        }
    }
}
