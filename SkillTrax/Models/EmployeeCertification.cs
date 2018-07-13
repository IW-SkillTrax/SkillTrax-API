using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillTrax.Models
{
    public class EmployeeCertification
    {
        [Key]
        public int EmployeeCertificationId { get; set; }
        public int CertificationId { get; set; }
        public Certification Certification { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}