using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_exam_lesson_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LessonId",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_LessonId",
                table: "Exams",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Lessions_LessonId",
                table: "Exams",
                column: "LessonId",
                principalTable: "Lessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Lessions_LessonId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_LessonId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Exams");
        }
    }
}
