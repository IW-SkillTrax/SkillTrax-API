using Microsoft.EntityFrameworkCore;
using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public class EmployeeRepository
    {

        private readonly AppDbContext db;

        public EmployeeRepository(AppDbContext context)
        {
            db = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Employee> GetEmployees()
        {
            return db.Employee.ToList();
        }

        internal int AddEmployeeSkill(int employeeId, int skillId)
        {
            var employeeSkill = new EmployeeSkill
            {
                EmployeeId = employeeId,
                SkillId = skillId
            };
            db.EmployeeSkill.Add(employeeSkill);
            return db.SaveChanges();
        }

        internal IQueryable GetEmployee(int id)
        {
            return from e in db.Employee
                   where e.EmployeeId == id
                   select new
                   {
                       e.FirstName,
                       e.LastName,
                       e.RoleType.RoleName,
                       e.IsAdmin,
                       e.AdUniqueIdentifier
                   };
        }

        internal IQueryable GetEmployeeByAdUniqueId(string AdUniqueId)
        {
            return from e in db.Employee
                   where e.AdUniqueIdentifier == AdUniqueId
                   select new
                   {
                       e.EmployeeId,
                       e.FirstName,
                       e.LastName,
                       e.RoleType.RoleName,
                       e.IsAdmin,
                   };
        }

        internal IQueryable GetEmployeeSkills(int employeeId)
        {
            return from s in db.Skill
                   join es in db.EmployeeSkill on s.SkillId equals es.SkillId where es.EmployeeId == employeeId
                   join sts in db.SkillTypeSkill on s.SkillId equals sts.SkillId
                   join st in db.SkillType on sts.SkillTypeId equals st.SkillTypeId
                   join ss in db.SolutionSkill on s.SkillId equals ss.SkillId
                   join so in db.Solution on ss.SolutionId equals so.SolutionId
                   

                   select new SkillListItem
                   {
                       SkillId = s.SkillId,
                       SkillName = s.SkillName,
                       SkillTypeId = st.SkillTypeId,
                       SkillTypeName = st.SkillTypeName,
                       SolutionId = so.SolutionId,
                       SolutionIdName = so.SolutionName,
                       //EmployeeSkillId = es.EmployeeSkillId
                   };
        }

        internal IQueryable GetAvailableSkills(int employeeId)
        {

            //var x = db.Skill.Where(skill => skill.Employees.All(emp => emp.EmployeeId != employeeId));




            var userskills = from s in db.Skill
                             join es in db.EmployeeSkill on s.SkillId equals es.SkillId
                             where es.EmployeeId == employeeId
                             select s.SkillId;

            return from s in db.Skill
                   where !(userskills).Contains(s.SkillId)
                   join sts in db.SkillTypeSkill on s.SkillId equals sts.SkillId
                   join st in db.SkillType on sts.SkillTypeId equals st.SkillTypeId
                   join ss in db.SolutionSkill on s.SkillId equals ss.SkillId
                   join so in db.Solution on ss.SolutionId equals so.SolutionId

                   select new SkillListItem
                   {
                       SkillId = s.SkillId,
                       SkillName = s.SkillName,
                       SkillTypeId = st.SkillTypeId,
                       SkillTypeName = st.SkillTypeName,
                       SolutionId = so.SolutionId,
                       SolutionIdName = so.SolutionName,
                   };
        }

        internal int DeleteEmployeeSkill(int employeeSkillId)
        {
            var employeeSkill = new EmployeeSkill {
                //EmployeeSkillId = employeeSkillId
            };
            db.EmployeeSkill.Remove(employeeSkill);
            return db.SaveChanges();
        }
    }
}
