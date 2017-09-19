using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CorveTool.DAL.Migrations
{
    public partial class InitialCreatenewdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "ScheduleTask");

            migrationBuilder.AddColumn<int>(
                name: "SchedulesId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchedulesId",
                table: "ScheduleTask",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleTask",
                table: "ScheduleTask",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    When = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_SchedulesId",
                table: "Tasks",
                column: "SchedulesId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTask_SchedulesId",
                table: "ScheduleTask",
                column: "SchedulesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleTask_Schedules_SchedulesId",
                table: "ScheduleTask",
                column: "SchedulesId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Schedules_SchedulesId",
                table: "Tasks",
                column: "SchedulesId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleTask_Schedules_SchedulesId",
                table: "ScheduleTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Schedules_SchedulesId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_SchedulesId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleTask",
                table: "ScheduleTask");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleTask_SchedulesId",
                table: "ScheduleTask");

            migrationBuilder.DropColumn(
                name: "SchedulesId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "SchedulesId",
                table: "ScheduleTask");

            migrationBuilder.RenameTable(
                name: "ScheduleTask",
                newName: "Schedules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Id");
        }
    }
}
