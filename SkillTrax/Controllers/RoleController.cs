using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillTrax.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillTrax.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleDataService _dataService; 
        public RoleController(IRoleDataService dataService)
        {
            _dataService = dataService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                return Ok(await _dataService.getRoles());
            }
            catch (Exception e)
            {

            }
            return BadRequest();
        }
    }
}
