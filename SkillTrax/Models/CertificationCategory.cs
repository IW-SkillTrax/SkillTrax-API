using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillTrax.Models
{
    public class CertificationCategory
    {
        [Key]
        public int CertCategoryId { get; set; }
        [Required]
        public string CertCategoryName { get; set; }
        public ICollection <Certification> Certifications { get; set; }
         
    }
}