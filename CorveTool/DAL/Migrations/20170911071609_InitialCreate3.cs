using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CorveTool.DAL.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Schedules_ScheduleTaskId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Schedules_ScheduleTaskId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ScheduleTaskId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_ScheduleTaskId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ScheduleTaskId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ScheduleTaskId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "When",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleID",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaksID",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleID",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TaksID",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleTaskId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleTaskId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "When",
                table: "Schedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ScheduleTaskId",
                table: "Tasks",
                column: "ScheduleTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ScheduleTaskId",
                table: "Schedules",
                column: "ScheduleTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Schedules_ScheduleTaskId",
                table: "Schedules",
                column: "ScheduleTaskId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Schedules_ScheduleTaskId",
                table: "Tasks",
                column: "ScheduleTaskId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
