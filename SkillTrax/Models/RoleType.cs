﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillTrax.Models
{
    public class RoleType
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}