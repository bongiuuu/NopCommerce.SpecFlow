using Newtonsoft.Json;

namespace NopCommerce.Models
{
    public class Account
    {
        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("First Name")]
        public string Firstname { get; set; }

        [JsonProperty("Last Name")]
        public string Lastname { get; set; }

        [JsonProperty("Birthday")]
        public string Birthday { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Company Name")]
        public string CompanyName { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Confirm Password")]
        public string ConfirmPassword { get; set; }

        public Account(string gender="", string firstname="", string lastname="", string birthday="", string email="", string companyName="", string password="", string confirmPassword="") 
        {
            this.Gender = gender;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthday = birthday;
            this.Email = email;
            this.CompanyName = companyName;
            this.Password = password;
            this.ConfirmPassword = confirmPassword;
        }
    }
}