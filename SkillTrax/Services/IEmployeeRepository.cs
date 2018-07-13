using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        int AddEmployeeSkill(int employeeId, int skillId);
        Employee GetEmployee(int id);
        Employee GetEmployeeByAdUniqueId(string AdUniqueId);
        List<Skill> GetEmployeeSkills(int employeeId);
        IQueryable GetAvailableSkills(int employeeId);
        int DeleteEmployeeSkill(int employeeSkillId);
    }
}
