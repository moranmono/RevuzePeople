using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class GroupModel
    {
        public int From { get; set; }
        public int To { get; set; }
        public List<UserModel> UserModels { get; set; }
    }
}
