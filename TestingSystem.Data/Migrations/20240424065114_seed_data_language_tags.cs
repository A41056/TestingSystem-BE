using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class seed_data_language_tags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2eb9b15a-0f3d-4e50-bfc1-bf7cf0e556b6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("436af843-8340-4a53-a22c-4a94998393a9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90efaef9-81a2-4d9a-a990-16bd6346f980"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("5bbb11af-fb05-4d9b-aa52-a95529d0f85b"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("97ce259e-27ef-45e1-822d-5c97b677dbb3"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("c907e6dc-d79f-4ad9-b7ef-4d16dd1c55ab"));

            migrationBuilder.InsertData(
                table: "LanguageTags",
                columns: new[] { "Code", "Created", "IsActive", "IsDefault", "Modified", "Name", "SortOrder" },
                values: new object[,]
                {
                    { "en-EN", new DateTime(2024, 4, 24, 6, 51, 13, 861, DateTimeKind.Utc).AddTicks(8077), true, false, null, "English", 1 },
                    { "ru-RU", new DateTime(2024, 4, 24, 6, 51, 13, 861, DateTimeKind.Utc).AddTicks(8079), true, false, null, "Russia", 2 },
                    { "vi-VN", new DateTime(2024, 4, 24, 6, 51, 13, 861, DateTimeKind.Utc).AddTicks(8075), true, true, null, "VietNam", 0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("6e35eeaa-612a-47a9-bb54-a5746ef53258"), "Teacher" },
                    { new Guid("984597c8-6d81-4734-ab98-46cc42140aac"), "User" },
                    { new Guid("db81b955-710c-4e3e-a2d4-857113c53454"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "Created", "Deleted", "Email", "FirstName", "FullName", "FullTextSearch", "Gender", "IsActive", "LastName", "Modified", "PasswordHash", "PasswordSalt", "PhoneNumber", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("15232a90-0b2c-4f07-9b9b-7b7fc148a079"), (short)0, new DateTime(2000, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 24, 6, 51, 13, 861, DateTimeKind.Utc).AddTicks(8029), false, "ronaldo@example.com", "Cristiano", "Cristiano Ronaldo", "user Cristiano Ronaldo ronaldo@example.com 5555555555 Male", "Male", true, "Ronaldo", new DateTime(2024, 4, 24, 6, 51, 13, 861, DateTimeKind.Utc).AddTicks(8029), new byte[] { 96, 62, 248, 157, 36, 54, 241, 139, 154, 10, 155, 172, 224, 226, 25, 48, 133, 199, 217, 242, 198, 182, 229, 186, 224, 80, 53, 243, 181, 153, 152, 145, 37, 70, 254, 120, 251, 55, 230, 109, 92, 119, 39, 246, 47, 55, 198, 91, 133, 19, 58, 64, 26, 212, 204, 82, 63, 253, 21, 38, 55, 132, 69, 77 }, new byte[] { 186, 161, 196, 145, 121, 172, 197, 204, 231, 124, 190, 0, 191, 249, 148, 22, 14, 158, 83, 186, 109, 164, 176, 77, 207, 215, 253, 86, 42, 14, 166, 211, 39, 98, 86, 10, 17, 251, 112, 191, 93, 10, 30, 228, 235, 17, 63, 71, 255, 44, 184, 66, 61, 43, 184, 53, 122, 114, 208, 55, 92, 180, 88, 167, 140, 240, 128, 215, 49, 18, 170, 95, 177, 176, 56, 237, 142, 30, 194, 10, 149, 115, 25, 131, 201, 191, 133, 140, 156, 30, 56, 245, 161, 149, 197, 194, 41, 232, 125, 207, 121, 240, 176, 4, 243, 206, 34, 33, 219, 16, 164, 137, 218, 23, 239, 159, 179, 186, 195, 16, 142, 207, 17, 50, 226, 167, 249, 77 }, "5555555555", new Guid("984597c8-6d81-4734-ab98-46cc42140aac"), "user" },
                    { new Guid("3b477390-8d75-4071-af77-dbace8d8b7ca"), (short)0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 24, 6, 51, 13, 861, DateTimeKind.Utc).AddTicks(7859), false, "admin@example.com", "AdminFirstName", "AdminFirstName AdminLastName", "admin AdminFirstName AdminLastName admin@example.com 1234567890 Male", "Male", true, "AdminLastName", new DateTime(2024, 4, 24, 6, 51, 13, 861, DateTimeKind.Utc).AddTicks(7862), new byte[] { 182, 251, 58, 58, 17, 197, 254, 178, 43, 192, 215, 150, 87, 243, 218, 220, 142, 198, 124, 63, 19, 226, 142, 249, 30, 6, 79, 184, 60, 32, 99, 14, 206, 52, 229, 187, 44, 167, 210, 64, 120, 167, 129, 229, 28, 169, 219, 21, 212, 50, 207, 191, 146, 126, 100, 96, 173, 74, 13, 178, 127, 19, 202, 68 }, new byte[] { 111, 105, 127, 95, 102, 14, 93, 136, 232, 251, 255, 16, 232, 38, 144, 160, 131, 73, 27, 205, 171, 102, 216, 5, 163, 222, 120, 53, 70, 188, 7, 202, 246, 77, 71, 127, 241, 75, 147, 15, 142, 234, 59, 106, 243, 84, 182, 149, 57, 138, 32, 80, 21, 124, 119, 10, 136, 214, 182, 231, 63, 32, 77, 139, 105, 60, 141, 117, 14, 56, 164, 212, 25, 194, 147, 111, 226, 213, 65, 88, 159, 1, 127, 100, 232, 165, 165, 241, 100, 73, 133, 54, 8, 5, 206, 3, 91, 104, 14, 28, 207, 245, 231, 38, 117, 166, 11, 252, 188, 173, 117, 229, 159, 159, 180, 132, 54, 19, 165, 100, 223, 30, 65, 174, 7, 163, 22, 251 }, "1234567890", new Guid("db81b955-710c-4e3e-a2d4-857113c53454"), "admin" },
                    { new Guid("6f8ac548-d222-49c9-a229-dcaf0a30be3f"), (short)0, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 24, 6, 51, 13, 861, DateTimeKind.Utc).AddTicks(7903), false, "teacher@example.com", "TeacherFirstName", "TeacherFirstName TeacherLastName", "teacher TeacherFirstName TeacherLastName teacher@example.com 9876543210 Female", "Female", true, "TeacherLastName", new DateTime(2024, 4, 24, 6, 51, 13, 861, DateTimeKind.Utc).AddTicks(7903), new byte[] { 196, 116, 241, 143, 237, 219, 223, 138, 253, 45, 2, 175, 166, 59, 102, 155, 9, 155, 26, 38, 171, 203, 241, 158, 91, 8, 156, 20, 39, 47, 210, 78, 25, 80, 237, 70, 130, 48, 82, 30, 56, 71, 14, 105, 100, 36, 195, 11, 56, 248, 52, 199, 100, 50, 129, 232, 24, 15, 78, 221, 165, 155, 123, 55 }, new byte[] { 132, 83, 36, 67, 159, 225, 54, 214, 22, 37, 89, 88, 255, 198, 72, 46, 254, 5, 27, 91, 117, 90, 51, 18, 121, 35, 157, 226, 90, 192, 55, 12, 118, 80, 71, 153, 180, 36, 87, 204, 169, 47, 132, 152, 170, 255, 55, 74, 120, 203, 178, 121, 119, 122, 157, 161, 243, 244, 204, 238, 10, 69, 81, 175, 10, 52, 214, 131, 22, 9, 142, 186, 82, 215, 57, 23, 138, 230, 92, 72, 253, 216, 203, 60, 97, 163, 105, 183, 147, 135, 163, 66, 253, 206, 140, 177, 18, 9, 52, 143, 177, 207, 192, 136, 237, 10, 228, 106, 64, 51, 234, 179, 250, 101, 104, 29, 22, 126, 214, 246, 182, 218, 206, 158, 4, 184, 50, 84 }, "9876543210", new Guid("6e35eeaa-612a-47a9-bb54-a5746ef53258"), "teacher" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("15232a90-0b2c-4f07-9b9b-7b7fc148a079"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b477390-8d75-4071-af77-dbace8d8b7ca"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6f8ac548-d222-49c9-a229-dcaf0a30be3f"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("6e35eeaa-612a-47a9-bb54-a5746ef53258"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("984597c8-6d81-4734-ab98-46cc42140aac"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("db81b955-710c-4e3e-a2d4-857113c53454"));

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("5bbb11af-fb05-4d9b-aa52-a95529d0f85b"), "User" },
                    { new Guid("97ce259e-27ef-45e1-822d-5c97b677dbb3"), "Teacher" },
                    { new Guid("c907e6dc-d79f-4ad9-b7ef-4d16dd1c55ab"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "Created", "Deleted", "Email", "FirstName", "FullName", "FullTextSearch", "Gender", "IsActive", "LastName", "Modified", "PasswordHash", "PasswordSalt", "PhoneNumber", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("2eb9b15a-0f3d-4e50-bfc1-bf7cf0e556b6"), (short)0, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 24, 6, 19, 32, 554, DateTimeKind.Utc).AddTicks(9700), false, "teacher@example.com", "TeacherFirstName", "TeacherFirstName TeacherLastName", "teacher TeacherFirstName TeacherLastName teacher@example.com 9876543210 Female", "Female", true, "TeacherLastName", new DateTime(2024, 4, 24, 6, 19, 32, 554, DateTimeKind.Utc).AddTicks(9701), new byte[] { 214, 60, 15, 74, 47, 89, 96, 10, 113, 89, 233, 3, 236, 11, 145, 84, 94, 217, 58, 121, 184, 213, 97, 238, 179, 25, 84, 137, 198, 3, 83, 110, 249, 71, 208, 222, 130, 134, 33, 140, 99, 196, 8, 32, 196, 77, 118, 36, 113, 161, 49, 243, 109, 115, 47, 142, 62, 81, 72, 81, 55, 226, 218, 251 }, new byte[] { 208, 64, 35, 34, 29, 74, 203, 65, 162, 38, 12, 78, 30, 138, 36, 152, 202, 58, 166, 7, 99, 23, 236, 221, 177, 138, 209, 75, 15, 2, 199, 244, 93, 54, 33, 0, 231, 114, 32, 157, 137, 148, 167, 161, 236, 161, 137, 51, 111, 2, 173, 131, 122, 214, 21, 197, 175, 12, 148, 184, 4, 120, 47, 253, 1, 66, 20, 23, 39, 152, 241, 152, 215, 198, 113, 82, 95, 187, 103, 49, 171, 175, 205, 203, 54, 42, 182, 107, 24, 210, 210, 241, 24, 85, 152, 195, 154, 144, 247, 126, 33, 214, 199, 130, 249, 230, 154, 230, 112, 65, 238, 62, 71, 5, 249, 98, 113, 194, 44, 110, 65, 170, 182, 200, 37, 223, 142, 179 }, "9876543210", new Guid("97ce259e-27ef-45e1-822d-5c97b677dbb3"), "teacher" },
                    { new Guid("436af843-8340-4a53-a22c-4a94998393a9"), (short)0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 24, 6, 19, 32, 554, DateTimeKind.Utc).AddTicks(9656), false, "admin@example.com", "AdminFirstName", "AdminFirstName AdminLastName", "admin AdminFirstName AdminLastName admin@example.com 1234567890 Male", "Male", true, "AdminLastName", new DateTime(2024, 4, 24, 6, 19, 32, 554, DateTimeKind.Utc).AddTicks(9659), new byte[] { 36, 162, 24, 53, 220, 160, 149, 182, 220, 2, 201, 234, 162, 184, 111, 19, 16, 172, 254, 203, 179, 13, 212, 236, 193, 98, 94, 142, 55, 98, 177, 95, 191, 202, 238, 126, 9, 41, 115, 42, 24, 26, 97, 227, 228, 148, 15, 10, 252, 39, 237, 156, 248, 44, 7, 113, 202, 213, 245, 104, 83, 113, 75, 119 }, new byte[] { 66, 46, 161, 74, 253, 166, 43, 138, 119, 162, 110, 128, 11, 157, 1, 9, 65, 204, 141, 47, 62, 252, 114, 10, 17, 30, 198, 25, 89, 172, 167, 160, 105, 134, 78, 209, 210, 156, 15, 232, 115, 21, 25, 19, 67, 14, 58, 218, 133, 93, 129, 70, 193, 52, 87, 158, 165, 43, 2, 140, 70, 66, 113, 87, 248, 175, 131, 157, 61, 146, 31, 111, 116, 234, 101, 204, 239, 15, 190, 227, 139, 250, 9, 131, 4, 21, 33, 61, 26, 64, 70, 60, 94, 225, 186, 144, 37, 120, 84, 117, 207, 199, 199, 93, 88, 250, 147, 160, 158, 108, 112, 165, 171, 58, 44, 91, 111, 8, 221, 173, 194, 208, 46, 159, 154, 216, 58, 27 }, "1234567890", new Guid("c907e6dc-d79f-4ad9-b7ef-4d16dd1c55ab"), "admin" },
                    { new Guid("90efaef9-81a2-4d9a-a990-16bd6346f980"), (short)0, new DateTime(2000, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 24, 6, 19, 32, 554, DateTimeKind.Utc).AddTicks(9735), false, "ronaldo@example.com", "Cristiano", "Cristiano Ronaldo", "user Cristiano Ronaldo ronaldo@example.com 5555555555 Male", "Male", true, "Ronaldo", new DateTime(2024, 4, 24, 6, 19, 32, 554, DateTimeKind.Utc).AddTicks(9736), new byte[] { 87, 157, 185, 201, 221, 236, 229, 154, 242, 91, 214, 196, 14, 33, 36, 71, 103, 123, 58, 105, 88, 116, 241, 104, 53, 132, 130, 89, 40, 122, 33, 12, 123, 49, 27, 65, 194, 45, 198, 221, 217, 3, 54, 71, 86, 99, 214, 83, 252, 135, 213, 206, 201, 3, 153, 51, 66, 154, 236, 85, 160, 196, 157, 243 }, new byte[] { 205, 80, 131, 162, 72, 251, 29, 250, 208, 15, 183, 57, 242, 175, 241, 127, 119, 239, 86, 146, 237, 245, 143, 112, 152, 96, 23, 137, 136, 70, 72, 105, 252, 70, 241, 228, 36, 114, 164, 109, 221, 2, 13, 238, 184, 156, 6, 148, 36, 244, 32, 106, 20, 4, 139, 49, 141, 183, 27, 118, 169, 178, 56, 161, 128, 88, 114, 163, 118, 156, 221, 242, 238, 159, 89, 97, 45, 190, 126, 134, 95, 143, 154, 255, 147, 183, 110, 40, 114, 6, 90, 220, 129, 26, 93, 255, 230, 139, 209, 180, 47, 140, 99, 13, 63, 139, 47, 130, 82, 153, 231, 30, 81, 147, 72, 127, 7, 42, 95, 253, 197, 138, 33, 253, 193, 252, 149, 200 }, "5555555555", new Guid("5bbb11af-fb05-4d9b-aa52-a95529d0f85b"), "user" }
                });
        }
    }
}
