using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillTrax.Models;
using SkillTrax.Services;

namespace SkillTrax.Controllers
{
    [Produces("application/json")]
    [Route("api/Skill")]
    public class SkillController : Controller
    {
        private readonly AppDbContext db;

        public SkillController(AppDbContext context)
        {
            db = context;
        }

        [Route(""), HttpGet]
        public IQueryable<SkillListItem> GetSkillsList()
        {
            var repo = new SkillRepository(db);
            return repo.GetSkillList(); 
        }


    }
}