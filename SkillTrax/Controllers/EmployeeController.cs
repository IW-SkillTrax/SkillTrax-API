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
            try
            {
                List<EmployeeViewModel> employees = await _DataService.GetEmployeeViewModels();
                return Ok(employees);
            }
            catch(Exception e)
            {

            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                EmployeeViewModel employeeViewModel = await _DataService.GetEmployeeViewModel(id);
                if (employeeViewModel == null)
                {
                    return NotFound();
                }
                return Ok(employeeViewModel);
            }
            catch(Exception e)
            {

            }
            return BadRequest();
        }

        [HttpGet("ActiveDirectoryId/{adUniqueId}")]
        public async Task<IActionResult> GetEmployeeByAdUniqueId(string adUniqueId)
        {
            try
            {
                EmployeeViewModel employeeViewModel = await _DataService.GetEmployeeViewModelByAdUniqueId(adUniqueId);
                if (employeeViewModel == null)
                {
                    return NotFound();
                }
                return Ok(employeeViewModel);
            }
            catch(Exception e)
            {

            }
            return BadRequest();
        }
        
        [HttpPost("{employeeId}/AddSkill/{skillId}")]
        public async Task<IActionResult> AddEmployeeSkill(int employeeId, int skillId)
        {
            try
            {
                return Ok(await _DataService.AddEmployeeSkill(employeeId, skillId));
            }
            catch(Exception e)
            {

            }
            return BadRequest();
        }

        [HttpDelete("{employeeId}/RemoveSkill/{skillId}")]
        public async Task<IActionResult> DeleteEmployeeSkill(int employeeId, int skillId)
        {
            try
            {
                return Ok(await _DataService.DeleteEmployeeSkill(employeeId, skillId));
            }
            catch(Exception e)
            {

            }
            return BadRequest();
        }
    }
}