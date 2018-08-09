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
        public async Task<int> DeleteSkill(int skillId)
        {
            Skill skill = await _db.Skill.FirstOrDefaultAsync(s => s.SkillId == skillId);
            _db.Skill.Remove(skill);
            return _db.SaveChanges();
        }
    }
}

