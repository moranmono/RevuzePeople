using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Groups.Interfaces
{
    public interface IGroupService
    {
        Task<List<MonthGroupModel>> CreateMonthGroupModels();
    }
}
