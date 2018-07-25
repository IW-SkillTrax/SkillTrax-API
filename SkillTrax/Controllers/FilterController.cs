using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillTrax.Services;
using SkillTrax.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillTrax.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class FilterController : Controller
    {
        private readonly IFilterDataService _dataService;

        public FilterController(IFilterDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("")]
        public async Task<IActionResult> getFilters()
        {
            List <FilterViewModel>filters = await _dataService.getFilters();
                return Ok(filters);
            
            
        }
    }
}
