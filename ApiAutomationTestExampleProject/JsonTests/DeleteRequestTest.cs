//-----------------------------------------------------------------------------
// <copyright file="DeleteRequestTest.cs" company="Planit Testing">
//      Copyright © 2019 Planit Testing.
//      All rights reserved.
// </copyright>
// <created>12/04/2019</created>
// <author>Sam Chen</author>
//-----------------------------------------------------------------------------
namespace ApiAutomationTestExampleProject.JsonTests
{
    using ApiAutomationTestExampleProject.JsonProcessor;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DeleteRequestTest
    {
        [TestMethod]
        // Delete a specific user object from endpoint
        // Assume that user with id exists in db
        public void VerifyDeleteSpecificUserObjectFromEndpoint()
        {
            // Ensure that user object with id 11 exists
            var jsonResponsor = new JsonResponsor();
            var jsonstring = jsonResponsor.GetJsonStringFromEndpointWithArgument("id=11");
            var jsonParser = new JsonParser();
            var users = jsonParser.ConvertJsonStringIntoUserObjects(jsonstring);
            Assert.AreEqual(1, users.Count);

            // Delete user with id 11
            int statusCode = jsonResponsor.DeleteUserObjectFromEndpoint("id", "11");
            // Verify successful status code is returned
            Assert.AreEqual(200, statusCode);

            // Attempt to get deleted user object
            jsonstring = jsonResponsor.GetJsonStringFromEndpointWithArgument("id=11");
            users = jsonParser.ConvertJsonStringIntoUserObjects(jsonstring);
            // Verify user object with id 11 is deleted
            Assert.AreEqual(0, users.Count);
        }
    }
}
