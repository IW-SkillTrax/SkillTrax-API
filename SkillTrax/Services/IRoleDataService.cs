using SkillTrax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public interface IRoleDataService
    {
        Task<List<RoleViewModel>> getRoles();
    }
}
