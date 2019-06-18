namespace ApiAutomationTestExampleProject.JsonTests
{
    using ApiAutomationTestExampleProject.JsonProcessor;
    using NUnit.Framework;

    [TestFixture]
    public class DeleteRequestTest : BaseTest
    {
        [Test]
        // Delete a specific booking object from endpoint
        public void VerifyDeleteSpecificBookingObjectFromEndpoint()
        {
            // Ensure that 11 booking objects initially
            var jsonResponsor = new JsonResponsor();
            var jsonstring = jsonResponsor.GetJsonStringFromEndpointForAllBookingIdObjects();
            var jsonParser = new JsonParser();
            var bookingIdResults = jsonParser.ConvertJsonStringIntoBookingIdResultObjects(jsonstring);
            Assert.AreEqual(11, bookingIdResults.Count);

            // Delete booking object with id 
            var statusCode = jsonResponsor.DeleteBookingObjectFromEndpoint(BookingId);
            // Verify successful status code is returned
            Assert.AreEqual(201, statusCode);

            // Verify booking object is deleted
            jsonstring = jsonResponsor.GetJsonStringFromEndpointForAllBookingIdObjects();
            bookingIdResults = jsonParser.ConvertJsonStringIntoBookingIdResultObjects(jsonstring);
            Assert.AreEqual(10, bookingIdResults.Count);
        }
    }
}
