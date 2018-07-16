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
using SkillTrax.ViewModels;

namespace SkillTrax.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeDataService _DataService;

        public EmployeeController(IEmployeeDataService DataService)
        {
            _DataService = DataService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _DataService.GetEmployeeViewModels());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return Ok(await _DataService.GetEmployeeViewModel(id));
        }

        [HttpGet("ActiveDirectoryId/{adUniqueId}")]
        public async Task<IActionResult> GetEmployeeByAdUniqueId(string adUniqueId)
        {
            return Ok(await _DataService.GetEmployeeViewModelByAdUniqueId(adUniqueId));
        }

        [HttpPost("{employeeId}/Skill/{skillId}")]
        public async Task<IActionResult> AddEmployeeSkill(int employeeId, int skillId)
        {
            return Ok( await _DataService.AddEmployeeSkill(employeeId, skillId));
        }

        [HttpDelete("EmployeeSkill/{employeeSkillId}")]
        public async Task<IActionResult> DeleteEmployeeSkill(int employeeSkillId)
        {
            return Ok(await _DataService.DeleteEmployeeSkill(employeeSkillId));
        }
       
    }
}