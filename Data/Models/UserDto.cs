using Newtonsoft.Json;
using System;

namespace HighfieldTest.Data.Models
{
    public class UserDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("dob")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("favouriteColour")]
        public string FavouriteColour { get; set; }
    }
}
