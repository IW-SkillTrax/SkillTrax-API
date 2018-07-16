using Microsoft.EntityFrameworkCore;
using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SkillTrax.ViewModels;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly AppDbContext db;
        private readonly ISkillRepository skillrepo;

        public EmployeeRepository(AppDbContext context, ISkillRepository _skillRepo)
        {
            db = context ?? throw new ArgumentNullException(nameof(context));
            skillrepo = _skillRepo;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return db.Employee.ToList();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return db.Employee.FirstOrDefault(Employee => Employee.EmployeeId == id);
        }

        public async Task<Employee> GetEmployeeByAdUniqueId(string AdUniqueId)
        {

            return db.Employee.FirstOrDefault(Employee => Employee.AdUniqueIdentifier == AdUniqueId);

        }

        public async Task<List<Certification>> GetEmployeeCertifications(int employeeId)
        {
            List<EmployeeCertification> employeeCertifications = db.EmployeeCertification
                .Where(EC => EC.EmployeeId == employeeId).ToList();
            List<Certification> Certifications = new List<Certification>();
            foreach (EmployeeCertification employeeCertification in employeeCertifications)
            {
                Certifications.Add(db.Certification
                    .FirstOrDefault(C => C.CertificationId == employeeCertification.CertificationId));
            }
            return Certifications;
        }

        public async Task<List<Skill>> GetEmployeeSkills(int employeeId)
        {
            List<EmployeeSkill> employeeSkills = db.EmployeeSkill
                .Where(ES => ES.EmployeeId == employeeId).ToList();
            List<Skill> Skills = new List<Skill>();
            foreach (EmployeeSkill employeeSkill in employeeSkills)
            {
                Skills.Add(db.Skill.FirstOrDefault(S => S.SkillId == employeeSkill.SkillId));
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
            db.EmployeeSkill.Add(employeeSkill);
            return db.SaveChanges();
        }

        public async Task<int> DeleteEmployeeSkill(int employeeSkillId)
        {
            var employeeSkill = new EmployeeSkill
            {
                EmployeeSkillId = employeeSkillId
            };
            db.EmployeeSkill.Remove(employeeSkill);
            return db.SaveChanges();
        }
    }
}
