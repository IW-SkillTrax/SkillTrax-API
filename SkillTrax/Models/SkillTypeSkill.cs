using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillTrax.Models
{
    public class SkillTypeSkill
    {
    
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    
        public int SkillTypeId { get; set; }
        public SkillType SkillType { get; set; }

    }
}