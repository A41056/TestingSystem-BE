using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class fix_translation_key_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTranslations",
                table: "CourseTranslations");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4ed92470-53ef-4ff0-a03b-e0e97addbe79"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ae6522d1-eeb3-4523-9a8e-d4da40a041ca"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf0b97be-a776-4a53-a3e3-33233ad4b8e5"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("00511f34-2fa2-4246-b0e8-1c4eab19c2f3"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("543504a5-6d00-4261-b39a-1a72ddda020f"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("c8986eff-c950-4f9f-892a-6e97b4727981"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTranslations",
                table: "CourseTranslations",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "en-EN",
                column: "Created",
                value: new DateTime(2024, 4, 26, 9, 6, 56, 58, DateTimeKind.Utc).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "ru-RU",
                column: "Created",
                value: new DateTime(2024, 4, 26, 9, 6, 56, 58, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "vi-VN",
                column: "Created",
                value: new DateTime(2024, 4, 26, 9, 6, 56, 58, DateTimeKind.Utc).AddTicks(2051));

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("0d2f6964-8ce0-4ddb-99c9-4458a4e8b080"), "Teacher" },
                    { new Guid("5c79da67-5426-4a4b-ac00-7b3021db92e6"), "User" },
                    { new Guid("b26db3c4-7453-46b1-a7b1-2ef242b579dd"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "BirthDay", "Created", "Deleted", "Email", "FirstName", "FullName", "FullTextSearch", "Gender", "IsActive", "LastName", "Modified", "PasswordHash", "PasswordSalt", "PhoneNumber", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("0147fa07-b063-4f94-8771-850905d90098"), (short)0, "https://cdn-icons-png.flaticon.com/512/149/149071.png", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 26, 9, 6, 56, 58, DateTimeKind.Utc).AddTicks(1815), false, "admin@example.com", "AdminFirstName", "AdminFirstName AdminLastName", "admin AdminFirstName AdminLastName admin@example.com 1234567890 Male", "Male", true, "AdminLastName", new DateTime(2024, 4, 26, 9, 6, 56, 58, DateTimeKind.Utc).AddTicks(1819), new byte[] { 80, 54, 26, 115, 224, 190, 224, 56, 247, 215, 0, 12, 72, 146, 8, 86, 248, 214, 31, 66, 37, 92, 111, 203, 216, 161, 252, 76, 32, 41, 195, 31, 62, 152, 171, 182, 37, 174, 90, 191, 145, 142, 210, 78, 198, 132, 100, 123, 231, 205, 82, 1, 6, 228, 234, 76, 220, 230, 35, 204, 0, 234, 179, 241 }, new byte[] { 198, 252, 141, 253, 156, 101, 62, 52, 19, 123, 95, 235, 133, 37, 81, 189, 15, 133, 170, 194, 213, 126, 1, 176, 212, 29, 84, 70, 122, 234, 239, 18, 199, 131, 233, 192, 109, 211, 69, 62, 140, 218, 215, 133, 47, 203, 210, 61, 224, 84, 254, 192, 165, 173, 144, 51, 244, 145, 96, 220, 94, 124, 178, 185, 5, 109, 238, 65, 234, 67, 170, 47, 49, 18, 191, 13, 56, 219, 174, 160, 90, 142, 158, 176, 49, 191, 222, 223, 227, 43, 98, 174, 197, 2, 141, 123, 151, 107, 12, 24, 66, 127, 204, 50, 115, 44, 62, 74, 141, 3, 113, 186, 201, 77, 224, 36, 64, 70, 142, 55, 230, 184, 83, 96, 191, 226, 221, 103 }, "1234567890", new Guid("b26db3c4-7453-46b1-a7b1-2ef242b579dd"), "admin" },
                    { new Guid("b2787339-8490-47cf-89db-58289782dab1"), (short)0, "https://cdn-icons-png.flaticon.com/512/149/149071.png", new DateTime(2000, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 26, 9, 6, 56, 58, DateTimeKind.Utc).AddTicks(1976), false, "ronaldo@example.com", "Cristiano", "Cristiano Ronaldo", "user Cristiano Ronaldo ronaldo@example.com 5555555555 Male", "Male", true, "Ronaldo", new DateTime(2024, 4, 26, 9, 6, 56, 58, DateTimeKind.Utc).AddTicks(1977), new byte[] { 81, 8, 223, 26, 201, 60, 83, 211, 165, 52, 71, 113, 192, 56, 58, 198, 120, 51, 238, 32, 246, 194, 107, 74, 32, 221, 130, 23, 106, 34, 76, 115, 234, 36, 33, 148, 218, 242, 88, 16, 64, 10, 109, 227, 43, 233, 136, 117, 197, 92, 246, 250, 47, 86, 31, 199, 109, 96, 202, 12, 83, 201, 167, 145 }, new byte[] { 16, 105, 73, 194, 222, 13, 99, 61, 232, 231, 68, 175, 86, 255, 200, 138, 254, 109, 199, 31, 37, 6, 154, 88, 184, 160, 83, 219, 173, 57, 44, 165, 10, 124, 214, 233, 39, 185, 16, 8, 29, 237, 89, 171, 17, 129, 96, 104, 126, 144, 245, 196, 41, 240, 94, 3, 236, 198, 42, 75, 4, 173, 125, 48, 109, 89, 97, 158, 212, 222, 194, 26, 22, 97, 17, 172, 90, 179, 47, 75, 97, 92, 227, 235, 98, 246, 131, 116, 58, 77, 78, 115, 127, 121, 43, 185, 181, 213, 149, 30, 150, 233, 22, 132, 165, 0, 33, 193, 243, 233, 26, 3, 30, 54, 253, 48, 161, 68, 14, 253, 52, 28, 152, 64, 204, 131, 168, 183 }, "5555555555", new Guid("5c79da67-5426-4a4b-ac00-7b3021db92e6"), "user" },
                    { new Guid("f1721e9d-7fce-438f-88a9-d282a2953cd5"), (short)0, "https://cdn-icons-png.flaticon.com/512/149/149071.png", new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 26, 9, 6, 56, 58, DateTimeKind.Utc).AddTicks(1902), false, "teacher@example.com", "TeacherFirstName", "TeacherFirstName TeacherLastName", "teacher TeacherFirstName TeacherLastName teacher@example.com 9876543210 Female", "Female", true, "TeacherLastName", new DateTime(2024, 4, 26, 9, 6, 56, 58, DateTimeKind.Utc).AddTicks(1903), new byte[] { 211, 88, 28, 20, 251, 86, 144, 252, 99, 88, 101, 245, 211, 155, 143, 173, 55, 236, 111, 16, 144, 172, 78, 176, 51, 226, 197, 78, 115, 83, 244, 237, 88, 115, 105, 159, 159, 118, 23, 106, 46, 223, 88, 204, 84, 11, 111, 37, 80, 191, 234, 36, 168, 154, 85, 103, 39, 251, 83, 43, 116, 67, 167, 96 }, new byte[] { 27, 192, 4, 147, 59, 184, 197, 51, 151, 54, 102, 132, 149, 121, 136, 70, 19, 43, 185, 233, 42, 202, 240, 61, 45, 106, 29, 23, 85, 52, 130, 65, 142, 218, 6, 54, 183, 42, 109, 226, 206, 134, 104, 119, 188, 198, 125, 192, 186, 19, 153, 64, 47, 215, 31, 62, 156, 125, 242, 144, 96, 87, 182, 16, 9, 108, 39, 81, 250, 186, 94, 64, 144, 37, 237, 92, 95, 214, 108, 113, 198, 183, 167, 84, 161, 93, 36, 255, 50, 188, 70, 31, 68, 213, 56, 167, 183, 69, 82, 6, 217, 107, 18, 176, 137, 102, 240, 173, 192, 158, 190, 87, 60, 122, 160, 210, 221, 42, 148, 159, 207, 175, 203, 47, 75, 121, 110, 71 }, "9876543210", new Guid("0d2f6964-8ce0-4ddb-99c9-4458a4e8b080"), "teacher" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTranslations_Id",
                table: "CourseTranslations",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTranslations",
                table: "CourseTranslations");

            migrationBuilder.DropIndex(
                name: "IX_CourseTranslations_Id",
                table: "CourseTranslations");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0147fa07-b063-4f94-8771-850905d90098"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b2787339-8490-47cf-89db-58289782dab1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f1721e9d-7fce-438f-88a9-d282a2953cd5"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("0d2f6964-8ce0-4ddb-99c9-4458a4e8b080"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("5c79da67-5426-4a4b-ac00-7b3021db92e6"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("b26db3c4-7453-46b1-a7b1-2ef242b579dd"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTranslations",
                table: "CourseTranslations",
                column: "CourseId");

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "en-EN",
                column: "Created",
                value: new DateTime(2024, 4, 26, 8, 51, 22, 738, DateTimeKind.Utc).AddTicks(688));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "ru-RU",
                column: "Created",
                value: new DateTime(2024, 4, 26, 8, 51, 22, 738, DateTimeKind.Utc).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "vi-VN",
                column: "Created",
                value: new DateTime(2024, 4, 26, 8, 51, 22, 738, DateTimeKind.Utc).AddTicks(684));

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("00511f34-2fa2-4246-b0e8-1c4eab19c2f3"), "Admin" },
                    { new Guid("543504a5-6d00-4261-b39a-1a72ddda020f"), "User" },
                    { new Guid("c8986eff-c950-4f9f-892a-6e97b4727981"), "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "BirthDay", "Created", "Deleted", "Email", "FirstName", "FullName", "FullTextSearch", "Gender", "IsActive", "LastName", "Modified", "PasswordHash", "PasswordSalt", "PhoneNumber", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("4ed92470-53ef-4ff0-a03b-e0e97addbe79"), (short)0, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 26, 8, 51, 22, 738, DateTimeKind.Utc).AddTicks(456), false, "admin@example.com", "AdminFirstName", "AdminFirstName AdminLastName", "admin AdminFirstName AdminLastName admin@example.com 1234567890 Male", "Male", true, "AdminLastName", new DateTime(2024, 4, 26, 8, 51, 22, 738, DateTimeKind.Utc).AddTicks(460), new byte[] { 3, 132, 166, 31, 240, 166, 207, 79, 157, 204, 248, 240, 53, 153, 187, 192, 142, 228, 23, 221, 116, 103, 49, 71, 132, 65, 181, 37, 200, 136, 117, 56, 210, 39, 94, 237, 233, 149, 157, 42, 121, 186, 64, 250, 148, 132, 229, 86, 178, 6, 169, 249, 15, 105, 85, 238, 111, 52, 18, 46, 26, 107, 90, 137 }, new byte[] { 189, 22, 96, 150, 233, 55, 151, 138, 57, 89, 167, 141, 126, 206, 84, 238, 191, 80, 74, 146, 172, 174, 123, 54, 103, 201, 160, 168, 148, 192, 129, 110, 237, 191, 19, 24, 174, 180, 168, 4, 195, 169, 185, 164, 131, 16, 161, 215, 60, 39, 72, 46, 188, 205, 34, 255, 210, 23, 60, 108, 145, 204, 204, 233, 81, 66, 228, 193, 159, 168, 246, 146, 5, 164, 252, 197, 73, 113, 62, 86, 255, 251, 218, 46, 214, 53, 62, 70, 184, 2, 236, 115, 16, 193, 87, 101, 145, 23, 181, 237, 230, 33, 174, 108, 196, 130, 226, 50, 103, 178, 189, 69, 206, 121, 140, 206, 146, 183, 191, 82, 0, 133, 137, 81, 220, 62, 143, 30 }, "1234567890", new Guid("00511f34-2fa2-4246-b0e8-1c4eab19c2f3"), "admin" },
                    { new Guid("ae6522d1-eeb3-4523-9a8e-d4da40a041ca"), (short)0, null, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 26, 8, 51, 22, 738, DateTimeKind.Utc).AddTicks(542), false, "teacher@example.com", "TeacherFirstName", "TeacherFirstName TeacherLastName", "teacher TeacherFirstName TeacherLastName teacher@example.com 9876543210 Female", "Female", true, "TeacherLastName", new DateTime(2024, 4, 26, 8, 51, 22, 738, DateTimeKind.Utc).AddTicks(543), new byte[] { 234, 4, 66, 197, 6, 34, 102, 156, 96, 245, 140, 196, 205, 22, 54, 206, 63, 149, 41, 229, 164, 188, 42, 156, 220, 100, 103, 185, 99, 95, 48, 198, 125, 220, 195, 26, 53, 15, 105, 112, 190, 248, 93, 249, 26, 219, 87, 169, 133, 152, 220, 172, 9, 139, 24, 232, 103, 121, 250, 122, 104, 169, 235, 115 }, new byte[] { 24, 158, 232, 128, 25, 149, 149, 83, 20, 143, 214, 123, 244, 149, 137, 143, 184, 56, 111, 174, 102, 198, 95, 210, 0, 167, 243, 162, 67, 16, 223, 11, 35, 212, 76, 222, 228, 15, 183, 149, 170, 255, 61, 133, 209, 92, 120, 141, 160, 100, 86, 162, 76, 207, 207, 160, 224, 13, 243, 76, 49, 78, 203, 9, 151, 92, 142, 55, 236, 100, 71, 63, 14, 31, 103, 128, 235, 86, 19, 63, 134, 185, 231, 54, 144, 156, 28, 81, 119, 207, 123, 134, 99, 172, 125, 97, 101, 121, 214, 254, 126, 137, 112, 36, 25, 74, 74, 66, 161, 94, 0, 113, 179, 73, 48, 254, 202, 73, 6, 96, 15, 208, 245, 90, 63, 68, 118, 184 }, "9876543210", new Guid("c8986eff-c950-4f9f-892a-6e97b4727981"), "teacher" },
                    { new Guid("bf0b97be-a776-4a53-a3e3-33233ad4b8e5"), (short)0, null, new DateTime(2000, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 26, 8, 51, 22, 738, DateTimeKind.Utc).AddTicks(614), false, "ronaldo@example.com", "Cristiano", "Cristiano Ronaldo", "user Cristiano Ronaldo ronaldo@example.com 5555555555 Male", "Male", true, "Ronaldo", new DateTime(2024, 4, 26, 8, 51, 22, 738, DateTimeKind.Utc).AddTicks(615), new byte[] { 77, 96, 180, 101, 42, 100, 220, 151, 214, 160, 126, 88, 20, 210, 174, 232, 52, 202, 245, 190, 116, 71, 125, 74, 157, 89, 212, 121, 173, 242, 75, 184, 55, 169, 54, 51, 254, 26, 208, 27, 83, 241, 56, 3, 91, 87, 204, 125, 201, 58, 166, 68, 124, 154, 112, 126, 245, 179, 12, 188, 200, 151, 91, 92 }, new byte[] { 80, 63, 134, 101, 164, 119, 191, 57, 156, 129, 139, 181, 47, 79, 6, 174, 77, 4, 94, 41, 185, 77, 114, 118, 236, 194, 189, 94, 116, 138, 224, 74, 12, 248, 35, 144, 61, 158, 180, 231, 69, 255, 5, 176, 244, 54, 222, 230, 215, 238, 53, 22, 184, 228, 30, 140, 239, 244, 35, 194, 71, 36, 14, 57, 254, 247, 90, 173, 164, 37, 232, 221, 55, 60, 117, 194, 228, 127, 80, 154, 158, 35, 24, 152, 209, 130, 234, 229, 62, 188, 111, 251, 105, 230, 69, 51, 141, 77, 175, 12, 193, 151, 208, 140, 137, 223, 171, 241, 150, 52, 121, 192, 116, 77, 209, 132, 200, 20, 252, 67, 162, 127, 187, 43, 44, 200, 189, 141 }, "5555555555", new Guid("543504a5-6d00-4261-b39a-1a72ddda020f"), "user" }
                });
        }
    }
}
