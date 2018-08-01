using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillTrax.Migrations
{
    public partial class RemovedManyToManys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillTypeSkill");

            migrationBuilder.DropTable(
                name: "SolutionSkill");

            migrationBuilder.AddColumn<int>(
                name: "SkillTypeId",
                table: "Skill",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SolutionId",
                table: "Skill",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SkillTypeId",
                table: "Skill",
                column: "SkillTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SolutionId",
                table: "Skill",
                column: "SolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_SkillType_SkillTypeId",
                table: "Skill",
                column: "SkillTypeId",
                principalTable: "SkillType",
                principalColumn: "SkillTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Solution_SolutionId",
                table: "Skill",
                column: "SolutionId",
                principalTable: "Solution",
                principalColumn: "SolutionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_SkillType_SkillTypeId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Solution_SolutionId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_SkillTypeId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_SolutionId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "SkillTypeId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "SolutionId",
                table: "Skill");

            migrationBuilder.CreateTable(
                name: "SkillTypeSkill",
                columns: table => new
                {
                    SkillTypeSkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillId = table.Column<int>(nullable: false),
                    SkillTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTypeSkill", x => x.SkillTypeSkillId);
                    table.ForeignKey(
                        name: "FK_SkillTypeSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillTypeSkill_SkillType_SkillTypeId",
                        column: x => x.SkillTypeId,
                        principalTable: "SkillType",
                        principalColumn: "SkillTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolutionSkill",
                columns: table => new
                {
                    SolutionSkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillId = table.Column<int>(nullable: false),
                    SolutionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionSkill", x => x.SolutionSkillId);
                    table.ForeignKey(
                        name: "FK_SolutionSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolutionSkill_Solution_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solution",
                        principalColumn: "SolutionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillTypeSkill_SkillId",
                table: "SkillTypeSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTypeSkill_SkillTypeId",
                table: "SkillTypeSkill",
                column: "SkillTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionSkill_SkillId",
                table: "SolutionSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionSkill_SolutionId",
                table: "SolutionSkill",
                column: "SolutionId");
        }
    }
}
