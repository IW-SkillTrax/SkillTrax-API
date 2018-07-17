using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillTrax.Services;
using SkillTrax.ViewModels;

namespace SkillTrax.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class SkillController : Controller
    {
        private readonly ISkillDataService _dataService;

        public SkillController(ISkillDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetSkills()
        {
            return Ok(await _dataService.GetSkillViewModels());
        }
    }
}