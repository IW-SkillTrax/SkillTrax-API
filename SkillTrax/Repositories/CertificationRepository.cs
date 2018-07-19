using Microsoft.EntityFrameworkCore;
using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Repositories
{
    public class CertificationRepository : ICertificationRepository
    {
        private readonly AppDbContext _db;
        public CertificationRepository( AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<Certification>> GetCertifications()
        {
            return await _db.Certification
                .Include(C => C.CertCategory)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
