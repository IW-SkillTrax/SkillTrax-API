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
        public DbSet<EmployeeCertification> EmployeeCertification { get; set; }
        public DbSet<Certification> Certification { get; set; }
        public DbSet<CertificationCategory> CertificationCategory { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configures SolutionSkill intersection Entity
            modelBuilder.Entity<SolutionSkill>()
                .HasKey(SS => new { SS.SkillId, SS.SolutionId });
            modelBuilder.Entity<SolutionSkill>()
                .HasOne(SS => SS.Skill)
                .WithMany(S => S.SolutionSkills)
                .HasForeignKey(SS => SS.SkillId);
            modelBuilder.Entity<SolutionSkill>()
                .HasOne(SS => SS.Solution)
                .WithMany(S => S.SolutionSkills)
                .HasForeignKey(SS => SS.SolutionId);

            //configures SkillTypeSkill intersection Entity
            modelBuilder.Entity<SkillTypeSkill>()
                .HasKey(STS => new { STS.SkillId, STS.SkillTypeId });
            modelBuilder.Entity<SkillTypeSkill>()
                .HasOne(STS => STS.Skill)
                .WithMany(S => S.SkillTypeSkills)
                .HasForeignKey(STS => STS.SkillId);
            modelBuilder.Entity<SkillTypeSkill>()
                .HasOne(STS => STS.SkillType)
                .WithMany(ST => ST.SkillTypeSkills)
                .HasForeignKey(STS => STS.SkillTypeId);

            //configures EmployeeSkill intersection Entity
            modelBuilder.Entity<EmployeeSkill>()
                .HasKey(ES => new { ES.SkillId, ES.EmployeeId });
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
                .HasKey(EC => new { EC.EmployeeId, EC.CertificationId });
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
