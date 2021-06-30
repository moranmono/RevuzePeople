using BusinessLogic.Users.Interfaces;
using DataAccess.Interfaces;
using DTOModels.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersDBService _usersDBService;

        public UserService(IUsersDBService usersDBService)
        {
            _usersDBService = usersDBService;
        }
        public async Task<List<UserModel>> CreateUserModelOrderedList()
        {
            var userModelOrderedList = new List<UserModel>();
            var users = await _usersDBService.GetUsers();
            if (users != null)
            {
                return userModelOrderedList = users.OrderBy(u => u.Date.Month)
                    .Select(user => new UserModel()
                    {
                        FullName = user.Name,
                        BirthDate = user.Date,
                        Address = user.Address
                    }).ToList();
            }
            return null;
        }
    }
}
