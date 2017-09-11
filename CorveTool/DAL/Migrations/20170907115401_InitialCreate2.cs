using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CorveTool.DAL.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Schedule_Task_ScheduleTaskId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Schedule_Task_ScheduleTaskId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Schedule_Task");

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

            migrationBuilder.CreateTable(
                name: "SchedulesTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaskId = table.Column<int>(type: "int", nullable: true),
                    scheduleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulesTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchedulesTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchedulesTasks_Schedules_scheduleId",
                        column: x => x.scheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchedulesTasks_TaskId",
                table: "SchedulesTasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulesTasks_scheduleId",
                table: "SchedulesTasks",
                column: "scheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchedulesTasks");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleTaskId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleTaskId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Schedule_Task",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule_Task", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ScheduleTaskId",
                table: "Tasks",
                column: "ScheduleTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ScheduleTaskId",
                table: "Schedules",
                column: "ScheduleTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Schedule_Task_ScheduleTaskId",
                table: "Schedules",
                column: "ScheduleTaskId",
                principalTable: "Schedule_Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Schedule_Task_ScheduleTaskId",
                table: "Tasks",
                column: "ScheduleTaskId",
                principalTable: "Schedule_Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
