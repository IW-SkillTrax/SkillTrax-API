using System.Collections.Generic;
using SkillTrax.Models;
namespace SkillTrax.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {

        }
        public EmployeeViewModel(Employee employee)
        {
            EmployeeId = employee.EmployeeId;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            IsAdmin = employee.IsAdmin;
            AdUniqueIdentifier = employee.AdUniqueIdentifier;
            RoleId = employee.RoleType.RoleId;
            RoleName = employee.RoleType.RoleName;
            Skills = new List<SkillViewModel>();
            foreach(EmployeeSkill employeeSkill in employee.EmployeeSkills)
            {
                SkillViewModel skillViewModel = new SkillViewModel(employeeSkill.Skill);
                Skills.Add(skillViewModel);
            }
            Certifications = new List<CertificationViewModel>();
            foreach(EmployeeCertification employeeCertification in employee.EmployeeCertifications)
            {
                CertificationViewModel certificationViewModel = new CertificationViewModel(employeeCertification.Certification);
                Certifications.Add(certificationViewModel);
            }
        }


        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public string AdUniqueIdentifier { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }      
        public List<SkillViewModel> Skills { get; set; }
        public List<CertificationViewModel> Certifications { get; set; }
    }
}
