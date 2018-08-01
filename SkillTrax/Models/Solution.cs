using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillTrax.Models
{
    public class Solution
    {
        [Key]
        public int SolutionId { get; set; }
        [Required]
        public string SolutionName { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
    }
}