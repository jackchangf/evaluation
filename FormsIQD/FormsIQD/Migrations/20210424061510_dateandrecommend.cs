using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormsIQD.Migrations
{
    public partial class dateandrecommend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CourseEnd",
                table: "tblForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CourseStart",
                table: "tblForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "WillRecommend",
                table: "tblForms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseEnd",
                table: "tblForms");

            migrationBuilder.DropColumn(
                name: "CourseStart",
                table: "tblForms");

            migrationBuilder.DropColumn(
                name: "WillRecommend",
                table: "tblForms");
        }
    }
}
