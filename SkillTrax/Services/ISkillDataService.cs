using SkillTrax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public interface ISkillDataService
    {
        Task<List<SkillViewModel>> GetSkillViewModels();
        Task<SkillViewModel> GetSkillViewModelById(int Id);
        Task<int> DeleteSkill(int skillId);

    }
}
