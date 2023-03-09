using Newtonsoft.Json;

namespace NopCommerce.Models
{
    public class Address
    {
        [JsonProperty("First Name")]
        public string FirstName;
        [JsonProperty("Last Name")]
        public string LastName;
        [JsonProperty("Email")]
        public string Email;
        [JsonProperty("Company")]
        public string Company;
        [JsonProperty("Country")]
        public string Country;
        [JsonProperty("State")]
        public string State;
        [JsonProperty("City")]
        public string City;
        [JsonProperty("Address1")]
        public string Address1;
        [JsonProperty("Address2")]
        public string Address2;
        [JsonProperty("Zipcode")]
        public string Zipcode;
        [JsonProperty("Phone")]
        public string Phone;
        [JsonProperty("Fax")]
        public string Fax;

        public Address(string firstName="", string lastName="", string email="", string company="", string country="", string state="", string city="", string address1="", string address2="", string zipcode="", string phone="", string fax="")
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Company = company;
            this.Country = country;
            this.State = state;
            this.City = city;
            this.Address1 = address1;
            this.Address2 = address2;
            this.Zipcode = zipcode;
            this.Phone = phone;
            this.Fax = fax;
        }
    }
}