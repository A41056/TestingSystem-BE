using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_avatar_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "en-EN",
                column: "Created",
                value: new DateTime(2024, 4, 25, 15, 24, 45, 498, DateTimeKind.Utc).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "ru-RU",
                column: "Created",
                value: new DateTime(2024, 4, 25, 15, 24, 45, 498, DateTimeKind.Utc).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "vi-VN",
                column: "Created",
                value: new DateTime(2024, 4, 25, 15, 24, 45, 498, DateTimeKind.Utc).AddTicks(1365));

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("4427e482-1631-4ba5-b194-9de37a47ad87"), "User" },
                    { new Guid("7534bd82-50f3-459d-8cfd-f7f233c47eea"), "Teacher" },
                    { new Guid("a5da0fdb-8e2f-4d03-abaa-bb311ad17fea"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "BirthDay", "Created", "Deleted", "Email", "FirstName", "FullName", "FullTextSearch", "Gender", "IsActive", "LastName", "Modified", "PasswordHash", "PasswordSalt", "PhoneNumber", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("1b223032-fcdb-4d57-8667-1a4967545dd9"), (short)0, null, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 15, 24, 45, 498, DateTimeKind.Utc).AddTicks(1160), false, "teacher@example.com", "TeacherFirstName", "TeacherFirstName TeacherLastName", "teacher TeacherFirstName TeacherLastName teacher@example.com 9876543210 Female", "Female", true, "TeacherLastName", new DateTime(2024, 4, 25, 15, 24, 45, 498, DateTimeKind.Utc).AddTicks(1161), new byte[] { 209, 0, 181, 28, 63, 239, 172, 255, 208, 26, 84, 72, 192, 193, 186, 122, 60, 173, 224, 5, 148, 137, 209, 216, 225, 221, 165, 27, 47, 99, 79, 218, 114, 90, 214, 165, 184, 105, 197, 221, 181, 82, 161, 234, 154, 253, 241, 125, 142, 37, 189, 179, 139, 31, 48, 136, 151, 219, 175, 127, 111, 148, 77, 9 }, new byte[] { 101, 179, 159, 223, 95, 217, 15, 231, 2, 49, 140, 11, 62, 223, 244, 150, 250, 108, 158, 32, 146, 235, 215, 73, 102, 180, 186, 175, 130, 66, 83, 212, 178, 163, 100, 45, 50, 8, 68, 93, 143, 172, 4, 194, 185, 51, 187, 103, 189, 90, 252, 213, 172, 163, 244, 218, 207, 39, 63, 179, 144, 66, 125, 229, 166, 34, 22, 150, 211, 146, 1, 54, 167, 119, 158, 68, 150, 97, 72, 205, 156, 235, 104, 128, 201, 206, 121, 144, 180, 180, 199, 69, 223, 95, 229, 49, 130, 211, 204, 80, 157, 252, 234, 127, 73, 98, 101, 207, 45, 72, 19, 206, 72, 204, 19, 69, 133, 36, 216, 176, 189, 29, 137, 107, 104, 190, 77, 158 }, "9876543210", new Guid("7534bd82-50f3-459d-8cfd-f7f233c47eea"), "teacher" },
                    { new Guid("2fdc3898-e7be-4a43-9cd6-84f7690ef182"), (short)0, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 15, 24, 45, 498, DateTimeKind.Utc).AddTicks(1021), false, "admin@example.com", "AdminFirstName", "AdminFirstName AdminLastName", "admin AdminFirstName AdminLastName admin@example.com 1234567890 Male", "Male", true, "AdminLastName", new DateTime(2024, 4, 25, 15, 24, 45, 498, DateTimeKind.Utc).AddTicks(1025), new byte[] { 230, 187, 197, 136, 18, 179, 108, 58, 164, 127, 165, 71, 187, 189, 158, 167, 194, 21, 97, 166, 32, 93, 252, 210, 221, 137, 212, 132, 188, 162, 167, 157, 189, 153, 75, 128, 102, 172, 28, 5, 176, 160, 156, 17, 198, 75, 165, 31, 45, 101, 39, 105, 167, 137, 146, 32, 11, 14, 96, 72, 28, 0, 172, 93 }, new byte[] { 190, 251, 128, 27, 29, 106, 156, 75, 220, 144, 39, 237, 134, 54, 153, 82, 47, 116, 28, 229, 181, 205, 191, 126, 216, 140, 237, 238, 206, 90, 70, 58, 233, 9, 216, 221, 233, 213, 165, 68, 121, 107, 190, 30, 235, 9, 205, 255, 1, 44, 254, 214, 225, 180, 94, 162, 126, 248, 213, 135, 112, 209, 205, 199, 39, 89, 152, 16, 92, 2, 167, 138, 58, 84, 216, 105, 241, 65, 72, 70, 4, 150, 118, 6, 82, 124, 131, 64, 14, 178, 233, 44, 233, 49, 70, 214, 237, 16, 75, 94, 205, 210, 87, 183, 139, 251, 137, 70, 89, 213, 95, 59, 247, 11, 207, 221, 42, 221, 246, 232, 90, 228, 140, 233, 182, 245, 244, 135 }, "1234567890", new Guid("a5da0fdb-8e2f-4d03-abaa-bb311ad17fea"), "admin" },
                    { new Guid("6f6049fb-9e28-44dd-b9d9-5331e8e69bf0"), (short)0, null, new DateTime(2000, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 15, 24, 45, 498, DateTimeKind.Utc).AddTicks(1301), false, "ronaldo@example.com", "Cristiano", "Cristiano Ronaldo", "user Cristiano Ronaldo ronaldo@example.com 5555555555 Male", "Male", true, "Ronaldo", new DateTime(2024, 4, 25, 15, 24, 45, 498, DateTimeKind.Utc).AddTicks(1302), new byte[] { 29, 206, 67, 19, 54, 166, 213, 191, 138, 185, 50, 78, 204, 85, 247, 162, 217, 225, 150, 75, 10, 245, 70, 31, 196, 14, 246, 10, 212, 148, 197, 84, 25, 195, 144, 126, 226, 244, 136, 105, 93, 156, 244, 201, 74, 248, 213, 175, 222, 243, 229, 183, 212, 114, 111, 86, 59, 106, 57, 35, 189, 225, 49, 150 }, new byte[] { 249, 107, 157, 184, 7, 232, 213, 233, 13, 202, 181, 159, 99, 194, 49, 183, 216, 171, 214, 174, 64, 21, 34, 125, 73, 168, 121, 71, 111, 163, 125, 50, 54, 51, 219, 131, 111, 76, 139, 176, 193, 178, 46, 5, 21, 234, 211, 60, 125, 244, 49, 248, 80, 136, 21, 245, 175, 152, 42, 216, 193, 40, 31, 225, 103, 230, 57, 142, 0, 225, 37, 234, 91, 167, 216, 196, 90, 69, 203, 177, 33, 240, 6, 88, 95, 67, 54, 215, 42, 84, 49, 54, 212, 115, 165, 91, 82, 225, 248, 239, 158, 63, 224, 179, 75, 198, 171, 122, 94, 228, 0, 249, 43, 82, 190, 125, 7, 60, 63, 185, 129, 46, 49, 104, 157, 244, 149, 30 }, "5555555555", new Guid("4427e482-1631-4ba5-b194-9de37a47ad87"), "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1b223032-fcdb-4d57-8667-1a4967545dd9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2fdc3898-e7be-4a43-9cd6-84f7690ef182"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6f6049fb-9e28-44dd-b9d9-5331e8e69bf0"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("4427e482-1631-4ba5-b194-9de37a47ad87"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("7534bd82-50f3-459d-8cfd-f7f233c47eea"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("a5da0fdb-8e2f-4d03-abaa-bb311ad17fea"));

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "Users");

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
        }
    }
}
