using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.ViewModels
{
    public class SkillViewModel
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public Solution Solution { get; set; }
        public SkillType SkillType { get; set; }

    }
}
