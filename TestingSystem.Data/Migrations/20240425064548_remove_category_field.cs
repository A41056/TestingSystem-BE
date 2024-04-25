using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class remove_category_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("37b24c00-f4d3-4517-bd4a-387f3bbc811f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bef85b2a-d9c6-4fa6-a975-feb61d997889"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f07d2bff-3cf2-4984-bd3c-16e92f8ccb05"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("2e6b81d9-0ee1-495b-b6ab-11185b430191"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("74c33832-9368-4283-bd3e-2e32ab937b38"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("8f726563-4622-44e9-99d2-bcbbcffbe1bd"));

            migrationBuilder.DropColumn(
                name: "CategoryType",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ImageFileId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LinkUrl",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Categories");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "CategoryType",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageFileId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LinkUrl",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "en-EN",
                column: "Created",
                value: new DateTime(2024, 4, 24, 10, 13, 17, 28, DateTimeKind.Utc).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "ru-RU",
                column: "Created",
                value: new DateTime(2024, 4, 24, 10, 13, 17, 28, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "vi-VN",
                column: "Created",
                value: new DateTime(2024, 4, 24, 10, 13, 17, 28, DateTimeKind.Utc).AddTicks(6066));

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("2e6b81d9-0ee1-495b-b6ab-11185b430191"), "User" },
                    { new Guid("74c33832-9368-4283-bd3e-2e32ab937b38"), "Admin" },
                    { new Guid("8f726563-4622-44e9-99d2-bcbbcffbe1bd"), "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "Created", "Deleted", "Email", "FirstName", "FullName", "FullTextSearch", "Gender", "IsActive", "LastName", "Modified", "PasswordHash", "PasswordSalt", "PhoneNumber", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("37b24c00-f4d3-4517-bd4a-387f3bbc811f"), (short)0, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 24, 10, 13, 17, 28, DateTimeKind.Utc).AddTicks(5990), false, "teacher@example.com", "TeacherFirstName", "TeacherFirstName TeacherLastName", "teacher TeacherFirstName TeacherLastName teacher@example.com 9876543210 Female", "Female", true, "TeacherLastName", new DateTime(2024, 4, 24, 10, 13, 17, 28, DateTimeKind.Utc).AddTicks(5991), new byte[] { 223, 201, 102, 123, 75, 173, 190, 100, 246, 192, 19, 11, 235, 249, 107, 71, 92, 143, 178, 34, 9, 1, 168, 121, 130, 90, 104, 118, 203, 248, 87, 197, 153, 17, 205, 207, 52, 35, 102, 204, 160, 22, 1, 180, 110, 68, 92, 171, 9, 23, 201, 248, 138, 146, 116, 18, 69, 63, 139, 198, 196, 103, 250, 151 }, new byte[] { 182, 49, 174, 186, 84, 41, 175, 8, 244, 11, 88, 24, 59, 59, 65, 47, 62, 135, 3, 218, 177, 130, 10, 67, 28, 93, 165, 208, 239, 148, 158, 51, 119, 105, 106, 6, 71, 227, 4, 231, 180, 121, 109, 93, 138, 53, 224, 221, 66, 203, 165, 175, 131, 172, 184, 245, 253, 201, 20, 197, 116, 234, 231, 33, 99, 9, 89, 27, 139, 219, 220, 163, 121, 231, 167, 154, 232, 2, 236, 114, 209, 37, 32, 143, 159, 228, 88, 131, 98, 132, 3, 170, 223, 193, 112, 140, 11, 144, 136, 86, 222, 217, 2, 79, 19, 98, 43, 120, 0, 48, 163, 125, 17, 228, 76, 111, 194, 248, 45, 175, 242, 51, 184, 133, 152, 35, 109, 197 }, "9876543210", new Guid("8f726563-4622-44e9-99d2-bcbbcffbe1bd"), "teacher" },
                    { new Guid("bef85b2a-d9c6-4fa6-a975-feb61d997889"), (short)0, new DateTime(2000, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 24, 10, 13, 17, 28, DateTimeKind.Utc).AddTicks(6025), false, "ronaldo@example.com", "Cristiano", "Cristiano Ronaldo", "user Cristiano Ronaldo ronaldo@example.com 5555555555 Male", "Male", true, "Ronaldo", new DateTime(2024, 4, 24, 10, 13, 17, 28, DateTimeKind.Utc).AddTicks(6025), new byte[] { 170, 236, 76, 137, 170, 26, 3, 206, 177, 53, 137, 27, 38, 31, 169, 163, 152, 230, 31, 69, 91, 132, 11, 255, 19, 102, 222, 224, 202, 116, 26, 207, 155, 248, 216, 35, 183, 99, 88, 238, 122, 26, 204, 146, 41, 173, 63, 14, 93, 173, 112, 14, 36, 225, 1, 122, 157, 153, 233, 53, 98, 211, 1, 232 }, new byte[] { 5, 180, 49, 221, 181, 196, 238, 67, 103, 155, 65, 96, 181, 236, 68, 17, 51, 100, 68, 80, 87, 198, 108, 217, 171, 201, 52, 77, 174, 22, 184, 137, 71, 68, 88, 47, 191, 218, 207, 49, 128, 111, 192, 38, 150, 86, 113, 148, 154, 135, 107, 24, 239, 122, 208, 209, 82, 82, 142, 139, 33, 1, 226, 104, 89, 245, 46, 244, 148, 244, 112, 50, 193, 71, 116, 41, 138, 208, 93, 26, 120, 211, 127, 14, 6, 196, 47, 52, 185, 60, 40, 33, 77, 234, 154, 247, 226, 52, 41, 123, 181, 211, 66, 145, 172, 161, 209, 94, 106, 210, 210, 92, 33, 202, 60, 10, 202, 3, 30, 223, 217, 132, 156, 126, 212, 225, 7, 78 }, "5555555555", new Guid("2e6b81d9-0ee1-495b-b6ab-11185b430191"), "user" },
                    { new Guid("f07d2bff-3cf2-4984-bd3c-16e92f8ccb05"), (short)0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 24, 10, 13, 17, 28, DateTimeKind.Utc).AddTicks(5942), false, "admin@example.com", "AdminFirstName", "AdminFirstName AdminLastName", "admin AdminFirstName AdminLastName admin@example.com 1234567890 Male", "Male", true, "AdminLastName", new DateTime(2024, 4, 24, 10, 13, 17, 28, DateTimeKind.Utc).AddTicks(5944), new byte[] { 67, 8, 42, 12, 237, 24, 145, 145, 25, 134, 110, 126, 226, 156, 187, 122, 69, 230, 137, 122, 180, 253, 181, 164, 87, 54, 251, 252, 68, 132, 130, 195, 9, 202, 107, 18, 183, 249, 145, 180, 177, 239, 210, 22, 4, 233, 78, 181, 176, 23, 232, 27, 55, 9, 29, 231, 1, 116, 1, 162, 143, 38, 146, 211 }, new byte[] { 233, 177, 51, 191, 90, 118, 253, 62, 25, 101, 81, 217, 102, 6, 164, 191, 188, 107, 24, 242, 108, 53, 250, 167, 98, 224, 12, 223, 52, 164, 240, 194, 227, 160, 77, 49, 191, 56, 79, 193, 173, 141, 150, 255, 95, 128, 145, 53, 204, 133, 110, 108, 141, 0, 155, 119, 27, 134, 167, 129, 240, 115, 220, 233, 57, 247, 157, 10, 197, 242, 125, 180, 2, 152, 232, 37, 0, 142, 242, 254, 200, 192, 171, 2, 153, 44, 113, 223, 130, 208, 60, 22, 113, 205, 112, 125, 27, 95, 232, 60, 10, 194, 190, 247, 173, 146, 230, 69, 241, 96, 234, 246, 195, 175, 181, 104, 196, 168, 250, 76, 243, 250, 206, 196, 59, 129, 20, 84 }, "1234567890", new Guid("74c33832-9368-4283-bd3e-2e32ab937b38"), "admin" }
                });
        }
    }
}
