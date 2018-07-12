using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillTrax.Models
{
    public class SkillTypeSkill
    {
        [Key]
        public int SkillTypeSkillId { get; set; }

        [ForeignKey("Skill")]
        public int SkillId { get; set; }

        [ForeignKey("SkillType")]
        public int SkillTypeId { get; set; }

    }
}