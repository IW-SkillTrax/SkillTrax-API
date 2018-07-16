using SkillTrax.Models;
using SkillTrax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public class SkillRepository : ISkillRepository
    {
        private readonly AppDbContext db;

        public SkillRepository(AppDbContext context)
        {
            db = context;
        }

        public async Task<Skill> GetSkillById(int Id)
        {
            return db.Skill.FirstOrDefault(S => S.SkillId == Id);
        }
        public async Task<List<Skill>> GetSkills()
        {
            return db.Skill.ToList();
        }
        public async Task<Solution> getSkillSolution(int Id)
        {
            SolutionSkill solutionSkill = db.SolutionSkill.FirstOrDefault(S => S.SkillId == Id);
            return db.Solution.FirstOrDefault(S => S.SolutionId == solutionSkill.SolutionId);
        }
        public async Task<SkillType> getSkillType(int Id)
        {
            SkillTypeSkill skillTypeSkill = db.SkillTypeSkill.FirstOrDefault(S => S.SkillId == Id);
            return db.SkillType.FirstOrDefault(S => S.SkillTypeId == skillTypeSkill.SkillTypeId);

        }
    }
}

