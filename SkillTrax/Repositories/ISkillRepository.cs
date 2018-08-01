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
        
        
    }
}
