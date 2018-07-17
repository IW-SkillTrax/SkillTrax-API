using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public interface ICertificationDataService
    {
        Task<List<Certification>> GetCertifications();
    }
}
