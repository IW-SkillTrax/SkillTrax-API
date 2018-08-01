using Microsoft.EntityFrameworkCore;
using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        private readonly AppDbContext _db;
        public RoleRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<RoleType>> getRoles()
        {
            return await _db.Role.AsNoTracking().ToListAsync();
        }
    }
}
