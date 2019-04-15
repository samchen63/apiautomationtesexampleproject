//-----------------------------------------------------------------------------
// <copyright file="PostRequestTest.cs" company="Planit Testing">
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
    public class PostRequestTest
    {
        [TestMethod]
        // Create a user object and post it to endpoint
        // Assume that user with id 11 doesn't exist in db
        public void VerifyPostSpecficUserObjectToEndpoint()
        {
            // Initially verify no user object with id 11
            var jsonResponsor = new JsonResponsor();
            var jsonstring = jsonResponsor.GetJsonStringFromEndpointWithArgument("id=11");
            var jsonParser = new JsonParser();
            var users = jsonParser.ConvertJsonStringIntoUserObjects(jsonstring);
            Assert.AreEqual(0, users.Count);

            // Create a new user with id 11
            var newUser = new User
            {
                Id = 11,
                Name = "Sam Chen",
                Username = "SamChen",
                Email = "sam@chen.com",
                Address = new Address
                {
                    Street = "152 Gloucester St",
                    Suite = "Suite",
                    City = "Sydney",
                    Zipcode = "2000",
                    Geo = new Geo
                    {
                        Lat = 99.9999,
                        Lng = 11.1111
                    }
                },
                Phone = "12345678",
                Website = "http://sam.chen.com",
                Company = new Company
                {
                    Name = "Planit",
                    CatchPhrase = "Testing Consulting",
                    Bs = "IT market"
                }
            };
            users = new List<User>
            {
                newUser
            };
            var jsonString = jsonParser.ConvertUserObjectsIntoJsonString(users);
            int statusCode = jsonResponsor.PostJsonStringToEndpoint(jsonString);
            // Verify successful status code is returned
            Assert.AreEqual(201, statusCode);

            // Get added user object to ensure posting successfully
            jsonstring = jsonResponsor.GetJsonStringFromEndpointWithArgument("id=11");
            users = jsonParser.ConvertJsonStringIntoUserObjects(jsonstring);
            Assert.AreEqual(1, users.Count);
        }
    }
}
