using SkillTrax.Models;
using SkillTrax.Repositories;
using SkillTrax.ViewModels;
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
        public async Task<List<CertificationViewModel>> GetCertifications()
        {
            List<Certification> certifications = await _repo.GetCertifications();
            List<CertificationViewModel> certificationViewModels = new List<CertificationViewModel>();
            foreach(Certification certification in certifications)
            {
                CertificationViewModel certificationViewModel = new CertificationViewModel
                {
                    CertificationId = certification.CertificationId,
                    CertificationName = certification.CertificationName,
                    CertCategoryId = certification.CertCategory.CertCategoryId,
                    CertCategoryName = certification.CertCategory.CertCategoryName
                };
                certificationViewModels.Add(certificationViewModel);
            }
            return certificationViewModels;
        }
        public async Task<int> DeleteCertification(int certificationId)
        {
            return await _repo.DeleteCertification(certificationId);
        }
        public async Task<List<CertCategoryViewModel>> getCertCategoryViewModels()
        {
            List<CertificationCategory> certCategories = await _repo.getCertificationCategories();
            List<CertCategoryViewModel> certCategoryVMs = new List<CertCategoryViewModel>();
            foreach(CertificationCategory certCategory in certCategories)
            {
                certCategoryVMs.Add(new CertCategoryViewModel(certCategory));
            }
            return certCategoryVMs;
        }
        public async Task<int> CreateCertification(CertificationViewModel certVm)
        {
            return await _repo.CreateCertification(certVm.CertificationName, certVm.CertCategoryId);
        }
        public async Task<int> UpdateCertification(int id, CertificationViewModel certVm)
        {
            return await _repo.UpdateCertification(id, certVm.CertificationName, certVm.CertCategoryId);
        }
    }
}