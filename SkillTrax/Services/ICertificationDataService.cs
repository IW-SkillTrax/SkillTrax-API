using SkillTrax.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public interface ICertificationDataService
    {
        Task<List<CertificationViewModel>> GetCertifications();
        Task<int> DeleteCertification(int certificationId);
        Task<List<CertCategoryViewModel>> getCertCategoryViewModels();
        Task<int> CreateCertification(CertificationViewModel certVm);
        Task<int> UpdateCertification(int id, CertificationViewModel certVm);
    }
}
