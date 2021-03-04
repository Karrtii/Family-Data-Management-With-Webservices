using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DNPHandin1.Models;

namespace DNPHandin1.Data.Implementation
{
    public class InMemoryUserService : IUserService
    {
        private string userFile = "users.json";
        private List<User> users = new List<User>();

        public InMemoryUserService()
        {
            if (!File.Exists(userFile))
            {
                users.Add(new User { UserName = "admin", Password = "admin", City = "computer", Age = 21 });
                string productAsJson = JsonSerializer.Serialize(users);
                File.WriteAllText(userFile, productAsJson);
            }
            else
            {
                string content = File.ReadAllText(userFile);
                users = JsonSerializer.Deserialize<List<User>>(content);
            }
        }

        public async Task AddUser(User newUser)
        {
                users.Add(newUser);
                string productAsJson = JsonSerializer.Serialize(users);
                File.WriteAllText(userFile, productAsJson);
        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}
