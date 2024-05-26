using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_answer_question_translation_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageCode = table.Column<string>(type: "varchar(5)", nullable: false),
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerTranslations_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerTranslations_LanguageTags_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "LanguageTags",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageCode = table.Column<string>(type: "varchar(5)", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionTranslations_LanguageTags_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "LanguageTags",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionTranslations_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerTranslations_AnswerId",
                table: "AnswerTranslations",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerTranslations_Id",
                table: "AnswerTranslations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerTranslations_LanguageCode",
                table: "AnswerTranslations",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTranslations_Id",
                table: "QuestionTranslations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTranslations_LanguageCode",
                table: "QuestionTranslations",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTranslations_QuestionId",
                table: "QuestionTranslations",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerTranslations");

            migrationBuilder.DropTable(
                name: "QuestionTranslations");
        }
    }
}
