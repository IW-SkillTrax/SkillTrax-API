using Microsoft.EntityFrameworkCore;

namespace SkillTrax.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Solution> Solution { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<SkillType> SkillType { get; set; }
        public DbSet<SolutionSkill> SolutionSkill { get; set; }
        public DbSet<SkillTypeSkill> SkillTypeSkill { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkill { get; set; }
        public DbSet<RoleType> Role { get; set; }
        public DbSet<EmployeeCert> EmployeeCert { get; set; }
        public DbSet<Certification> Certification { get; set; }
        public DbSet<CertCategory> CertCategory { get; set; }
    }
}
