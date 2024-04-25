using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_translation_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTranslation",
                table: "CategoryTranslation");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0e274f1b-803f-4150-8f75-1240cf67335b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("122a18af-d2c9-4752-a4ad-8e75fac0a024"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e0e2248d-07da-4ee0-accf-a5ef51908a98"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("3ad02241-89a4-4e1a-8de4-ea57a412fba2"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("c2cbf9f8-152a-41af-a167-19c58f4ec82b"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("e22bb0c2-ff66-42e7-b52d-cbca29875342"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CategoryTranslation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTranslation",
                table: "CategoryTranslation",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTranslation",
                table: "CategoryTranslation");

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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CategoryTranslation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTranslation",
                table: "CategoryTranslation",
                column: "CategoryId");

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "en-EN",
                column: "Created",
                value: new DateTime(2024, 4, 25, 6, 45, 48, 93, DateTimeKind.Utc).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "ru-RU",
                column: "Created",
                value: new DateTime(2024, 4, 25, 6, 45, 48, 93, DateTimeKind.Utc).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "vi-VN",
                column: "Created",
                value: new DateTime(2024, 4, 25, 6, 45, 48, 93, DateTimeKind.Utc).AddTicks(4182));

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("3ad02241-89a4-4e1a-8de4-ea57a412fba2"), "User" },
                    { new Guid("c2cbf9f8-152a-41af-a167-19c58f4ec82b"), "Teacher" },
                    { new Guid("e22bb0c2-ff66-42e7-b52d-cbca29875342"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "Created", "Deleted", "Email", "FirstName", "FullName", "FullTextSearch", "Gender", "IsActive", "LastName", "Modified", "PasswordHash", "PasswordSalt", "PhoneNumber", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("0e274f1b-803f-4150-8f75-1240cf67335b"), (short)0, new DateTime(2000, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 6, 45, 48, 93, DateTimeKind.Utc).AddTicks(4139), false, "ronaldo@example.com", "Cristiano", "Cristiano Ronaldo", "user Cristiano Ronaldo ronaldo@example.com 5555555555 Male", "Male", true, "Ronaldo", new DateTime(2024, 4, 25, 6, 45, 48, 93, DateTimeKind.Utc).AddTicks(4139), new byte[] { 223, 231, 42, 207, 46, 179, 133, 147, 173, 238, 67, 180, 154, 119, 1, 162, 52, 147, 128, 59, 223, 110, 126, 132, 136, 147, 59, 174, 173, 128, 68, 224, 54, 86, 41, 14, 181, 17, 155, 223, 150, 219, 226, 65, 224, 188, 8, 48, 45, 146, 129, 152, 123, 66, 219, 219, 110, 158, 32, 210, 50, 163, 165, 220 }, new byte[] { 36, 143, 27, 76, 136, 181, 34, 203, 181, 121, 78, 146, 152, 124, 64, 68, 178, 221, 197, 9, 200, 210, 109, 220, 142, 254, 28, 248, 138, 215, 28, 180, 73, 183, 165, 88, 123, 66, 131, 180, 189, 64, 231, 88, 249, 181, 235, 121, 174, 178, 202, 24, 181, 254, 206, 235, 240, 78, 55, 140, 19, 226, 115, 66, 145, 26, 215, 73, 217, 113, 94, 210, 139, 157, 218, 211, 139, 10, 15, 149, 18, 87, 102, 213, 110, 8, 176, 74, 35, 121, 12, 8, 164, 34, 3, 74, 64, 148, 51, 251, 54, 112, 244, 111, 69, 120, 113, 251, 77, 173, 180, 252, 131, 238, 98, 230, 224, 192, 161, 34, 171, 28, 220, 8, 250, 121, 42, 196 }, "5555555555", new Guid("3ad02241-89a4-4e1a-8de4-ea57a412fba2"), "user" },
                    { new Guid("122a18af-d2c9-4752-a4ad-8e75fac0a024"), (short)0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 6, 45, 48, 93, DateTimeKind.Utc).AddTicks(4050), false, "admin@example.com", "AdminFirstName", "AdminFirstName AdminLastName", "admin AdminFirstName AdminLastName admin@example.com 1234567890 Male", "Male", true, "AdminLastName", new DateTime(2024, 4, 25, 6, 45, 48, 93, DateTimeKind.Utc).AddTicks(4053), new byte[] { 80, 148, 207, 158, 169, 69, 237, 150, 195, 62, 192, 163, 233, 149, 9, 37, 56, 175, 175, 228, 69, 246, 96, 58, 13, 22, 59, 238, 185, 71, 91, 24, 149, 121, 102, 24, 144, 13, 3, 150, 206, 159, 207, 15, 115, 168, 68, 50, 90, 192, 169, 133, 85, 107, 80, 10, 100, 97, 2, 207, 238, 34, 177, 63 }, new byte[] { 100, 161, 9, 122, 250, 195, 154, 68, 221, 124, 121, 198, 230, 222, 109, 211, 143, 28, 18, 47, 164, 164, 58, 82, 1, 40, 94, 31, 131, 200, 175, 141, 202, 214, 114, 232, 72, 102, 166, 252, 134, 148, 81, 109, 190, 97, 80, 58, 215, 245, 211, 139, 188, 78, 212, 183, 191, 183, 168, 49, 208, 152, 98, 71, 110, 116, 19, 210, 12, 144, 165, 169, 216, 164, 178, 250, 20, 86, 9, 0, 128, 78, 172, 2, 249, 247, 19, 102, 49, 50, 8, 151, 161, 252, 173, 54, 37, 175, 202, 34, 66, 228, 64, 84, 114, 143, 222, 254, 164, 236, 185, 243, 135, 99, 76, 20, 68, 223, 51, 179, 149, 120, 145, 229, 33, 0, 15, 108 }, "1234567890", new Guid("e22bb0c2-ff66-42e7-b52d-cbca29875342"), "admin" },
                    { new Guid("e0e2248d-07da-4ee0-accf-a5ef51908a98"), (short)0, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 6, 45, 48, 93, DateTimeKind.Utc).AddTicks(4101), false, "teacher@example.com", "TeacherFirstName", "TeacherFirstName TeacherLastName", "teacher TeacherFirstName TeacherLastName teacher@example.com 9876543210 Female", "Female", true, "TeacherLastName", new DateTime(2024, 4, 25, 6, 45, 48, 93, DateTimeKind.Utc).AddTicks(4101), new byte[] { 52, 173, 84, 211, 228, 191, 46, 186, 153, 134, 63, 70, 94, 12, 154, 155, 109, 117, 243, 48, 181, 217, 15, 8, 248, 131, 154, 235, 111, 56, 24, 20, 30, 181, 224, 118, 189, 249, 78, 194, 217, 61, 96, 215, 161, 1, 242, 117, 60, 205, 176, 12, 131, 36, 235, 136, 15, 173, 141, 216, 75, 95, 177, 31 }, new byte[] { 144, 175, 67, 59, 151, 216, 13, 75, 61, 119, 24, 70, 211, 47, 17, 2, 153, 133, 211, 143, 240, 17, 230, 253, 15, 184, 50, 144, 135, 80, 3, 190, 187, 112, 180, 63, 222, 196, 178, 139, 78, 132, 110, 59, 117, 24, 59, 33, 56, 54, 145, 38, 201, 89, 87, 240, 209, 154, 4, 90, 218, 56, 28, 231, 224, 49, 62, 175, 138, 66, 78, 18, 95, 107, 59, 124, 245, 23, 192, 145, 58, 29, 141, 165, 125, 12, 35, 231, 213, 27, 225, 12, 0, 207, 118, 4, 214, 199, 84, 241, 55, 3, 122, 55, 80, 155, 44, 68, 112, 100, 84, 199, 194, 46, 152, 186, 221, 142, 35, 120, 183, 45, 42, 83, 78, 219, 64, 160 }, "9876543210", new Guid("c2cbf9f8-152a-41af-a167-19c58f4ec82b"), "teacher" }
                });
        }
    }
}
