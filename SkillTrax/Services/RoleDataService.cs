using SkillTrax.Models;
using SkillTrax.Repositories;
using SkillTrax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public class RoleDataService: IRoleDataService
    {
        private readonly IRoleRepository _roleRepo;
        public RoleDataService(IRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public async Task<List<RoleViewModel>> getRoles()
        {
            List<RoleType> roles = await _roleRepo.getRoles();
            List<RoleViewModel> roleViewModels = new List<RoleViewModel>();
            foreach(RoleType role in roles)
            {
                RoleViewModel roleViewModel = new RoleViewModel(role);
                roleViewModels.Add(roleViewModel);
            };
            return roleViewModels;
        }
    }
}
