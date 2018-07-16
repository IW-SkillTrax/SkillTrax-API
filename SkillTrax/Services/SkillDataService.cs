using SkillTrax.Models;
using SkillTrax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public class SkillDataService : ISkillDataService
    {
        private readonly ISkillRepository _repo;

        public SkillDataService(ISkillRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<SkillViewModel>> GetSkillViewModels()
        {
            List<Skill> skills = await _repo.GetSkills();
            List<SkillViewModel> skillViewModels = new List<SkillViewModel>();
            foreach (Skill skill in skills)
            {
                skillViewModels.Add(await GetSkillViewModelById(skill.SkillId));
            }
            return skillViewModels;
        }
        public async Task<SkillViewModel> GetSkillViewModelById(int Id)
        {
            Skill skill = await _repo.GetSkillById(Id);

            SkillViewModel skillViewModel = new SkillViewModel
            {
                SkillId = skill.SkillId,
                SkillName = skill.SkillName,
                SkillType = await _repo.getSkillType(Id),
                Solution = await _repo.getSkillSolution(Id)
            };
            return skillViewModel;
        }
    }
}
