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

        private readonly IEmployeeRepository repo;

        public EmployeeController(IEmployeeRepository _repo)
        {
            repo = _repo;
        }

        [Route(""), HttpGet]
        public List<Employee> GetEmployees()
        {
            return repo.GetEmployees(); 
        }

        [Route("{id}"), HttpGet]
        public Employee GetEmployee(int id)
        {
            
            return repo.GetEmployee(id);
        }

        [Route("ActiveDirectoryId/{adUniqueId}"), HttpGet]
        public Employee GetEmployeeByAdUniqueId(string adUniqueId)
        {
            
            return repo.GetEmployeeByAdUniqueId(adUniqueId);
        }

        [Route("{employeeId}/Skill/{skillId}"), HttpPost]
        public int AddEmployeeSkill(int employeeId, int skillId)
        {
           
            return repo.AddEmployeeSkill(employeeId, skillId);
        }

        [Route("EmployeeSkill/{employeeSkillId}"), HttpDelete]
        public int DeleteEmployeeSkill(int employeeSkillId)
        {
            
            return repo.DeleteEmployeeSkill(employeeSkillId);
        }

        [Route("{employeeId}/Skills"), HttpGet]
        public List<Skill> GetEmployeeSkill(int employeeId)
        {
            
            return repo.GetEmployeeSkills(employeeId);
        }

        [Route("{employeeId}/AvailableSkills"), HttpGet]
        public IQueryable GetAvailableSkills(int employeeId)
        {
            
            return repo.GetAvailableSkills(employeeId);
        }
    }
}