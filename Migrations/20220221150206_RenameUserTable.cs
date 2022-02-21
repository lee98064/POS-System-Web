using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSSystemApi.Migrations
{
    public partial class RenameUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_POSSystemApi.Models.Users",
                table: "POSSystemApi.Models.Users");

            migrationBuilder.RenameTable(
                name: "POSSystemApi.Models.Users",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_POSSystemApi.Models.Users_email_account",
                table: "Users",
                newName: "IX_Users_email_account");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "POSSystemApi.Models.Users");

            migrationBuilder.RenameIndex(
                name: "IX_Users_email_account",
                table: "POSSystemApi.Models.Users",
                newName: "IX_POSSystemApi.Models.Users_email_account");

            migrationBuilder.AddPrimaryKey(
                name: "PK_POSSystemApi.Models.Users",
                table: "POSSystemApi.Models.Users",
                column: "Id");
        }
    }
}
