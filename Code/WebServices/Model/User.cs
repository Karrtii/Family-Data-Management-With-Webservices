using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DNPHandin1.Models
{
    public class User
    {
        [NotNull]
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [Range(1,100)]
        [JsonPropertyName("age")]
        public int Age { get; set; }
        [NotNull]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        public User() {}
        public User(string username, string city, int age, string password)
        {
            this.UserName = username;
            this.City = city;
            this.Age = age;
            this.Password = password;
        }
    }
}
