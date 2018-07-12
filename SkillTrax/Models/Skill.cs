using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillTrax.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        [Required]
        public string SkillName { get; set; }
   
        public ICollection<Employee> Employees { get; set; }
    }
}