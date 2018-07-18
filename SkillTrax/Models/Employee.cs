using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillTrax.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        [Required]
        public string AdUniqueIdentifier { get; set; }
        public RoleType RoleType { get; set; }

        public IEnumerable <EmployeeSkill> EmployeeSkills { get; set; }
        public IEnumerable <EmployeeCertification> EmployeeCertifications { get; set; }

    }
}