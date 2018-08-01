using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillTrax.Models
{
    public class EmployeeSkill
    {
        [Key]
        public int EmployeeSkillId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }

    }
}