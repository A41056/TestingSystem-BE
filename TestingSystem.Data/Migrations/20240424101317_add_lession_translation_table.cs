using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_lession_translation_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "LessionTranslations",
                columns: table => new
                {
                    LessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageCode = table.Column<string>(type: "varchar(5)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessionTranslations", x => x.LessionId);
                    table.ForeignKey(
                        name: "FK_LessionTranslations_LanguageTags_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "LanguageTags",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessionTranslations_Lessions_LessionId",
                        column: x => x.LessionId,
                        principalTable: "Lessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LessionTranslations_LanguageCode",
                table: "LessionTranslations",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_LessionTranslations_LessionId",
                table: "LessionTranslations",
                column: "LessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessionTranslations");

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

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "en-EN",
                column: "Created",
                value: new DateTime(2024, 4, 24, 6, 51, 13, 861, DateTimeKind.Utc).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "ru-RU",
                column: "Created",
                value: new DateTime(2024, 4, 24, 6, 51, 13, 861, DateTimeKind.Utc).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "LanguageTags",
                keyColumn: "Code",
                keyValue: "vi-VN",
                column: "Created",
                value: new DateTime(2024, 4, 24, 6, 51, 13, 861, DateTimeKind.Utc).AddTicks(8075));

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
    }
}
