using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillTrax.Models
{
    public class Certification
    {
        [Key]
        public int CertificationId { get; set; }
        [Required]
        public string CertificationName { get; set; }
        public CertificationCategory CertCategory { get; set;}
        public ICollection<EmployeeCertification> EmployeeCertifications { get; set; }
    }
}