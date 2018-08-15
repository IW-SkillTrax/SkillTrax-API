using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.ViewModels
{
    public class CertCategoryViewModel
    {
        public CertCategoryViewModel()
        {

        }
        public CertCategoryViewModel(CertificationCategory certCategory)
        {
            CertCategoryId = certCategory.CertCategoryId;
            CertCategoryName = certCategory.CertCategoryName;
        }
        public int  CertCategoryId{ get; set;}
        public string CertCategoryName { get; set; }
    }
}
