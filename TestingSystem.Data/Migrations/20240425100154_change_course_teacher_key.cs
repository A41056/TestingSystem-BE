using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class change_course_teacher_key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0a9f122b-0d82-4fda-9bb5-18f87b28297b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6d1f9a6f-4214-4303-bf6a-c64eae92bb8a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6a2c7d9-ae87-4e18-842e-b9c01ec3a3ed"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("56f2308e-3077-473a-bdd0-47988989f981"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("d8df8fe9-d4eb-4383-b774-e72e427a4119"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("fd6a976d-d87f-4df7-a3ea-a8c6741b6dcf"));

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "CourseTeachers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "en-EN",
                column: "Created",
                value: new DateTime(2024, 4, 25, 10, 1, 53, 535, DateTimeKind.Utc).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "ru-RU",
                column: "Created",
                value: new DateTime(2024, 4, 25, 10, 1, 53, 535, DateTimeKind.Utc).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "vi-VN",
                column: "Created",
                value: new DateTime(2024, 4, 25, 10, 1, 53, 535, DateTimeKind.Utc).AddTicks(7761));

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1191aa8d-4cbe-49da-a544-071ce5de311c"), "User" },
                    { new Guid("504736c0-f5d4-44d0-a87c-5ef2be6ab4ec"), "Admin" },
                    { new Guid("eef1797a-271a-45e7-b260-3356fdb7af25"), "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "Created", "Deleted", "Email", "FirstName", "FullName", "FullTextSearch", "Gender", "IsActive", "LastName", "Modified", "PasswordHash", "PasswordSalt", "PhoneNumber", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("49cf5c8d-56f0-4145-87d5-bcefd9529d0f"), (short)0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 10, 1, 53, 535, DateTimeKind.Utc).AddTicks(7616), false, "admin@example.com", "AdminFirstName", "AdminFirstName AdminLastName", "admin AdminFirstName AdminLastName admin@example.com 1234567890 Male", "Male", true, "AdminLastName", new DateTime(2024, 4, 25, 10, 1, 53, 535, DateTimeKind.Utc).AddTicks(7619), new byte[] { 166, 136, 179, 125, 208, 88, 33, 107, 157, 158, 165, 42, 64, 42, 71, 251, 172, 61, 0, 113, 124, 99, 39, 197, 240, 38, 15, 123, 34, 74, 176, 39, 126, 185, 66, 135, 52, 246, 195, 221, 215, 106, 138, 213, 210, 83, 104, 182, 57, 122, 137, 221, 76, 93, 60, 55, 46, 217, 137, 57, 142, 69, 77, 131 }, new byte[] { 203, 102, 98, 240, 175, 107, 204, 126, 191, 222, 74, 200, 78, 72, 6, 126, 36, 249, 136, 241, 215, 206, 62, 1, 207, 157, 172, 164, 168, 149, 71, 127, 139, 171, 93, 51, 113, 159, 131, 224, 55, 67, 250, 197, 93, 129, 27, 176, 230, 151, 31, 20, 174, 169, 111, 5, 171, 166, 228, 140, 136, 163, 159, 171, 60, 164, 68, 2, 176, 203, 28, 118, 4, 6, 208, 163, 79, 226, 53, 137, 239, 170, 16, 210, 96, 233, 50, 48, 147, 19, 92, 234, 244, 85, 180, 172, 174, 250, 113, 88, 181, 65, 172, 185, 35, 193, 21, 85, 57, 126, 104, 133, 194, 148, 126, 221, 21, 203, 55, 42, 9, 178, 0, 57, 34, 92, 142, 93 }, "1234567890", new Guid("504736c0-f5d4-44d0-a87c-5ef2be6ab4ec"), "admin" },
                    { new Guid("714553a0-307e-4b13-901c-44b3262b733a"), (short)0, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 10, 1, 53, 535, DateTimeKind.Utc).AddTicks(7673), false, "teacher@example.com", "TeacherFirstName", "TeacherFirstName TeacherLastName", "teacher TeacherFirstName TeacherLastName teacher@example.com 9876543210 Female", "Female", true, "TeacherLastName", new DateTime(2024, 4, 25, 10, 1, 53, 535, DateTimeKind.Utc).AddTicks(7674), new byte[] { 172, 25, 143, 165, 103, 48, 129, 54, 100, 229, 247, 3, 139, 182, 133, 239, 129, 97, 209, 166, 118, 61, 113, 95, 164, 215, 244, 159, 170, 158, 199, 84, 173, 64, 74, 157, 208, 88, 51, 254, 244, 246, 27, 162, 92, 222, 9, 97, 140, 99, 52, 173, 219, 107, 47, 246, 19, 191, 197, 4, 174, 255, 250, 68 }, new byte[] { 9, 63, 52, 1, 78, 170, 151, 103, 196, 170, 137, 43, 12, 74, 210, 121, 255, 147, 142, 47, 147, 225, 177, 175, 4, 246, 34, 37, 135, 226, 112, 108, 102, 136, 231, 189, 113, 56, 237, 20, 76, 176, 40, 167, 243, 22, 175, 255, 193, 217, 188, 159, 167, 153, 113, 244, 138, 236, 127, 81, 47, 244, 248, 119, 31, 92, 194, 229, 255, 156, 137, 90, 34, 154, 120, 229, 69, 193, 104, 34, 136, 54, 155, 138, 9, 171, 160, 3, 68, 241, 249, 170, 56, 233, 7, 43, 59, 70, 121, 190, 108, 236, 102, 89, 198, 208, 201, 251, 185, 121, 145, 212, 92, 216, 170, 97, 124, 233, 123, 243, 2, 45, 118, 251, 90, 186, 232, 241 }, "9876543210", new Guid("eef1797a-271a-45e7-b260-3356fdb7af25"), "teacher" },
                    { new Guid("adc4002b-f2f2-4f8a-b1a4-5e8da6299c2c"), (short)0, new DateTime(2000, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 10, 1, 53, 535, DateTimeKind.Utc).AddTicks(7716), false, "ronaldo@example.com", "Cristiano", "Cristiano Ronaldo", "user Cristiano Ronaldo ronaldo@example.com 5555555555 Male", "Male", true, "Ronaldo", new DateTime(2024, 4, 25, 10, 1, 53, 535, DateTimeKind.Utc).AddTicks(7716), new byte[] { 6, 50, 124, 171, 3, 64, 198, 50, 219, 81, 14, 94, 241, 150, 237, 116, 23, 146, 226, 213, 161, 32, 241, 31, 91, 219, 215, 136, 193, 248, 181, 126, 245, 8, 94, 224, 35, 18, 87, 52, 130, 137, 7, 58, 104, 185, 168, 208, 104, 172, 191, 8, 147, 4, 127, 252, 177, 181, 49, 14, 158, 189, 219, 59 }, new byte[] { 131, 170, 178, 100, 159, 57, 190, 97, 204, 242, 13, 20, 170, 226, 31, 149, 58, 144, 200, 235, 162, 146, 233, 146, 142, 14, 61, 202, 70, 183, 30, 34, 157, 181, 204, 21, 44, 42, 79, 108, 104, 253, 127, 144, 223, 185, 91, 223, 232, 142, 221, 4, 35, 240, 174, 181, 202, 203, 202, 238, 213, 205, 49, 38, 68, 115, 20, 252, 62, 242, 48, 209, 152, 129, 112, 142, 117, 193, 63, 53, 59, 0, 22, 95, 64, 15, 158, 95, 196, 119, 27, 195, 12, 122, 44, 24, 86, 204, 45, 14, 72, 116, 90, 238, 11, 61, 6, 236, 90, 136, 182, 57, 151, 126, 9, 237, 255, 125, 39, 88, 142, 203, 144, 177, 160, 209, 79, 245 }, "5555555555", new Guid("1191aa8d-4cbe-49da-a544-071ce5de311c"), "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeachers_TeacherId",
                table: "CourseTeachers",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeachers_Users_TeacherId",
                table: "CourseTeachers",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeachers_Users_TeacherId",
                table: "CourseTeachers");

            migrationBuilder.DropIndex(
                name: "IX_CourseTeachers_TeacherId",
                table: "CourseTeachers");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("49cf5c8d-56f0-4145-87d5-bcefd9529d0f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("714553a0-307e-4b13-901c-44b3262b733a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("adc4002b-f2f2-4f8a-b1a4-5e8da6299c2c"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("1191aa8d-4cbe-49da-a544-071ce5de311c"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("504736c0-f5d4-44d0-a87c-5ef2be6ab4ec"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("eef1797a-271a-45e7-b260-3356fdb7af25"));

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "CourseTeachers");

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "en-EN",
                column: "Created",
                value: new DateTime(2024, 4, 25, 7, 53, 54, 742, DateTimeKind.Utc).AddTicks(7025));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "ru-RU",
                column: "Created",
                value: new DateTime(2024, 4, 25, 7, 53, 54, 742, DateTimeKind.Utc).AddTicks(7027));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "vi-VN",
                column: "Created",
                value: new DateTime(2024, 4, 25, 7, 53, 54, 742, DateTimeKind.Utc).AddTicks(7022));

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("56f2308e-3077-473a-bdd0-47988989f981"), "User" },
                    { new Guid("d8df8fe9-d4eb-4383-b774-e72e427a4119"), "Admin" },
                    { new Guid("fd6a976d-d87f-4df7-a3ea-a8c6741b6dcf"), "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "Created", "Deleted", "Email", "FirstName", "FullName", "FullTextSearch", "Gender", "IsActive", "LastName", "Modified", "PasswordHash", "PasswordSalt", "PhoneNumber", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("0a9f122b-0d82-4fda-9bb5-18f87b28297b"), (short)0, new DateTime(2000, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 7, 53, 54, 742, DateTimeKind.Utc).AddTicks(6974), false, "ronaldo@example.com", "Cristiano", "Cristiano Ronaldo", "user Cristiano Ronaldo ronaldo@example.com 5555555555 Male", "Male", true, "Ronaldo", new DateTime(2024, 4, 25, 7, 53, 54, 742, DateTimeKind.Utc).AddTicks(6975), new byte[] { 31, 93, 167, 50, 139, 183, 149, 131, 99, 128, 90, 220, 171, 123, 91, 119, 185, 246, 202, 163, 10, 39, 192, 181, 149, 6, 162, 62, 200, 100, 248, 163, 99, 175, 57, 24, 228, 74, 44, 85, 123, 107, 60, 42, 240, 224, 21, 178, 82, 148, 62, 96, 99, 46, 114, 251, 142, 149, 115, 139, 92, 45, 161, 33 }, new byte[] { 66, 147, 208, 55, 0, 124, 121, 75, 79, 22, 1, 39, 30, 238, 238, 28, 153, 190, 18, 0, 220, 80, 84, 247, 141, 52, 86, 15, 107, 24, 244, 80, 249, 135, 5, 74, 172, 148, 1, 72, 113, 216, 213, 149, 40, 146, 175, 208, 218, 99, 172, 218, 62, 13, 144, 141, 81, 1, 212, 38, 70, 122, 204, 27, 6, 76, 254, 63, 67, 120, 62, 10, 53, 98, 197, 101, 112, 28, 254, 141, 105, 60, 203, 42, 91, 225, 211, 155, 56, 141, 46, 199, 145, 240, 50, 9, 221, 171, 195, 236, 46, 145, 29, 192, 238, 54, 19, 98, 125, 89, 144, 253, 116, 142, 243, 121, 221, 53, 48, 191, 64, 94, 171, 21, 248, 132, 107, 43 }, "5555555555", new Guid("56f2308e-3077-473a-bdd0-47988989f981"), "user" },
                    { new Guid("6d1f9a6f-4214-4303-bf6a-c64eae92bb8a"), (short)0, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 7, 53, 54, 742, DateTimeKind.Utc).AddTicks(6938), false, "teacher@example.com", "TeacherFirstName", "TeacherFirstName TeacherLastName", "teacher TeacherFirstName TeacherLastName teacher@example.com 9876543210 Female", "Female", true, "TeacherLastName", new DateTime(2024, 4, 25, 7, 53, 54, 742, DateTimeKind.Utc).AddTicks(6939), new byte[] { 96, 151, 43, 227, 242, 31, 242, 37, 154, 15, 147, 242, 189, 223, 236, 50, 245, 164, 60, 69, 180, 95, 61, 253, 103, 174, 252, 22, 103, 26, 74, 167, 85, 244, 214, 33, 7, 38, 26, 95, 205, 0, 235, 32, 240, 40, 243, 133, 56, 180, 61, 183, 114, 166, 87, 124, 253, 98, 9, 52, 29, 216, 37, 41 }, new byte[] { 83, 201, 42, 126, 90, 128, 245, 23, 137, 204, 70, 176, 240, 178, 186, 52, 132, 82, 173, 203, 219, 215, 29, 58, 230, 151, 224, 9, 162, 82, 201, 230, 121, 68, 162, 30, 55, 99, 248, 106, 61, 255, 51, 156, 44, 218, 106, 57, 78, 114, 87, 43, 237, 88, 154, 66, 13, 218, 155, 146, 242, 26, 112, 63, 241, 195, 73, 2, 52, 206, 14, 234, 253, 190, 68, 57, 33, 251, 149, 211, 206, 34, 233, 131, 252, 135, 119, 175, 136, 187, 186, 26, 58, 28, 127, 201, 40, 31, 121, 221, 245, 10, 149, 234, 189, 172, 171, 62, 37, 195, 104, 148, 104, 93, 249, 108, 100, 207, 169, 111, 196, 163, 32, 134, 149, 79, 229, 38 }, "9876543210", new Guid("fd6a976d-d87f-4df7-a3ea-a8c6741b6dcf"), "teacher" },
                    { new Guid("d6a2c7d9-ae87-4e18-842e-b9c01ec3a3ed"), (short)0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 7, 53, 54, 742, DateTimeKind.Utc).AddTicks(6882), false, "admin@example.com", "AdminFirstName", "AdminFirstName AdminLastName", "admin AdminFirstName AdminLastName admin@example.com 1234567890 Male", "Male", true, "AdminLastName", new DateTime(2024, 4, 25, 7, 53, 54, 742, DateTimeKind.Utc).AddTicks(6886), new byte[] { 73, 148, 251, 199, 76, 199, 161, 4, 76, 86, 30, 7, 232, 226, 115, 65, 198, 214, 170, 208, 14, 250, 157, 168, 109, 124, 15, 251, 28, 193, 9, 217, 142, 28, 86, 189, 231, 225, 8, 159, 131, 141, 46, 74, 139, 200, 53, 115, 236, 135, 85, 72, 196, 103, 221, 78, 240, 66, 177, 183, 1, 141, 101, 167 }, new byte[] { 197, 152, 83, 223, 8, 35, 24, 8, 254, 87, 13, 227, 216, 100, 110, 194, 51, 46, 89, 72, 112, 94, 164, 8, 199, 9, 166, 109, 228, 232, 25, 0, 214, 99, 78, 155, 85, 152, 215, 45, 159, 215, 87, 249, 210, 233, 229, 5, 179, 205, 216, 50, 246, 33, 5, 128, 162, 200, 5, 120, 61, 196, 228, 245, 42, 153, 205, 62, 208, 86, 62, 231, 78, 203, 8, 226, 127, 230, 39, 54, 78, 43, 165, 254, 51, 170, 79, 55, 17, 236, 23, 162, 7, 65, 249, 160, 86, 16, 31, 24, 161, 160, 65, 158, 143, 154, 143, 220, 158, 99, 126, 218, 154, 112, 64, 191, 141, 106, 174, 123, 205, 185, 53, 190, 192, 171, 84, 194 }, "1234567890", new Guid("d8df8fe9-d4eb-4383-b774-e72e427a4119"), "admin" }
                });
        }
    }
}
