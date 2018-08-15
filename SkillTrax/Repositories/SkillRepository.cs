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
            return await _db.Skill
                .Include(S => S.SkillType)
                .Include(S => S.Solution)
                .AsNoTracking()
                .FirstOrDefaultAsync(S => S.SkillId == Id);
        }
        public async Task<List<Skill>> GetSkills()
        {
            return await _db.Skill
                .Include(S => S.SkillType)
                .Include(S => S.Solution)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<List<SkillType>> getSkillTypes()
        {
            return await _db.SkillType.AsNoTracking().ToListAsync();
        }
        public async Task<int> DeleteSkill(int skillId)
        {
            Skill skill = await _db.Skill.FirstOrDefaultAsync(s => s.SkillId == skillId);
            _db.Skill.Remove(skill);
            return _db.SaveChanges();
        }
        public async Task<int> CreateSkill(string skillName, int typeId, int solutionId)
        {
            Skill skill = new Skill
            {
                SkillName = skillName,
                Solution = await _db.Solution.FirstOrDefaultAsync(s => s.SolutionId == solutionId),
                SkillType = await _db.SkillType.FirstOrDefaultAsync(t => t.SkillTypeId == typeId)
            };
            _db.Skill.Add(skill);
            await _db.SaveChangesAsync();
            Skill newSkill = await _db.Skill.AsNoTracking().FirstOrDefaultAsync(s => s.SkillName == skillName);
            return newSkill.SkillId;
        }
        public async Task<int> UpdateSkill(int skillId, string skillName, int typeId, int solutionId)
        {
            Skill skill = await _db.Skill.FirstOrDefaultAsync(s => s.SkillId == skillId);
            SkillType type = await _db.SkillType.FirstOrDefaultAsync(t => t.SkillTypeId == typeId);
            Solution solution = await _db.Solution.FirstOrDefaultAsync(s => s.SolutionId == solutionId);
            skill.SkillName = skillName;
            skill.SkillType = type;
            skill.Solution = solution;
            _db.Skill.Update(skill);
            return await _db.SaveChangesAsync();
        }
    }
}

