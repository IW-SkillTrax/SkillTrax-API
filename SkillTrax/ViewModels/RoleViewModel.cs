using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.ViewModels
{
    public class RoleViewModel
    {
        public string RoleName;
        public int RoleId;
        public RoleViewModel()
        {

        }
        public RoleViewModel(RoleType role)
        {
            RoleName = role.RoleName;
            RoleId = role.RoleId;
        }
    }
}
