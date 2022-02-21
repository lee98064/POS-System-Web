using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSSystemApi.Migrations
{
    public partial class AddEmailIntoUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "POSSystemApi.Models.Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_POSSystemApi.Models.Users_email_account",
                table: "POSSystemApi.Models.Users",
                columns: new[] { "email", "account" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_POSSystemApi.Models.Users_email_account",
                table: "POSSystemApi.Models.Users");

            migrationBuilder.DropColumn(
                name: "email",
                table: "POSSystemApi.Models.Users");
        }
    }
}
