using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillTrax.Migrations
{
    public partial class ModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certification_CertCategory_CertCategoryId",
                table: "Certification");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Certification_CertificationId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Role_RoleTypeId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Skill_SkillId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "CertCategory");

            migrationBuilder.DropTable(
                name: "EmployeeCert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolutionSkill",
                table: "SolutionSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillTypeSkill",
                table: "SkillTypeSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSkill",
                table: "EmployeeSkill");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSkill_SkillId",
                table: "EmployeeSkill");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CertificationId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_RoleTypeId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SolutionSkillId",
                table: "SolutionSkill");

            migrationBuilder.DropColumn(
                name: "SkillTypeSkillId",
                table: "SkillTypeSkill");

            migrationBuilder.DropColumn(
                name: "EmployeeSkillId",
                table: "EmployeeSkill");

            migrationBuilder.DropColumn(
                name: "CertificationId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "RoleTypeId",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "Employee",
                newName: "RoleTypeRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_SkillId",
                table: "Employee",
                newName: "IX_Employee_RoleTypeRoleId");

            migrationBuilder.AlterColumn<int>(
                name: "CertCategoryId",
                table: "Certification",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolutionSkill",
                table: "SolutionSkill",
                columns: new[] { "SkillId", "SolutionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillTypeSkill",
                table: "SkillTypeSkill",
                columns: new[] { "SkillId", "SkillTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSkill",
                table: "EmployeeSkill",
                columns: new[] { "SkillId", "EmployeeId" });

            migrationBuilder.CreateTable(
                name: "CertificationCategory",
                columns: table => new
                {
                    CertCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CertCategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationCategory", x => x.CertCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCertification",
                columns: table => new
                {
                    CertificationId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCertification", x => new { x.EmployeeId, x.CertificationId });
                    table.ForeignKey(
                        name: "FK_EmployeeCertification_Certification_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certification",
                        principalColumn: "CertificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCertification_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolutionSkill_SolutionId",
                table: "SolutionSkill",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTypeSkill_SkillTypeId",
                table: "SkillTypeSkill",
                column: "SkillTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCertification_CertificationId",
                table: "EmployeeCertification",
                column: "CertificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certification_CertificationCategory_CertCategoryId",
                table: "Certification",
                column: "CertCategoryId",
                principalTable: "CertificationCategory",
                principalColumn: "CertCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Role_RoleTypeRoleId",
                table: "Employee",
                column: "RoleTypeRoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillTypeSkill_Skill_SkillId",
                table: "SkillTypeSkill",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillTypeSkill_SkillType_SkillTypeId",
                table: "SkillTypeSkill",
                column: "SkillTypeId",
                principalTable: "SkillType",
                principalColumn: "SkillTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionSkill_Skill_SkillId",
                table: "SolutionSkill",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionSkill_Solution_SolutionId",
                table: "SolutionSkill",
                column: "SolutionId",
                principalTable: "Solution",
                principalColumn: "SolutionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certification_CertificationCategory_CertCategoryId",
                table: "Certification");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Role_RoleTypeRoleId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillTypeSkill_Skill_SkillId",
                table: "SkillTypeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillTypeSkill_SkillType_SkillTypeId",
                table: "SkillTypeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionSkill_Skill_SkillId",
                table: "SolutionSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionSkill_Solution_SolutionId",
                table: "SolutionSkill");

            migrationBuilder.DropTable(
                name: "CertificationCategory");

            migrationBuilder.DropTable(
                name: "EmployeeCertification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolutionSkill",
                table: "SolutionSkill");

            migrationBuilder.DropIndex(
                name: "IX_SolutionSkill_SolutionId",
                table: "SolutionSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillTypeSkill",
                table: "SkillTypeSkill");

            migrationBuilder.DropIndex(
                name: "IX_SkillTypeSkill_SkillTypeId",
                table: "SkillTypeSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSkill",
                table: "EmployeeSkill");

            migrationBuilder.RenameColumn(
                name: "RoleTypeRoleId",
                table: "Employee",
                newName: "SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_RoleTypeRoleId",
                table: "Employee",
                newName: "IX_Employee_SkillId");

            migrationBuilder.AddColumn<int>(
                name: "SolutionSkillId",
                table: "SolutionSkill",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "SkillTypeSkillId",
                table: "SkillTypeSkill",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeSkillId",
                table: "EmployeeSkill",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "CertificationId",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleTypeId",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CertCategoryId",
                table: "Certification",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolutionSkill",
                table: "SolutionSkill",
                column: "SolutionSkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillTypeSkill",
                table: "SkillTypeSkill",
                column: "SkillTypeSkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSkill",
                table: "EmployeeSkill",
                column: "EmployeeSkillId");

            migrationBuilder.CreateTable(
                name: "CertCategory",
                columns: table => new
                {
                    CertCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CertCategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertCategory", x => x.CertCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCert",
                columns: table => new
                {
                    EmployeeCertId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CertificationId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCert", x => x.EmployeeCertId);
                    table.ForeignKey(
                        name: "FK_EmployeeCert_Certification_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certification",
                        principalColumn: "CertificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCert_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_SkillId",
                table: "EmployeeSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CertificationId",
                table: "Employee",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleTypeId",
                table: "Employee",
                column: "RoleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCert_CertificationId",
                table: "EmployeeCert",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCert_SkillId",
                table: "EmployeeCert",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certification_CertCategory_CertCategoryId",
                table: "Certification",
                column: "CertCategoryId",
                principalTable: "CertCategory",
                principalColumn: "CertCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Certification_CertificationId",
                table: "Employee",
                column: "CertificationId",
                principalTable: "Certification",
                principalColumn: "CertificationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Role_RoleTypeId",
                table: "Employee",
                column: "RoleTypeId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Skill_SkillId",
                table: "Employee",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
