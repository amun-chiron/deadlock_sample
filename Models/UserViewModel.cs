using Newtonsoft.Json;
using System.Collections.Generic;

namespace SampleWebApp.Models
{
    public class UserResponse
    {
        public IEnumerable<UserViewModel> Data { get; set; }
    }

    public class UserViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }
}