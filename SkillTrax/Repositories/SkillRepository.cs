using Microsoft.EntityFrameworkCore;
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
        private readonly AppDbContext _db;

        public SkillRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Skill> GetSkillById(int Id)
        {
            return _db.Skill
                .Include(S => S.SkillTypeSkills)
                .Include(S => S.SolutionSkills)
                .FirstOrDefault(S => S.SkillId == Id);
        }
        public async Task<List<Skill>> GetSkills()
        {
            return _db.Skill
                .Include(S => S.SkillTypeSkills)
                .Include(S => S.SolutionSkills)
                .ToList();
        }
        public async Task<Solution> getSkillSolution(int Id)
        {
            SolutionSkill solutionSkill = _db.SolutionSkill.FirstOrDefault(S => S.SkillId == Id);
            return _db.Solution.FirstOrDefault(S => S.SolutionId == solutionSkill.SolutionId);
        }
        public async Task<SkillType> getSkillType(int Id)
        {
            SkillTypeSkill skillTypeSkill = _db.SkillTypeSkill.FirstOrDefault(S => S.SkillId == Id);
            return _db.SkillType.FirstOrDefault(S => S.SkillTypeId == skillTypeSkill.SkillTypeId);
        }
    }
}

