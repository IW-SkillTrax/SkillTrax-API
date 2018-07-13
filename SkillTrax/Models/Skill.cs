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
   
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public ICollection<SolutionSkill> SolutionSkills { get; set; }
        public ICollection<SkillTypeSkill> SkillTypeSkills { get; set; }

    }
}