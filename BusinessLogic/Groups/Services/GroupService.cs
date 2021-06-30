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

        public async Task<List<MonthGroupModel>> CreateMonthGroupModels()
        {
            var userModelList = await _userService.CreateUserModelOrderedList();
            var monthGroupModelList = new List<MonthGroupModel>();
            for (int i = 1; i < 13; i++)
            {
                monthGroupModelList.Add(
                    new MonthGroupModel()
                    {
                        Month = i,
                        UserModels = userModelList.Where(um => um.BirthDate.Month == i).ToList()
                    });
            }
            return monthGroupModelList;
        }
    }
}
