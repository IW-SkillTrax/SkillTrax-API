using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.ViewModels
{
    public class CertificationViewModel
    {
        public CertificationViewModel()
        {

        }
        public CertificationViewModel(Certification certification)
        {
            CertificationId = certification.CertificationId;
            CertificationName = certification.CertificationName;
            CertCategoryId = certification.CertCategory.CertCategoryId;
            CertCategoryName = certification.CertCategory.CertCategoryName;
        }
        public int CertificationId { get; set; }
        public string CertificationName { get; set; }
        public int CertCategoryId { get; set; }
        public string CertCategoryName { get; set; }
    }
}
