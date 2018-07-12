using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Models
{
    public class SkillListItem
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int SkillTypeId { get; set; }
        public string SkillTypeName { get; set; }
        public int SolutionId { get; set; }
        public string SolutionIdName { get; set; }
        public int? EmployeeSkillId { get; set; }
    }
}
