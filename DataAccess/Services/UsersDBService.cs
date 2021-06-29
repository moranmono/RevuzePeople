using DataAccess.Interfaces;
using DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class UsersDBService : IUsersDBService
    {
        public async Task<List<User>> GetUsers()
        {
            var users = new List<User>();
            using (var streamReader = new StreamReader(@"C:\Users\moran\Exams\RevuzePeople\DataAccess\UsersDB\users.json"))
            {
                string usersString = await streamReader.ReadToEndAsync();
                users = JsonConvert.DeserializeObject<List<User>>(usersString);
            }
            return users;
        }
    }
}
