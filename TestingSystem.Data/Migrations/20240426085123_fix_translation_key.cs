using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class fix_translation_key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LessionTranslations",
                table: "LessionTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTeacherTranslations",
                table: "CourseTeacherTranslations");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("12ecfa05-53a8-48fb-8620-a2253cfe4179"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3509bcaf-4f24-4091-8717-4f427dc6cddd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fe24eff1-0e02-4078-9379-d577e2ba7855"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("023d323a-dc4b-46e5-8b17-7ebaca60e533"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("5177ce86-7a88-413d-8c67-d886db7208fb"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("82bd3f4e-49d9-4106-b1da-2d9aee8e08bb"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "LessionTranslations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CourseTranslations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CourseTeacherTranslations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessionTranslations",
                table: "LessionTranslations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTeacherTranslations",
                table: "CourseTeacherTranslations",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_LessionTranslations_Id",
                table: "LessionTranslations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeacherTranslations_Id",
                table: "CourseTeacherTranslations",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LessionTranslations",
                table: "LessionTranslations");

            migrationBuilder.DropIndex(
                name: "IX_LessionTranslations_Id",
                table: "LessionTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTeacherTranslations",
                table: "CourseTeacherTranslations");

            migrationBuilder.DropIndex(
                name: "IX_CourseTeacherTranslations_Id",
                table: "CourseTeacherTranslations");

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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LessionTranslations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseTranslations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseTeacherTranslations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessionTranslations",
                table: "LessionTranslations",
                column: "LessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTeacherTranslations",
                table: "CourseTeacherTranslations",
                column: "CourseTeacherId");

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "en-EN",
                column: "Created",
                value: new DateTime(2024, 4, 25, 16, 13, 15, 987, DateTimeKind.Utc).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "ru-RU",
                column: "Created",
                value: new DateTime(2024, 4, 25, 16, 13, 15, 987, DateTimeKind.Utc).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "vi-VN",
                column: "Created",
                value: new DateTime(2024, 4, 25, 16, 13, 15, 987, DateTimeKind.Utc).AddTicks(4376));

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("023d323a-dc4b-46e5-8b17-7ebaca60e533"), "Admin" },
                    { new Guid("5177ce86-7a88-413d-8c67-d886db7208fb"), "Teacher" },
                    { new Guid("82bd3f4e-49d9-4106-b1da-2d9aee8e08bb"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "BirthDay", "Created", "Deleted", "Email", "FirstName", "FullName", "FullTextSearch", "Gender", "IsActive", "LastName", "Modified", "PasswordHash", "PasswordSalt", "PhoneNumber", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("12ecfa05-53a8-48fb-8620-a2253cfe4179"), (short)0, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 16, 13, 15, 987, DateTimeKind.Utc).AddTicks(3593), false, "admin@example.com", "AdminFirstName", "AdminFirstName AdminLastName", "admin AdminFirstName AdminLastName admin@example.com 1234567890 Male", "Male", true, "AdminLastName", new DateTime(2024, 4, 25, 16, 13, 15, 987, DateTimeKind.Utc).AddTicks(3599), new byte[] { 58, 71, 43, 111, 93, 143, 52, 139, 187, 101, 219, 54, 179, 198, 177, 151, 144, 83, 185, 230, 57, 196, 185, 128, 116, 99, 232, 194, 141, 99, 218, 91, 137, 179, 254, 39, 255, 65, 168, 163, 38, 234, 93, 230, 136, 201, 18, 39, 8, 9, 55, 184, 178, 168, 118, 146, 167, 205, 126, 217, 233, 119, 45, 148 }, new byte[] { 223, 147, 161, 207, 51, 21, 177, 51, 48, 104, 47, 89, 89, 158, 125, 119, 207, 143, 190, 97, 151, 32, 86, 215, 62, 153, 16, 81, 21, 88, 221, 94, 140, 66, 72, 243, 138, 71, 31, 182, 242, 143, 201, 31, 199, 35, 10, 198, 224, 166, 120, 223, 155, 207, 175, 177, 85, 110, 230, 8, 35, 29, 83, 83, 118, 162, 141, 224, 252, 106, 124, 19, 24, 178, 56, 163, 130, 74, 180, 15, 39, 219, 78, 119, 92, 215, 202, 131, 81, 241, 163, 83, 210, 131, 223, 48, 88, 163, 47, 246, 191, 174, 157, 11, 72, 38, 176, 134, 24, 182, 181, 54, 175, 69, 144, 136, 165, 160, 94, 58, 115, 197, 143, 95, 175, 246, 185, 54 }, "1234567890", new Guid("023d323a-dc4b-46e5-8b17-7ebaca60e533"), "admin" },
                    { new Guid("3509bcaf-4f24-4091-8717-4f427dc6cddd"), (short)0, null, new DateTime(2000, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 16, 13, 15, 987, DateTimeKind.Utc).AddTicks(4154), false, "ronaldo@example.com", "Cristiano", "Cristiano Ronaldo", "user Cristiano Ronaldo ronaldo@example.com 5555555555 Male", "Male", true, "Ronaldo", new DateTime(2024, 4, 25, 16, 13, 15, 987, DateTimeKind.Utc).AddTicks(4156), new byte[] { 99, 242, 176, 30, 152, 166, 24, 18, 236, 115, 155, 211, 173, 127, 144, 66, 176, 20, 183, 58, 21, 206, 245, 215, 184, 1, 179, 104, 139, 49, 72, 149, 73, 24, 19, 52, 247, 144, 130, 20, 38, 154, 83, 184, 55, 13, 152, 109, 158, 163, 212, 147, 82, 59, 163, 203, 248, 61, 207, 120, 255, 37, 91, 116 }, new byte[] { 210, 54, 136, 216, 182, 76, 243, 89, 3, 236, 116, 216, 251, 162, 27, 144, 189, 13, 58, 89, 54, 14, 158, 196, 15, 120, 155, 34, 128, 51, 215, 17, 162, 38, 94, 172, 68, 58, 31, 47, 224, 61, 126, 13, 103, 157, 223, 7, 85, 89, 100, 183, 78, 86, 57, 15, 126, 231, 14, 215, 85, 51, 159, 252, 15, 5, 97, 227, 246, 203, 109, 77, 188, 26, 86, 70, 108, 212, 109, 7, 218, 192, 174, 61, 71, 140, 139, 63, 55, 125, 90, 246, 128, 4, 20, 163, 212, 215, 203, 67, 228, 203, 142, 125, 17, 148, 196, 149, 65, 140, 136, 224, 201, 4, 111, 184, 139, 60, 59, 46, 236, 72, 226, 143, 136, 232, 18, 50 }, "5555555555", new Guid("82bd3f4e-49d9-4106-b1da-2d9aee8e08bb"), "user" },
                    { new Guid("fe24eff1-0e02-4078-9379-d577e2ba7855"), (short)0, null, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 16, 13, 15, 987, DateTimeKind.Utc).AddTicks(3900), false, "teacher@example.com", "TeacherFirstName", "TeacherFirstName TeacherLastName", "teacher TeacherFirstName TeacherLastName teacher@example.com 9876543210 Female", "Female", true, "TeacherLastName", new DateTime(2024, 4, 25, 16, 13, 15, 987, DateTimeKind.Utc).AddTicks(3902), new byte[] { 31, 226, 67, 224, 67, 175, 249, 181, 109, 103, 204, 0, 54, 238, 150, 203, 94, 122, 93, 0, 184, 1, 185, 184, 254, 74, 52, 104, 241, 155, 25, 37, 124, 178, 141, 150, 68, 166, 180, 9, 170, 61, 0, 149, 237, 111, 1, 190, 224, 89, 166, 136, 172, 103, 9, 116, 41, 241, 22, 137, 45, 185, 128, 219 }, new byte[] { 163, 66, 115, 3, 57, 31, 46, 130, 212, 29, 130, 31, 224, 75, 242, 140, 217, 190, 221, 56, 158, 116, 201, 158, 246, 127, 101, 0, 234, 214, 2, 144, 80, 227, 207, 229, 99, 225, 17, 226, 0, 125, 102, 69, 191, 158, 75, 57, 151, 240, 168, 228, 127, 115, 109, 238, 193, 185, 103, 0, 92, 54, 188, 208, 252, 69, 214, 200, 147, 169, 145, 83, 157, 155, 79, 107, 100, 115, 104, 184, 155, 89, 237, 223, 168, 47, 210, 103, 90, 10, 233, 107, 24, 49, 174, 43, 86, 123, 123, 217, 155, 47, 222, 115, 208, 18, 178, 61, 22, 27, 238, 123, 45, 23, 176, 152, 3, 104, 102, 109, 66, 62, 108, 185, 170, 53, 14, 219 }, "9876543210", new Guid("5177ce86-7a88-413d-8c67-d886db7208fb"), "teacher" }
                });
        }
    }
}
