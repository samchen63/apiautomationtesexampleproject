//-----------------------------------------------------------------------------
// <copyright file="PutRequestTest.cs" company="Planit Testing">
//      Copyright © 2019 Planit Testing.
//      All rights reserved.
// </copyright>
// <created>12/04/2019</created>
// <author>Sam Chen</author>
//-----------------------------------------------------------------------------
namespace ApiAutomationTestExampleProject.JsonTests
{
    using System.Collections.Generic;

    using ApiAutomationTestExampleProject.JsonProcessor;
    using static ApiAutomationTestExampleProject.JsonProcessor.JsonWrapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PutRequestTest
    {
        [TestMethod]
        // Update the value of one key in a specific user object and put it to endpoint
        public void VerifyPutSpecificUserObjectToEndpoint()
        {
            // New email address
            string NewEmailAddress = "newemailaddress@april.biz";

            var jsonResponsor = new JsonResponsor();
            var jsonstring = jsonResponsor.GetJsonStringFromEndpointWithArgument("id=1");
            var jsonParser = new JsonParser();
            var users = jsonParser.ConvertJsonStringIntoUserObjects(jsonstring);
            Assert.AreEqual(1, users.Count);
            var user = users[0];
            // Verify initial value of email of a user object
            Assert.AreEqual("Sincere@april.biz", user.Email);

            // Modify email address to a new one
            var newUser = new User
            {
                Id = 1,
                Name = "Leanne Graham",
                Username = "Bret",
                Email = NewEmailAddress, // New value of email adress
                Address = new Address
                {
                    Street = "Kulas Light",
                    Suite = "Apt. 556",
                    City = "Gwenborough",
                    Zipcode = "92998-3874",
                    Geo = new Geo
                    {
                        Lat = -37.3159,
                        Lng = 81.1496
                    }
                },
                Phone = "1-770-736-8031 x56442",
                Website = "hildegard.org",
                Company = new Company
                {
                    Name = "Romaguera-Crona",
                    CatchPhrase = "Multi-layered client-server neural-net",
                    Bs = "harness real-time e-markets"
                }
            };
            users = new List<User>
            {
                newUser
            };
            var jsonString = jsonParser.ConvertUserObjectsIntoJsonString(users);
            int statusCode = jsonResponsor.PutJsonStringToEndpoint(jsonString);
            // Verify successful status code is returned
            Assert.AreEqual(200, statusCode);

            // Verify email address is updated to new one
            jsonstring = jsonResponsor.GetJsonStringFromEndpointWithArgument("id=1");
            users = jsonParser.ConvertJsonStringIntoUserObjects(jsonstring);
            Assert.AreEqual(1, users.Count);
            user = users[0];
            // Verify updated value of email of a user object
            Assert.AreEqual(NewEmailAddress, user.Email);
        }
    }
}
