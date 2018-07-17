using Microsoft.EntityFrameworkCore;
using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly AppDbContext _db;

        public EmployeeRepository(AppDbContext context, ISkillRepository skillRepo)
        {
            _db = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return _db.Employee
                .Include(E => E.EmployeeCertifications)
                .Include(E => E.EmployeeSkills)
                .Include(E => E.RoleType)
                .ToList();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return _db.Employee
                .Include(E => E.EmployeeCertifications)
                .Include(E => E.EmployeeSkills)
                .Include(E => E.RoleType)
                .FirstOrDefault(Employee => Employee.EmployeeId == id);
                
        }

        public async Task<Employee> GetEmployeeByAdUniqueId(string AdUniqueId)
        {
            return _db.Employee
                .Include(E => E.EmployeeSkills)
                .Include(E => E.EmployeeCertifications)
                .Include(E => E.RoleType)
                .FirstOrDefault(Employee => Employee.AdUniqueIdentifier == AdUniqueId);
        }

        public async Task<List<Certification>> GetEmployeeCertifications(int employeeId)
        {
            List<EmployeeCertification> employeeCertifications = _db.EmployeeCertification
                .Where(EC => EC.EmployeeId == employeeId).ToList();
            List<Certification> Certifications = new List<Certification>();
            foreach (EmployeeCertification employeeCertification in employeeCertifications)
            {
                Certifications.Add(_db.Certification
                    .FirstOrDefault(C => C.CertificationId == employeeCertification.CertificationId));
            }
            return Certifications;
        }

        public async Task<List<Skill>> GetEmployeeSkills(int employeeId)
        {
            List<EmployeeSkill> employeeSkills = _db.EmployeeSkill
                .Where(ES => ES.EmployeeId == employeeId).ToList();
            List<Skill> Skills = new List<Skill>();
            foreach (EmployeeSkill employeeSkill in employeeSkills)
            {
                Skills.Add(_db.Skill.FirstOrDefault(S => S.SkillId == employeeSkill.SkillId));
            }
            return Skills;
        }

        public async Task<int> AddEmployeeSkill(int employeeId, int skillId)
        {
            var employeeSkill = new EmployeeSkill
            {
                EmployeeId = employeeId,
                SkillId = skillId
            };
            _db.EmployeeSkill.Add(employeeSkill);
            return _db.SaveChanges();
        }

        public async Task<int> DeleteEmployeeSkill(int employeeSkillId)
        {
            var employeeSkill = new EmployeeSkill
            {
                EmployeeSkillId = employeeSkillId
            };
            _db.EmployeeSkill.Remove(employeeSkill);
            return _db.SaveChanges();
        }
    }
}
