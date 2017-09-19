using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CorveTool.DAL.Migrations
{
    public partial class updatecolums3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeekNumber",
                table: "ScheduleTask");

            migrationBuilder.AddColumn<int>(
                name: "Week",
                table: "ScheduleTask",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Week",
                table: "ScheduleTask");

            migrationBuilder.AddColumn<int>(
                name: "WeekNumber",
                table: "ScheduleTask",
                nullable: false,
                defaultValue: 0);
        }
    }
}
