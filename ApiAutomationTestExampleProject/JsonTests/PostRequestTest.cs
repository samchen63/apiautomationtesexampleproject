namespace ApiAutomationTestExampleProject.JsonTests
{
    using ApiAutomationTestExampleProject.JsonProcessor;
    using static ApiAutomationTestExampleProject.JsonProcessor.JsonWrapper;
    using NUnit.Framework;

    [TestFixture]
    public class PostRequestTest : BaseTest
    {
        int PostBookingId;

        [Test]
        // Create a booking object and post it to endpoint
        public void VerifyPostSpecificBookingObjectToEndpoint()
        {
            var jsonResponsor = new JsonResponsor();
            var jsonParser = new JsonParser();

            // Create a booking object
            var booking = new Booking
            {
                firstname = NewFirstName,
                lastname = NewLastName,
                totalprice = NewTotalPrice,
                depositpaid = NewDepositPaid,
                bookingdates = new Bookingdates
                {
                    checkin = NewCheckinDate,
                    checkout = NewCheckoutDate
                },
                additionalneeds = NewAdditionalNeeds
            };
            var jsonString = jsonParser.ConverBookingObjectIntoJsonString(booking);
            var jsonResponse = jsonResponsor.PostJsonStringToEndpoint(jsonString);
            var bookingResults = jsonParser.ConvertJsonStringIntoBookingIdResultObject(jsonResponse);
            PostBookingId = bookingResults.bookingid;

            // Get booking object and verify details
            jsonString = jsonResponsor.GetJsonStringFromEndpointForSpecificBooking(PostBookingId);
            booking = jsonParser.ConvertJsonStringIntoBookingObject(jsonString);
            Assert.AreEqual(NewFirstName, booking.firstname);
            Assert.AreEqual(NewLastName, booking.lastname);
            Assert.AreEqual(NewTotalPrice, booking.totalprice);
            Assert.AreEqual(NewDepositPaid, booking.depositpaid);
            Assert.AreEqual(NewCheckinDate, booking.bookingdates.checkin);
            Assert.AreEqual(NewCheckoutDate, booking.bookingdates.checkout);
            Assert.AreEqual(NewAdditionalNeeds, booking.additionalneeds);
        }

        // Class level tear down if test case fails after booking object is created
        [TearDown]
        public void ClassCleanUp()
        {
            var jsonResponsor = new JsonResponsor();
            var jsonParser = new JsonParser();
            var jsonstring = jsonResponsor.GetJsonStringFromEndpointForAllBookingIdObjects();
            var bookingIdResults = jsonParser.ConvertJsonStringIntoBookingIdResultObjects(jsonstring);
            if (bookingIdResults.Count > 10)
            {
                jsonResponsor.DeleteBookingObjectFromEndpoint(PostBookingId);
            }
        }
    }
}
