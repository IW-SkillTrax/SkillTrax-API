using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillTrax.Migrations
{
    public partial class updatedCertNameAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_CertificateCategory_CertCategoryId",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Certificate_CertificationId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCert_Certificate_CertificationId",
                table: "EmployeeCert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificateCategory",
                table: "CertificateCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificate",
                table: "Certificate");

            migrationBuilder.RenameTable(
                name: "CertificateCategory",
                newName: "CertCategory");

            migrationBuilder.RenameTable(
                name: "Certificate",
                newName: "Certification");

            migrationBuilder.RenameIndex(
                name: "IX_Certificate_CertCategoryId",
                table: "Certification",
                newName: "IX_Certification_CertCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertCategory",
                table: "CertCategory",
                column: "CertCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certification",
                table: "Certification",
                column: "CertificationId");

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
                name: "FK_EmployeeCert_Certification_CertificationId",
                table: "EmployeeCert",
                column: "CertificationId",
                principalTable: "Certification",
                principalColumn: "CertificationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certification_CertCategory_CertCategoryId",
                table: "Certification");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Certification_CertificationId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCert_Certification_CertificationId",
                table: "EmployeeCert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certification",
                table: "Certification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertCategory",
                table: "CertCategory");

            migrationBuilder.RenameTable(
                name: "Certification",
                newName: "Certificate");

            migrationBuilder.RenameTable(
                name: "CertCategory",
                newName: "CertificateCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Certification_CertCategoryId",
                table: "Certificate",
                newName: "IX_Certificate_CertCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificate",
                table: "Certificate",
                column: "CertificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificateCategory",
                table: "CertificateCategory",
                column: "CertCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_CertificateCategory_CertCategoryId",
                table: "Certificate",
                column: "CertCategoryId",
                principalTable: "CertificateCategory",
                principalColumn: "CertCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Certificate_CertificationId",
                table: "Employee",
                column: "CertificationId",
                principalTable: "Certificate",
                principalColumn: "CertificationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCert_Certificate_CertificationId",
                table: "EmployeeCert",
                column: "CertificationId",
                principalTable: "Certificate",
                principalColumn: "CertificationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
