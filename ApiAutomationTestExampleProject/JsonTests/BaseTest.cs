namespace ApiAutomationTestExampleProject.JsonTests
{
    using ApiAutomationTestExampleProject.JsonProcessor;
    using NUnit.Framework;
    using static ApiAutomationTestExampleProject.JsonProcessor.JsonWrapper;

    [TestFixture]
    public class BaseTest
    {
        // Original booking details
        public string FirstName = "testFirstName";
        public string LastName = "testLastName";
        public int TotalPrice = 111;
        public bool DepositPaid = false;
        public string CheckinDate = "2016-01-01";
        public string CheckoutDate = "2016-01-01";
        public string AdditionalNeeds = "Lunch";

        // New/Updated booking details
        public string NewFirstName = "newTestFirstName";
        public string NewLastName = "newTestLastName";
        public int NewTotalPrice = 222;
        public bool NewDepositPaid = true;
        public string NewCheckinDate = "2017-01-01";
        public string NewCheckoutDate = "2017-01-01";
        public string NewAdditionalNeeds = "Dinner";

        public int BookingId;

        [SetUp]
        public void StartUp()
        {
            // Create a booking object for all test cases
            var jsonResponsor = new JsonResponsor();
            var jsonParser = new JsonParser();
            var booking = new Booking
            {
                firstname = FirstName,
                lastname = LastName,
                totalprice = TotalPrice,
                depositpaid = DepositPaid,
                bookingdates = new Bookingdates
                {
                    checkin = CheckinDate,
                    checkout = CheckoutDate
                },
                additionalneeds = AdditionalNeeds
            };
            var jsonString = jsonParser.ConverBookingObjectIntoJsonString(booking);
            var jsonResponse = jsonResponsor.PostJsonStringToEndpoint(jsonString);
            var bookingIdResults = jsonParser.ConvertJsonStringIntoBookingIdResultObject(jsonResponse);
            BookingId = bookingIdResults.bookingid;
        }

        [TearDown]
        public void CleanUp()
        {
            // Delete booking object if it is still there
            var jsonResponsor = new JsonResponsor();
            var jsonParser = new JsonParser();
            var jsonstring = jsonResponsor.GetJsonStringFromEndpointForAllBookingIdObjects();
            var bookingIdResults = jsonParser.ConvertJsonStringIntoBookingIdResultObjects(jsonstring);
            if (bookingIdResults.Count > 10)
            {
                jsonResponsor.DeleteBookingObjectFromEndpoint(BookingId);
            }
        }
    }
}
