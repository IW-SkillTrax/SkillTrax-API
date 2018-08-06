using SkillTrax.Models;
using SkillTrax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> GetEmployeeByAdUniqueId(string AdUniqueId);
        Task<List<Skill>> GetEmployeeSkills(int employeeId);
        Task<List<Certification>> GetEmployeeCertifications(int employeeId);
        Task<int> AddEmployeeSkill(int employeeId, int skillId);
        Task<int> DeleteEmployeeSkill(int employeeId, int skillId);
        Task<int> DeleteEmployeeCertification(int employeeId, int certificationId);
        Task<int> AddEmployeeCertification(int employeeId, int certificationId);
    }
}
