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
                .Include(S => S.SkillType)
                .Include(S => S.Solution)
                .FirstOrDefault(S => S.SkillId == Id);
        }
        public async Task<List<Skill>> GetSkills()
        {
            return _db.Skill
                .Include(S => S.SkillType)
                .Include(S => S.Solution)
                .ToList();
        }
    }
}

