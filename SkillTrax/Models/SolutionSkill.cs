using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillTrax.Models
{
    public class SolutionSkill
    {

        public int SkillId { get; set; }
        public Skill Skill { get; set; }


        public int SolutionId { get; set; }
        public Solution Solution { get; set; }
    }
}