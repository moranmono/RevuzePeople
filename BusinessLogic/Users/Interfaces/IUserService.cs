using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Users.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> CreateUserModelOrderedList();
    }
}
