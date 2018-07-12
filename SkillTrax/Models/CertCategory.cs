using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillTrax.Models
{
    public class CertCategory
    {
        [Key]
        public int CertCategoryId { get; set; }

        [Required]
        public string CertCategoryName { get; set; }
    }
}