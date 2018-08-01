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
    }
}
