using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class reinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FullTextSearch = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    AccessFailedCount = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsAutoGrade = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_Exams_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    Explanation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSingleChoice = table.Column<bool>(type: "bit", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Score = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submissions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Submissions_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Correct = table.Column<bool>(type: "bit", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebUserChooses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WebUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebUserChooses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebUserChooses_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebUserChooses_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebUserChooses_Users_WebUserId",
                        column: x => x.WebUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("0a28cb14-bf71-4bdb-88d9-042d4e483bd6"), "User" },
                    { new Guid("b20f0149-7e57-4ddd-b013-e2f99b365212"), "Admin" },
                    { new Guid("d447eca5-6e58-4519-9211-6c098dca0285"), "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "Created", "Deleted", "Email", "FirstName", "FullName", "FullTextSearch", "Gender", "IsActive", "LastName", "Modified", "PasswordHash", "PasswordSalt", "PhoneNumber", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("2ba0dd5e-123f-488c-84ed-f2da5bc9dd68"), (short)0, new DateTime(2000, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 26, 8, 37, 52, 206, DateTimeKind.Utc).AddTicks(353), false, "ronaldo@example.com", "Cristiano", "Cristiano Ronaldo", "user Cristiano Ronaldo ronaldo@example.com 5555555555 Male", "Male", true, "Ronaldo", new DateTime(2024, 3, 26, 8, 37, 52, 206, DateTimeKind.Utc).AddTicks(353), new byte[] { 91, 243, 90, 44, 98, 190, 114, 185, 191, 155, 108, 164, 40, 195, 133, 128, 171, 36, 223, 232, 249, 7, 170, 6, 173, 75, 92, 23, 2, 9, 220, 206, 207, 208, 28, 33, 229, 206, 79, 128, 235, 251, 233, 46, 250, 106, 109, 11, 235, 7, 116, 130, 198, 104, 164, 50, 125, 160, 71, 202, 219, 243, 203, 227 }, new byte[] { 229, 30, 55, 249, 93, 28, 60, 217, 61, 172, 221, 230, 143, 155, 142, 169, 92, 114, 205, 76, 77, 160, 126, 69, 49, 126, 215, 169, 90, 57, 248, 218, 206, 15, 10, 102, 75, 38, 92, 86, 240, 120, 252, 45, 184, 156, 200, 224, 66, 64, 4, 246, 103, 55, 220, 119, 72, 220, 201, 172, 64, 250, 9, 5, 25, 34, 217, 68, 139, 65, 207, 76, 189, 143, 44, 254, 142, 165, 141, 15, 224, 11, 197, 130, 79, 26, 245, 200, 27, 110, 129, 39, 19, 246, 9, 26, 103, 151, 193, 39, 19, 28, 86, 193, 61, 94, 74, 4, 37, 55, 37, 42, 39, 9, 244, 190, 24, 153, 119, 233, 24, 212, 108, 92, 197, 92, 45, 229 }, "5555555555", new Guid("0a28cb14-bf71-4bdb-88d9-042d4e483bd6"), "user" },
                    { new Guid("67d68547-c1cf-47c1-a84f-8fa4185731bf"), (short)0, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 26, 8, 37, 52, 206, DateTimeKind.Utc).AddTicks(315), false, "teacher@example.com", "TeacherFirstName", "TeacherFirstName TeacherLastName", "teacher TeacherFirstName TeacherLastName teacher@example.com 9876543210 Female", "Female", true, "TeacherLastName", new DateTime(2024, 3, 26, 8, 37, 52, 206, DateTimeKind.Utc).AddTicks(315), new byte[] { 73, 25, 164, 89, 46, 251, 135, 75, 66, 15, 70, 3, 81, 149, 167, 25, 124, 68, 110, 223, 142, 27, 137, 60, 173, 111, 128, 65, 134, 150, 92, 100, 199, 200, 212, 187, 32, 67, 108, 238, 33, 105, 221, 53, 81, 183, 240, 231, 157, 26, 20, 20, 45, 193, 21, 230, 210, 215, 100, 73, 149, 146, 141, 122 }, new byte[] { 249, 3, 246, 57, 195, 17, 154, 232, 223, 20, 41, 88, 92, 89, 96, 171, 231, 215, 184, 254, 165, 177, 32, 189, 23, 152, 54, 74, 165, 182, 30, 33, 0, 228, 252, 210, 38, 177, 221, 185, 197, 42, 170, 200, 79, 219, 157, 241, 152, 106, 196, 225, 71, 84, 136, 229, 31, 145, 89, 20, 119, 241, 253, 29, 181, 46, 160, 36, 15, 190, 254, 191, 98, 174, 234, 121, 167, 217, 62, 11, 198, 1, 126, 181, 77, 72, 250, 20, 109, 55, 224, 74, 255, 116, 66, 199, 207, 53, 245, 235, 158, 70, 178, 188, 220, 159, 119, 141, 254, 230, 7, 246, 21, 170, 169, 96, 171, 236, 92, 18, 172, 35, 47, 160, 193, 184, 120, 60 }, "9876543210", new Guid("d447eca5-6e58-4519-9211-6c098dca0285"), "teacher" },
                    { new Guid("8f512463-eada-4c8e-b783-80c24d2d3e69"), (short)0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 26, 8, 37, 52, 206, DateTimeKind.Utc).AddTicks(245), false, "admin@example.com", "AdminFirstName", "AdminFirstName AdminLastName", "admin AdminFirstName AdminLastName admin@example.com 1234567890 Male", "Male", true, "AdminLastName", new DateTime(2024, 3, 26, 8, 37, 52, 206, DateTimeKind.Utc).AddTicks(247), new byte[] { 50, 132, 182, 2, 16, 174, 2, 5, 251, 220, 54, 29, 174, 98, 50, 146, 192, 209, 158, 32, 248, 93, 203, 47, 134, 239, 254, 125, 161, 138, 128, 118, 75, 59, 39, 110, 233, 206, 159, 10, 80, 21, 188, 214, 220, 140, 111, 37, 247, 106, 22, 154, 194, 165, 175, 130, 233, 57, 244, 101, 23, 157, 43, 77 }, new byte[] { 245, 160, 44, 80, 155, 5, 193, 24, 81, 44, 217, 50, 173, 170, 56, 248, 106, 235, 186, 10, 7, 96, 152, 222, 12, 145, 149, 129, 35, 27, 0, 76, 173, 205, 35, 129, 204, 151, 172, 108, 233, 172, 54, 179, 55, 145, 209, 17, 168, 70, 9, 71, 0, 57, 119, 217, 120, 18, 34, 4, 169, 190, 157, 171, 211, 67, 52, 39, 1, 139, 197, 174, 246, 177, 181, 103, 134, 55, 149, 59, 31, 16, 94, 93, 211, 82, 148, 64, 134, 78, 33, 103, 90, 239, 99, 5, 24, 115, 98, 73, 134, 15, 110, 231, 185, 138, 180, 249, 75, 69, 109, 141, 121, 182, 213, 26, 166, 108, 235, 10, 219, 4, 18, 10, 135, 92, 35, 189 }, "1234567890", new Guid("b20f0149-7e57-4ddd-b013-e2f99b365212"), "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_Id",
                table: "Answers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CreatedByUserId",
                table: "Exams",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ExamId",
                table: "Exams",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamId",
                table: "Questions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Id",
                table: "Questions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_ExamId",
                table: "Submissions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_Id",
                table: "Submissions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_StudentId",
                table: "Submissions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_WebUserChooses_AnswerId",
                table: "WebUserChooses",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_WebUserChooses_QuestionId",
                table: "WebUserChooses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_WebUserChooses_WebUserId",
                table: "WebUserChooses",
                column: "WebUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "WebUserChooses");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
