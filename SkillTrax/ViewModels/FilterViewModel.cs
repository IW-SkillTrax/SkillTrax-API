using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.ViewModels
{
    public class FilterViewModel
    {
        public string Catagory;
        public string Name;

        public FilterViewModel() { }
        public FilterViewModel(Employee employee)
        {
            Catagory = "Person";
            Name = employee.FirstName + " " + employee.LastName;
        }
        public FilterViewModel(Skill skill)
        {
            Catagory = "Skill";
            Name = skill.SkillName;
        }
        public FilterViewModel(Certification certification)
        {
            Catagory = "Certification";
            Name = certification.CertificationName;
        }
        public FilterViewModel(RoleType role)
        {
            Catagory = "Role";
            Name = role.RoleName;
        }
    }
}
