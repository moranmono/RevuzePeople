using BusinessLogic.Groups.Interfaces;
using DTOModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevuzePeople.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupsController : ControllerBase
    {
        private readonly ILogger<UserGroupsController> _logger;
        private readonly IGroupService _groupService;

        public UserGroupsController(ILogger<UserGroupsController> logger, IGroupService groupService)
        {
            _logger = logger;
            _groupService = groupService;
        }

        [HttpGet, Route("GetUserGroups")]
        public async Task<IActionResult> GetUserGroups()
        {
            var groupModelList = new List<GroupModel>();
            try
            {
                var monthGroupModelList = await _groupService.CreateMonthGroupModels();
                for (int i = 0; i < monthGroupModelList.Count; i += 3)
                {
                    var quaterlyGroupModelList = monthGroupModelList.Skip(i).Take(3);
                    var quaterlyUserModelList = new List<UserModel>();
                    foreach (var quaterlyGroupModel in quaterlyGroupModelList)
                    {
                        quaterlyUserModelList.AddRange(quaterlyGroupModel.UserModels);
                    }
                    groupModelList.Add(new GroupModel()
                    {
                        From = quaterlyGroupModelList.First().Month,
                        To = quaterlyGroupModelList.Last().Month,
                        UserModels = quaterlyUserModelList
                    });

                }
                return Ok(groupModelList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return BadRequest();
        }

    }
}
