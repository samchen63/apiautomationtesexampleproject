namespace ApiAutomationTestExampleProject.JsonProcessor
{
    // Define booking ojbect matching to key and value in json string 
    public class JsonWrapper
    {
        // Booking object
        public class Booking
        {
            public string firstname;
            public string lastname;
            public int totalprice;
            public bool depositpaid;
            public Bookingdates bookingdates;
            public string additionalneeds;
        }

        // Booking Dates object
        public class Bookingdates
        {
            public string checkin;
            public string checkout;
        }

        // Booking Id object
        public class BookingIdResult
        {
            public int bookingid;
        }
    }
}
