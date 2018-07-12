using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillTrax.Models
{
    public class SolutionSkill
    {
        [Key]
        public int SolutionSkillId { get; set; }

        [ForeignKey("Skill")]
        public int SkillId { get; set; }

        [ForeignKey("Solution")]
        public int SolutionId { get; set; }
    }
}