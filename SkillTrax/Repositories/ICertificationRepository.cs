using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Repositories
{
    public interface ICertificationRepository
    {
        Task<List<Certification>> GetCertifications();
        Task<int> DeleteCertification(int certificationId);
        Task<List<CertificationCategory>> getCertificationCategories();
        Task<int> CreateCertification(string certName, int categoryId);
        Task<int> UpdateCertification(int id, string name, int categoryId);
    }
}
