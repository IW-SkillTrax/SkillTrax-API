using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SkillTrax.Models;
using SkillTrax.Services;

namespace SkillTrax.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {

        private readonly AppDbContext db;

        public EmployeeController(AppDbContext context)
        {
            db = context;
        }

        [Route(""), HttpGet]
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employee; 
        }

        [Route("{id}"), HttpGet]
        public IQueryable GetEmployee(int id)
        {
            var repo = new EmployeeRepository(db);
            return repo.GetEmployee(id);
        }

        [Route("ActiveDirectoryId/{adUniqueId}"), HttpGet]
        public IQueryable GetEmployeeByAdUniqueId(string adUniqueId)
        {
            var repo = new EmployeeRepository(db);
            return repo.GetEmployeeByAdUniqueId(adUniqueId);
        }

        [Route("{employeeId}/Skill/{skillId}"), HttpPost]
        public int AddEmployeeSkill(int employeeId, int skillId)
        {
            var repo = new EmployeeRepository(db);
            return repo.AddEmployeeSkill(employeeId, skillId);
        }

        [Route("EmployeeSkill/{employeeSkillId}"), HttpDelete]
        public int DeleteEmployeeSkill(int employeeSkillId)
        {
            var repo = new EmployeeRepository(db);
            return repo.DeleteEmployeeSkill(employeeSkillId);
        }

        [Route("{employeeId}/Skills"), HttpGet]
        public IQueryable GetEmployeeSkill(int employeeId)
        {
            var repo = new EmployeeRepository(db);
            return repo.GetEmployeeSkills(employeeId);
        }

        [Route("{employeeId}/AvailableSkills"), HttpGet]
        public IQueryable GetAvailableSkills(int employeeId)
        {
            var repo = new EmployeeRepository(db);
            return repo.GetAvailableSkills(employeeId);
        }
    }
}