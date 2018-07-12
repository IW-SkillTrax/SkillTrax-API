using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillTrax.Migrations
{
    public partial class UpdatedCertificationNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Certificate_CertificateId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCert_Certificate_CertificateId",
                table: "EmployeeCert");

            migrationBuilder.RenameColumn(
                name: "CertificateId",
                table: "EmployeeCert",
                newName: "CertificationId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeCert_CertificateId",
                table: "EmployeeCert",
                newName: "IX_EmployeeCert_CertificationId");

            migrationBuilder.RenameColumn(
                name: "CertificateId",
                table: "Employee",
                newName: "CertificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_CertificateId",
                table: "Employee",
                newName: "IX_Employee_CertificationId");

            migrationBuilder.RenameColumn(
                name: "CertificateName",
                table: "Certificate",
                newName: "CertificationName");

            migrationBuilder.RenameColumn(
                name: "CertificateId",
                table: "Certificate",
                newName: "CertificationId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Certificate_CertificationId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCert_Certificate_CertificationId",
                table: "EmployeeCert");

            migrationBuilder.RenameColumn(
                name: "CertificationId",
                table: "EmployeeCert",
                newName: "CertificateId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeCert_CertificationId",
                table: "EmployeeCert",
                newName: "IX_EmployeeCert_CertificateId");

            migrationBuilder.RenameColumn(
                name: "CertificationId",
                table: "Employee",
                newName: "CertificateId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_CertificationId",
                table: "Employee",
                newName: "IX_Employee_CertificateId");

            migrationBuilder.RenameColumn(
                name: "CertificationName",
                table: "Certificate",
                newName: "CertificateName");

            migrationBuilder.RenameColumn(
                name: "CertificationId",
                table: "Certificate",
                newName: "CertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Certificate_CertificateId",
                table: "Employee",
                column: "CertificateId",
                principalTable: "Certificate",
                principalColumn: "CertificateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCert_Certificate_CertificateId",
                table: "EmployeeCert",
                column: "CertificateId",
                principalTable: "Certificate",
                principalColumn: "CertificateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
