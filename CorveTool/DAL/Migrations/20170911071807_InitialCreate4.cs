using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CorveTool.DAL.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaksID",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "TasksID",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TasksID",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "TaksID",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);
        }
    }
}
