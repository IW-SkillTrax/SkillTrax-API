using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Repositories
{
    public interface IRoleRepository
    {
        Task<List<RoleType>> getRoles();
    }
}
