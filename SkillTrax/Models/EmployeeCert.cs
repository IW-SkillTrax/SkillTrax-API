using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillTrax.Models
{
    public class EmployeeCert
    {
        [Key]
        public int EmployeeCertId { get; set; }

        [ForeignKey("Certification")]
        public int CertificationId { get; set; }
        public Certification Certification { get; set; }

        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}