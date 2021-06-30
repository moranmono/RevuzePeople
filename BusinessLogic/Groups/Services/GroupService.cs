using BusinessLogic.Groups.Interfaces;
using BusinessLogic.Users.Interfaces;
using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Groups.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUserService _userService;
        public GroupService(IUserService userService)
        {
            _userService = userService;
        }
        public Task<List<GroupModel>> CreateGroupModels()
        {
            throw new NotImplementedException();
        }

        public async Task<List<MonthGroupModel>> CreateMonthGroupModels()
        {
            var userModelList = await _userService.CreateUserModelOrderedList();
            var monthGroupModels = new List<MonthGroupModel>();
            for (int i = 1; i < 13; i++)
            {
                monthGroupModels.Add(
                    new MonthGroupModel()
                    {
                        Month = i,
                        UserModels = userModelList.Where(um => um.BirthDate.Month == i).ToList()
                    });
            }
            return monthGroupModels;
        }
    }
}
