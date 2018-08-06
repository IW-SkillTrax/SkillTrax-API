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

        public EmployeeRepository(AppDbContext context)
        {
            _db = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _db.Employee
                .Include(E => E.EmployeeCertifications)
                    .ThenInclude(EC => EC.Certification)
                        .ThenInclude(C => C.CertCategory)
                .Include(E => E.EmployeeSkills)
                    .ThenInclude(ES => ES.Skill)
                        .ThenInclude(S => S.Solution)
                 .Include(E => E.EmployeeSkills)
                    .ThenInclude(ES => ES.Skill)
                        .ThenInclude(S => S.SkillType)
                 .Include(E => E.RoleType)
                 .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _db.Employee
                .Include(E => E.EmployeeCertifications)
                    .ThenInclude(EC => EC.Certification)
                        .ThenInclude(C => C.CertCategory)
                .Include(E => E.EmployeeSkills)
                    .ThenInclude(ES => ES.Skill)
                        .ThenInclude(S => S.Solution)
                 .Include(E => E.EmployeeSkills)
                    .ThenInclude(ES => ES.Skill)
                        .ThenInclude(S => S.SkillType)
                 .Include(E => E.RoleType)
                 .AsNoTracking()
                .FirstOrDefaultAsync(Employee => Employee.EmployeeId == id);
                
        }

        public async Task<Employee> GetEmployeeByAdUniqueId(string AdUniqueId)
        {
            return await _db.Employee
                .Include(E => E.EmployeeCertifications)
                    .ThenInclude(EC => EC.Certification)
                        .ThenInclude(C => C.CertCategory)
                .Include(E => E.EmployeeSkills)
                    .ThenInclude(ES => ES.Skill)
                        .ThenInclude(S => S.Solution)
                 .Include(E => E.EmployeeSkills)
                    .ThenInclude(ES => ES.Skill)
                        .ThenInclude(S => S.SkillType)
                 .Include(E => E.RoleType)
                 .AsNoTracking()
                .FirstOrDefaultAsync(Employee => Employee.AdUniqueIdentifier == AdUniqueId);
        }

        
        public async Task<List<Certification>> GetEmployeeCertifications(int employeeId)
        {
            List<EmployeeCertification> employeeCertifications = await _db.EmployeeCertification
                .Include(EC => EC.Certification)
                .Where(EC => EC.EmployeeId == employeeId)
                .AsNoTracking()
                .ToListAsync();
            List<Certification> Certifications = new List<Certification>();
           foreach(EmployeeCertification employeeCert in employeeCertifications)
            {
                Certifications.Add(employeeCert.Certification);
            }
            return Certifications;
        }

        public async Task<List<Skill>> GetEmployeeSkills(int employeeId)
        {
            List<EmployeeSkill> employeeSkills = await _db.EmployeeSkill
                .Include(ES => ES.Skill)
                .Where(ES => ES.EmployeeId == employeeId)
                .AsNoTracking()
                .ToListAsync();
            List<Skill> Skills = new List<Skill>();
            foreach (EmployeeSkill employeeSkill in employeeSkills)
            {
                Skills.Add(employeeSkill.Skill);
            }
            return Skills;
        }

        public async Task<int> AddEmployeeSkill(int employeeId, int skillId)
        {
            EmployeeSkill employeeSkill = new EmployeeSkill
            {
                EmployeeId = employeeId,
                SkillId = skillId
            };
            _db.EmployeeSkill.Add(employeeSkill);
            return _db.SaveChanges();
        }
        public async Task<int> DeleteEmployeeSkill(int employeeId, int skillId)
        {
            EmployeeSkill employeeSkill = await _db.EmployeeSkill.FirstOrDefaultAsync(x => x.SkillId == skillId && x.EmployeeId == employeeId);
            _db.EmployeeSkill.Remove(employeeSkill);
            return _db.SaveChanges();
        }
        public async Task<int> DeleteEmployeeCertification(int employeeId, int certificationId)
        {
            EmployeeCertification employeeCert = await _db.EmployeeCertification.FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.CertificationId == certificationId);
            _db.EmployeeCertification.Remove(employeeCert);
            return _db.SaveChanges();
        }
        public async Task<int> AddEmployeeCertification(int employeeId, int certificationId)
        {
            EmployeeCertification employeeCert = new EmployeeCertification
            {
                EmployeeId = employeeId,
                CertificationId = certificationId
            };
            _db.EmployeeCertification.Add(employeeCert);
            return _db.SaveChanges();
        }
    }
}
