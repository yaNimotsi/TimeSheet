using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.DB.Migrations
{
    public partial class AddUserNameAndPasswordToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "TimeSheet",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                schema: "TimeSheet",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                schema: "TimeSheet",
                table: "User",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Id",
                schema: "TimeSheet",
                table: "Employee",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Id",
                schema: "TimeSheet",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Employee_Id",
                schema: "TimeSheet",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "TimeSheet",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserPassword",
                schema: "TimeSheet",
                table: "User");
        }
    }
}
