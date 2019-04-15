//-----------------------------------------------------------------------------
// <copyright file="JsonWrapper.cs" company="Planit Testing">
//      Copyright © 2019 Planit Testing.
//      All rights reserved.
// </copyright>
// <created>11/04/2019</created>
// <author>Sam Chen</author>
//-----------------------------------------------------------------------------
namespace ApiAutomationTestExampleProject.JsonProcessor
{
    // Define user ojbect matching to key and value in json string 
    public class JsonWrapper
    {
        // User object
        public class User
        {
            public int Id;
            public string Name;
            public string Username;
            public string Email;
            public Address Address;
            public string Phone;
            public string Website;
            public Company Company;
        }

        // Address object
        public class Address
        {
            public string Street;
            public string Suite;
            public string City;
            public string Zipcode;
            public Geo Geo;
        }

        // Geo object
        public class Geo
        {
            public double Lat;
            public double Lng;
        }

        // Company object
        public class Company
        {
            public string Name;
            public string CatchPhrase;
            public string Bs;
        }
    }
}
