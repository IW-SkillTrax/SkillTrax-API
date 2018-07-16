using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.ViewModels
{
    public class EmployeeViewModel
    {
        
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public string AdUniqueIdentifier { get; set; }
        public RoleType RoleType { get; set; }
        public List<SkillViewModel> Skills { get; set; }
        public List<Certification> Certifications { get; set; }

    }
}
