using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2ba0dd5e-123f-488c-84ed-f2da5bc9dd68"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("67d68547-c1cf-47c1-a84f-8fa4185731bf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8f512463-eada-4c8e-b783-80c24d2d3e69"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("0a28cb14-bf71-4bdb-88d9-042d4e483bd6"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("b20f0149-7e57-4ddd-b013-e2f99b365212"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("d447eca5-6e58-4519-9211-6c098dca0285"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Exams");

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("2a03f8f6-db15-4fe7-97e4-9bac3339a472"), "User" },
                    { new Guid("b3da35e0-122f-4aa6-ac40-3980182d4bae"), "Teacher" },
                    { new Guid("d39c0f72-689c-4880-aba3-a5d4082d0ae9"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "Created", "Deleted", "Email", "FirstName", "FullName", "FullTextSearch", "Gender", "IsActive", "LastName", "Modified", "PasswordHash", "PasswordSalt", "PhoneNumber", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("8e98c066-a5ef-4cb1-9cf8-fb19359c57b1"), (short)0, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 26, 15, 59, 16, 528, DateTimeKind.Utc).AddTicks(8690), false, "teacher@example.com", "TeacherFirstName", "TeacherFirstName TeacherLastName", "teacher TeacherFirstName TeacherLastName teacher@example.com 9876543210 Female", "Female", true, "TeacherLastName", new DateTime(2024, 3, 26, 15, 59, 16, 528, DateTimeKind.Utc).AddTicks(8691), new byte[] { 250, 187, 3, 79, 232, 79, 113, 206, 112, 134, 86, 171, 81, 91, 247, 35, 233, 87, 131, 130, 170, 157, 165, 61, 157, 66, 110, 238, 91, 16, 70, 159, 65, 186, 107, 215, 131, 192, 249, 115, 244, 27, 129, 102, 21, 175, 45, 124, 31, 54, 106, 207, 233, 222, 40, 198, 36, 58, 32, 2, 206, 158, 255, 120 }, new byte[] { 201, 123, 64, 176, 35, 128, 32, 244, 40, 133, 46, 184, 183, 126, 82, 199, 37, 249, 6, 20, 220, 33, 252, 72, 189, 9, 142, 101, 112, 66, 168, 206, 157, 119, 60, 54, 138, 195, 222, 3, 35, 250, 124, 233, 150, 80, 51, 127, 201, 160, 242, 201, 114, 195, 50, 32, 128, 184, 218, 108, 186, 171, 52, 143, 226, 174, 195, 64, 173, 7, 246, 97, 121, 53, 199, 57, 28, 242, 111, 25, 216, 84, 251, 184, 42, 39, 147, 34, 148, 223, 88, 49, 79, 209, 243, 251, 164, 164, 85, 151, 202, 176, 84, 175, 141, 135, 19, 126, 94, 136, 32, 226, 46, 28, 243, 65, 157, 197, 143, 37, 96, 20, 246, 166, 210, 116, 136, 118 }, "9876543210", new Guid("b3da35e0-122f-4aa6-ac40-3980182d4bae"), "teacher" },
                    { new Guid("e0529d58-73e0-4b35-b93e-6675b23c39ed"), (short)0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 26, 15, 59, 16, 528, DateTimeKind.Utc).AddTicks(8611), false, "admin@example.com", "AdminFirstName", "AdminFirstName AdminLastName", "admin AdminFirstName AdminLastName admin@example.com 1234567890 Male", "Male", true, "AdminLastName", new DateTime(2024, 3, 26, 15, 59, 16, 528, DateTimeKind.Utc).AddTicks(8615), new byte[] { 5, 29, 138, 124, 236, 91, 192, 82, 215, 180, 91, 175, 97, 107, 43, 8, 76, 103, 239, 226, 77, 144, 200, 74, 229, 59, 21, 77, 18, 141, 159, 83, 171, 193, 42, 57, 207, 106, 30, 210, 196, 33, 72, 189, 225, 121, 192, 202, 214, 17, 58, 59, 181, 57, 151, 154, 62, 251, 54, 17, 205, 39, 31, 8 }, new byte[] { 53, 51, 184, 160, 119, 165, 113, 169, 72, 104, 154, 175, 25, 208, 194, 215, 215, 209, 188, 99, 108, 48, 209, 229, 29, 144, 200, 66, 143, 102, 228, 241, 105, 55, 64, 151, 106, 82, 209, 91, 157, 117, 59, 156, 236, 147, 224, 57, 96, 97, 255, 140, 182, 122, 97, 134, 212, 33, 49, 89, 50, 84, 134, 69, 48, 129, 108, 57, 254, 62, 129, 252, 29, 229, 71, 119, 129, 121, 92, 189, 17, 247, 159, 108, 35, 137, 173, 0, 59, 120, 86, 101, 118, 197, 247, 219, 237, 199, 24, 14, 100, 103, 92, 112, 161, 122, 34, 18, 179, 52, 137, 108, 213, 239, 108, 203, 207, 5, 238, 92, 182, 0, 199, 215, 23, 113, 139, 241 }, "1234567890", new Guid("d39c0f72-689c-4880-aba3-a5d4082d0ae9"), "admin" },
                    { new Guid("f4d99c13-6f71-4d0f-9ff8-816aaa04b9d3"), (short)0, new DateTime(2000, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 26, 15, 59, 16, 528, DateTimeKind.Utc).AddTicks(8730), false, "ronaldo@example.com", "Cristiano", "Cristiano Ronaldo", "user Cristiano Ronaldo ronaldo@example.com 5555555555 Male", "Male", true, "Ronaldo", new DateTime(2024, 3, 26, 15, 59, 16, 528, DateTimeKind.Utc).AddTicks(8730), new byte[] { 12, 191, 201, 91, 227, 239, 228, 76, 27, 60, 110, 65, 148, 61, 5, 170, 249, 122, 42, 209, 46, 9, 190, 228, 166, 89, 115, 101, 229, 204, 135, 64, 161, 109, 239, 91, 235, 244, 42, 135, 148, 5, 144, 233, 249, 199, 83, 180, 55, 251, 113, 80, 111, 42, 146, 207, 166, 130, 114, 82, 141, 106, 229, 47 }, new byte[] { 77, 103, 192, 31, 91, 103, 67, 113, 100, 196, 134, 14, 38, 125, 227, 47, 150, 102, 12, 193, 252, 129, 128, 196, 124, 96, 57, 215, 160, 148, 124, 196, 70, 127, 22, 147, 92, 207, 226, 255, 9, 217, 209, 168, 120, 157, 23, 233, 100, 114, 111, 113, 66, 45, 81, 185, 125, 249, 138, 46, 180, 103, 163, 219, 130, 14, 101, 135, 84, 149, 189, 232, 78, 181, 219, 236, 77, 228, 228, 170, 38, 201, 98, 234, 150, 64, 199, 118, 125, 62, 104, 35, 251, 68, 197, 61, 41, 128, 141, 187, 206, 226, 181, 253, 57, 153, 134, 97, 40, 19, 43, 224, 147, 16, 109, 2, 151, 138, 89, 39, 171, 103, 202, 135, 60, 26, 0, 103 }, "5555555555", new Guid("2a03f8f6-db15-4fe7-97e4-9bac3339a472"), "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8e98c066-a5ef-4cb1-9cf8-fb19359c57b1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e0529d58-73e0-4b35-b93e-6675b23c39ed"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f4d99c13-6f71-4d0f-9ff8-816aaa04b9d3"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("2a03f8f6-db15-4fe7-97e4-9bac3339a472"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("b3da35e0-122f-4aa6-ac40-3980182d4bae"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: new Guid("d39c0f72-689c-4880-aba3-a5d4082d0ae9"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Exams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Exams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }
    }
}
