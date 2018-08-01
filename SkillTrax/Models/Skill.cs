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
        [Required]
        public Solution Solution { get; set; }
        [Required]
        public SkillType SkillType { get; set; }
        public IEnumerable<EmployeeSkill> EmployeeSkills { get; set; }
        

    }
}