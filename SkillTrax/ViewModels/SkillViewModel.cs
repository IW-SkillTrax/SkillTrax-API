using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.ViewModels
{
    public class SkillViewModel
    {
        public SkillViewModel()
        {

        }
        public SkillViewModel(Skill skill)
        {
            SkillId = skill.SkillId;
            SkillName = skill.SkillName;
            SolutionId = skill.Solution.SolutionId;
            SolutionName = skill.Solution.SolutionName;
            SkillTypeId = skill.SkillType.SkillTypeId;
            SkillTypeName = skill.SkillType.SkillTypeName;
        }
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int SolutionId { get; set; }
        public string SolutionName { get; set; }
        public int SkillTypeId { get; set; }
        public string SkillTypeName { get; set; }

    }
}
