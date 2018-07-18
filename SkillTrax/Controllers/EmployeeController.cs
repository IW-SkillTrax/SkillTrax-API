using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
            List<EmployeeViewModel> employees = await _DataService.GetEmployeeViewModels();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            if(id < 1)
            {
                return NotFound();
            }
            EmployeeViewModel employeeViewModel = await _DataService.GetEmployeeViewModel(id);
            if(employeeViewModel == null)
            {
                return NotFound();
            }
            return Ok(employeeViewModel);
        }

        [HttpGet("ActiveDirectoryId/{adUniqueId}")]
        public async Task<IActionResult> GetEmployeeByAdUniqueId(string adUniqueId)
        {
            EmployeeViewModel employeeViewModel = await _DataService.GetEmployeeViewModelByAdUniqueId(adUniqueId);
            if (employeeViewModel == null)
            {
                return NotFound();
            }
            return Ok(employeeViewModel);
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