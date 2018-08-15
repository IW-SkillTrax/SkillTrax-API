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
                SkillViewModel skillViewModel = new SkillViewModel(skill);
               
                skillViewModels.Add(skillViewModel);
            }
            return skillViewModels;
        }
        public async Task<SkillViewModel> GetSkillViewModelById(int Id)
        {
            Skill skill = await _repo.GetSkillById(Id);
            if (skill == null)
            {
                return null;
            }
            SkillViewModel skillViewModel = new SkillViewModel(skill);
            
            return skillViewModel;
        }
        public async Task<int> DeleteSkill(int skillId)
        {
            return await _repo.DeleteSkill(skillId);
        }
        public async Task<int> CreateSkill(SkillViewModel skill)
        {
            return await _repo.CreateSkill(skill.SkillName, skill.SkillTypeId, skill.SolutionId);
        }
        public async Task<List<SkillTypeViewModel>> getSkillTypeViewModels()
        {
            List<SkillType> skillTypes = await _repo.getSkillTypes();
            List<SkillTypeViewModel> skillTypeVMs = new List<SkillTypeViewModel>();
            foreach(SkillType skillType in skillTypes)
            {
                SkillTypeViewModel skillTypeVM = new SkillTypeViewModel(skillType);
                skillTypeVMs.Add(skillTypeVM);
            }
            return skillTypeVMs;
        }
        public async Task<int> UpdateSkill(int id, SkillViewModel skill)
        {
            return (await _repo.UpdateSkill(id, skill.SkillName, skill.SkillTypeId, skill.SolutionId));
        }
    }
}
