using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CorveTool.DAL.Migrations
{
    public partial class createdatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckList_Tasks_taskId",
                table: "CheckList");

            migrationBuilder.RenameColumn(
                name: "taskId",
                table: "CheckList",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckList_taskId",
                table: "CheckList",
                newName: "IX_CheckList_TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckList_Tasks_TaskId",
                table: "CheckList",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckList_Tasks_TaskId",
                table: "CheckList");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "CheckList",
                newName: "taskId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckList_TaskId",
                table: "CheckList",
                newName: "IX_CheckList_taskId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckList_Tasks_taskId",
                table: "CheckList",
                column: "taskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
