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
        public async Task<int> DeleteCertification(int certificationId)
        {
            Certification cert = await _db.Certification.FirstOrDefaultAsync(c => c.CertificationId == certificationId);
            _db.Certification.Remove(cert);
            return _db.SaveChanges();
        }
        public async Task<List<CertificationCategory>> getCertificationCategories()
        {
            return await _db.CertificationCategory.AsNoTracking().ToListAsync();
        }
        public async Task<int> CreateCertification(string certName, int categoryId)
        {
            CertificationCategory category = await _db.CertificationCategory.FirstOrDefaultAsync(c => c.CertCategoryId == categoryId);
            Certification cert = new Certification
            {
                CertificationName = certName,
                CertCategory = category
            };
            _db.Certification.Add(cert);
            await _db.SaveChangesAsync();
            cert = await _db.Certification.AsNoTracking().FirstOrDefaultAsync(c => c.CertificationName == certName);

            return cert.CertificationId;
        }
        public async Task<int> UpdateCertification(int id, string name, int categoryId)
        {
            CertificationCategory category = await _db.CertificationCategory.FirstOrDefaultAsync(c => c.CertCategoryId == categoryId);
            Certification cert = await _db.Certification.FirstOrDefaultAsync(c => c.CertificationId == id);
            cert.CertificationName = name;
            cert.CertCategory = category;
            _db.Certification.Update(cert);
            return await _db.SaveChangesAsync();
        }
    }
}
