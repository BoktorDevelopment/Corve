using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CorveTool.DAL.Migrations
{
    public partial class createdatabase5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckList_Tasks_TaskId",
                table: "CheckList");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "CheckList",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckList_Tasks_TaskId",
                table: "CheckList",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckList_Tasks_TaskId",
                table: "CheckList");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "CheckList",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckList_Tasks_TaskId",
                table: "CheckList",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
