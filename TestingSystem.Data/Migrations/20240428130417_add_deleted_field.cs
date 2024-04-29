using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_deleted_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "en-EN");

            migrationBuilder.DeleteData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "ru-RU");

            migrationBuilder.DeleteData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "vi-VN");

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

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Lessions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Courses",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Lessions");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Courses");

            migrationBuilder.InsertData(
                table: "LanguageTags",
                columns: new[] { "Code", "Created", "IsActive", "IsDefault", "Modified", "Name", "SortOrder" },
                values: new object[,]
                {
                    { "en-EN", new DateTime(2024, 4, 26, 9, 6, 56, 58, DateTimeKind.Utc).AddTicks(2056), true, false, null, "English", 1 },
                    { "ru-RU", new DateTime(2024, 4, 26, 9, 6, 56, 58, DateTimeKind.Utc).AddTicks(2066), true, false, null, "Russia", 2 },
                    { "vi-VN", new DateTime(2024, 4, 26, 9, 6, 56, 58, DateTimeKind.Utc).AddTicks(2051), true, true, null, "VietNam", 0 }
                });

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
        }
    }
}
