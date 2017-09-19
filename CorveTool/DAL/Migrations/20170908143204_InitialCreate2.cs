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
                name: "FK_Tasks_Schedule_Task_ScheduleTaskId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule_Task",
                table: "Schedule_Task");

            migrationBuilder.RenameTable(
                name: "Schedule_Task",
                newName: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleTaskId",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "When",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Schedules_ScheduleTaskId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Schedules_ScheduleTaskId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_ScheduleTaskId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ScheduleTaskId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "When",
                table: "Schedules");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule_Task");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule_Task",
                table: "Schedule_Task",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScheduleTaskId = table.Column<int>(nullable: true),
                    When = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Schedule_Task_ScheduleTaskId",
                        column: x => x.ScheduleTaskId,
                        principalTable: "Schedule_Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ScheduleTaskId",
                table: "Schedules",
                column: "ScheduleTaskId");

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
