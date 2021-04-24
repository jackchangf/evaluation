using Microsoft.EntityFrameworkCore.Migrations;

namespace FormsIQD.Migrations
{
    public partial class radioanswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer1",
                table: "tblForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Radio1",
                table: "tblForms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer1",
                table: "tblForms");

            migrationBuilder.DropColumn(
                name: "Radio1",
                table: "tblForms");
        }
    }
}
