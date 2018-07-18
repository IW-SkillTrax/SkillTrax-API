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
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkill { get; set; }
        public DbSet<RoleType> Role { get; set; }
        public DbSet<EmployeeCertification> EmployeeCertification { get; set; }
        public DbSet<Certification> Certification { get; set; }
        public DbSet<CertificationCategory> CertificationCategory { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configures EmployeeSkill intersection Entity
            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(ES => ES.Skill)
                .WithMany(S => S.EmployeeSkills)
                .HasForeignKey(ES => ES.SkillId);
            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(ES => ES.Employee)
                .WithMany(E => E.EmployeeSkills)
                .HasForeignKey(ES => ES.EmployeeId);

            //configures EmployeeCertification intersection Entity
            modelBuilder.Entity<EmployeeCertification>()
                .HasOne(EC => EC.Certification)
                .WithMany(C => C.EmployeeCertifications)
                .HasForeignKey(EC => EC.CertificationId);
            modelBuilder.Entity<EmployeeCertification>()
                .HasOne(EC => EC.Employee)
                .WithMany(E => E.EmployeeCertifications)
                .HasForeignKey(EC => EC.EmployeeId);
        }
    }
}
