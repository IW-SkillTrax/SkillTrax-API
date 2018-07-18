using SkillTrax.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public interface ICertificationDataService
    {
        Task<List<CertificationViewModel>> GetCertifications();
    }
}
