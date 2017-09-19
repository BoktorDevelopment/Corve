using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CorveTool.DAL.Migrations
{
    public partial class InitialCreate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Schedules_SchedulesId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_SchedulesId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "SchedulesId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ScheduleID",
                table: "ScheduleTask");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchedulesId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleID",
                table: "ScheduleTask",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_SchedulesId",
                table: "Tasks",
                column: "SchedulesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Schedules_SchedulesId",
                table: "Tasks",
                column: "SchedulesId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
