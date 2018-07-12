using SkillTrax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public class SkillRepository
    {
        private readonly AppDbContext db;

        public SkillRepository(AppDbContext context)
        {
            db = context;
        }

        public IQueryable<SkillListItem> GetSkillList()
        {
            return from s in db.Skill
                   join sts in db.SkillTypeSkill on s.SkillId equals sts.SkillId
                   join st in db.SkillType on sts.SkillTypeId equals st.SkillTypeId
                   join ss in db.SolutionSkill on s.SkillId equals ss.SkillId
                   join so in db.Solution on ss.SolutionId equals so.SolutionId
                   select new SkillListItem
                   {
                       SkillId = s.SkillId,
                       SkillName = s.SkillName,
                       SkillTypeId = st.SkillTypeId,
                       SkillTypeName = st.SkillTypeName,
                       SolutionId = so.SolutionId,
                       SolutionIdName = so.SolutionName
                   };

        }
    }
}

