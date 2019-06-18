namespace ApiAutomationTestExampleProject.JsonTests
{
    using ApiAutomationTestExampleProject.JsonProcessor;
    using static ApiAutomationTestExampleProject.JsonProcessor.JsonWrapper;
    using NUnit.Framework;

    [TestFixture]
    public class PutRequestTest : BaseTest
    {
        [Test]
        // Update the value of a specific booking object and PUT it to endpoint
        public void VerifyPutSpecificBookingObjectToEndpoint()
        {
            // Booking object with updated value
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

            // PUT updated booking object to Endpoint
            var jsonParser = new JsonParser();
            var jsonString = jsonParser.ConverBookingObjectIntoJsonString(booking);
            var jsonResponsor = new JsonResponsor();
            var statusCode = jsonResponsor.PutJsonStringToEndpoint(BookingId, jsonString);
            // Verify successful status code is returned
            Assert.AreEqual(200, statusCode);

            // Verify updated value of booking object
            jsonString = jsonResponsor.GetJsonStringFromEndpointForSpecificBooking(BookingId);
            booking = jsonParser.ConvertJsonStringIntoBookingObject(jsonString);
            Assert.AreEqual(NewFirstName, booking.firstname);
            Assert.AreEqual(NewLastName, booking.lastname);
            Assert.AreEqual(NewTotalPrice, booking.totalprice);
            Assert.AreEqual(NewDepositPaid, booking.depositpaid);
            Assert.AreEqual(NewCheckinDate, booking.bookingdates.checkin);
            Assert.AreEqual(NewCheckoutDate, booking.bookingdates.checkout);
            Assert.AreEqual(NewAdditionalNeeds, booking.additionalneeds);
        }
    }
}
