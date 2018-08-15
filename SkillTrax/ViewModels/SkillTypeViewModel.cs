using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.ViewModels
{
    public class SkillTypeViewModel
    {
       public SkillTypeViewModel()
        {

        }
        public SkillTypeViewModel(SkillType skillType)
        {
            SkillTypeId = skillType.SkillTypeId;
            SkillTypeName = skillType.SkillTypeName;
        }
        public int SkillTypeId { get; set; }
        public string SkillTypeName { get; set; }

    }
}
