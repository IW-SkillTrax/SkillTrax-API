using SkillTrax.Models;
using SkillTrax.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public class CertificationDataService : ICertificationDataService
    {
        private ICertificationRepository _repo;
        public CertificationDataService(ICertificationRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Certification>> GetCertifications()
        {
            return await _repo.GetCertifications();
        }
    }
}
