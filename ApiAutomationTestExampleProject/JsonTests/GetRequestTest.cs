//-----------------------------------------------------------------------------
// <copyright file="GetRequestTest.cs" company="Planit Testing">
//      Copyright © 2019 Planit Testing.
//      All rights reserved.
// </copyright>
// <created>11/04/2019</created>
// <author>Sam Chen</author>
//-----------------------------------------------------------------------------
namespace ApiAutomationTestExampleProject.JsonTests
{
    using ApiAutomationTestExampleProject.JsonProcessor;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetRequestTest
    {
        [TestMethod]
        // Get all user objects back from endpoint and verify total amount of objects
        public void VerifyGetTotalNumberOfUserObjectsFromEndpoint()
        {
            var jsonResponsor = new JsonResponsor();
            var jsonstring = jsonResponsor.GetJsonStringFromEndpoint();
            var jsonParser = new JsonParser();
            var users = jsonParser.ConvertJsonStringIntoUserObjects(jsonstring);
            Assert.AreEqual(10, users.Count);
        }

        [TestMethod]
        // Get specfic user object back from endpoint by passing specific argument
        public void VerifyAllDetailForSepecficUserOjbectFromEndpoint()
        {
            var jsonResponsor = new JsonResponsor();
            var jsonstring = jsonResponsor.GetJsonStringFromEndpointWithArgument("id=1");
            var jsonParser = new JsonParser();
            var users = jsonParser.ConvertJsonStringIntoUserObjects(jsonstring);
            Assert.AreEqual(1, users.Count);
            var user = users[0];
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("Leanne Graham", user.Name);
            Assert.AreEqual("Bret", user.Username);
            Assert.AreEqual("Sincere@april.biz", user.Email);
            Assert.AreEqual("Kulas Light", user.Address.Street);
            Assert.AreEqual("Apt. 556", user.Address.Suite);
            Assert.AreEqual("Gwenborough", user.Address.City);
            Assert.AreEqual("92998-3874", user.Address.Zipcode);
            Assert.AreEqual(-37.3159, user.Address.Geo.Lat);
            Assert.AreEqual(81.1496, user.Address.Geo.Lng);
            Assert.AreEqual("1-770-736-8031 x56442", user.Phone);
            Assert.AreEqual("hildegard.org", user.Website);
            Assert.AreEqual("Romaguera-Crona", user.Company.Name);
            Assert.AreEqual("Multi-layered client-server neural-net", user.Company.CatchPhrase);
            Assert.AreEqual("harness real-time e-markets", user.Company.Bs);
        }

        [TestMethod]
        // Get null object back from endpoint by passing invalid argument
        public void VerifyNoObjectReturnedFromEndpointWithInvalidArgument()
        {
            var jsonResponsor = new JsonResponsor();
            var jsonstring = jsonResponsor.GetJsonStringFromEndpointWithArgument("id=invalid");
            var jsonParser = new JsonParser();
            var users = jsonParser.ConvertJsonStringIntoUserObjects(jsonstring);
            Assert.AreEqual(0, users.Count);
        }
    }
}
