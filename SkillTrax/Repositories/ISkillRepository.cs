using SkillTrax.Models;
using SkillTrax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public interface ISkillRepository
    {
        Task<Skill> GetSkillById(int Id);
        Task<List<Skill>> GetSkills();
        Task<int> DeleteSkill(int skillId);
        Task<int> CreateSkill(string skillName, int typeId, int solutionId);
        Task<int> UpdateSkill(int skillId, string skillName, int typeId, int solutionId);
        Task<List<SkillType>> getSkillTypes();
    }
}
