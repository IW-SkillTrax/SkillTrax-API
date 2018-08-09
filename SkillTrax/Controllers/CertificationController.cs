using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillTrax.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillTrax.Controllers
{
    [Route("[controller]")]
    public class CertificationController : Controller
    {
        private ICertificationDataService _dataService;
        public CertificationController(ICertificationDataService dataService)
        {
            _dataService = dataService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetCertifications()
        {
            try
            {
                return Ok(await _dataService.GetCertifications());
            }
            catch(Exception e)
            {

            }
            return BadRequest();
        }
        [HttpDelete("/Delete/{certificationId}")]
        public async Task<IActionResult> DeleteCertification(int certificationId)
        {
            try
            {
                return Ok( await _dataService.DeleteCertification(certificationId));
            }
            catch(Exception e)
            {

            }
            return BadRequest();
        }
    }
}
