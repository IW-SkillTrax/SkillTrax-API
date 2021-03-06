﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillTrax.Models
{
    public class SkillType
    {
        [Key]
        public int SkillTypeId { get; set; }
        [Required]
        public string SkillTypeName { get; set; }
        public IEnumerable<Skill> Skills { get; set; }

    }
}