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
    using NUnit.Framework;

    [TestFixture]
    public class GetRequestTest : BaseTest
    {
        [Test]
        // Get all booking id objects back from endpoint and verify total amount of objects
        public void VerifyGetTotalNumberOfBookingIdResultObjectsFromEndpoint()
        {
            var jsonResponsor = new JsonResponsor();
            var jsonstring = jsonResponsor.GetJsonStringFromEndpointForAllBookingIdObjects();
            var jsonParser = new JsonParser();
            var bookingIdResults = jsonParser.ConvertJsonStringIntoBookingIdResultObjects(jsonstring);
            Assert.AreEqual(11, bookingIdResults.Count);
        }

        [Test]
        // Get specfic booking object back from endpoint by passing booking id
        public void VerifyAllDetailForSpecificBookingObjectFromEndpoint()
        {
            var jsonResponsor = new JsonResponsor();
            var jsonString = jsonResponsor.GetJsonStringFromEndpointForSpecificBooking(BookingId);
            var jsonParser = new JsonParser();
            var booking = jsonParser.ConvertJsonStringIntoBookingObject(jsonString);
            Assert.AreEqual(FirstName, booking.firstname);
            Assert.AreEqual(LastName, booking.lastname);
            Assert.AreEqual(TotalPrice, booking.totalprice);
            Assert.AreEqual(DepositPaid, booking.depositpaid);
            Assert.AreEqual(CheckinDate, booking.bookingdates.checkin);
            Assert.AreEqual(CheckoutDate, booking.bookingdates.checkout);
            Assert.AreEqual(AdditionalNeeds, booking.additionalneeds);
        }
    }
}
