using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoftPM.Server.Migrations
{
    public partial class Partial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_DepartmentId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_ProjectManagers_DepartmentId",
                table: "ProjectManagers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "ProjectManagers");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_DepartmentId",
                table: "TeamMembers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManagers_DepartmentId",
                table: "ProjectManagers",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_DepartmentId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_ProjectManagers_DepartmentId",
                table: "ProjectManagers");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "ProjectManagers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_DepartmentId",
                table: "TeamMembers",
                column: "DepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId",
                unique: true,
                filter: "[ProjectManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManagers_DepartmentId",
                table: "ProjectManagers",
                column: "DepartmentId",
                unique: true);
        }
    }
}
