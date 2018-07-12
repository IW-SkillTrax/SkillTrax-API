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

        [ForeignKey("CertCategory")]
        public int CertCategoryId { get; set; }
        public CertCategory CertCategory { get; set;}


        public ICollection<Employee> Employees { get; set; }
    }
}