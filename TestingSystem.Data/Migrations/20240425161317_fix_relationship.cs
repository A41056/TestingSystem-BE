using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class fix_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseTeachers_CourseTeacherId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseTeacherId",
                table: "Courses");

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
                name: "CourseTeacherId",
                table: "Courses");

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

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeachers_Id",
                table: "CourseTeachers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Id",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeachers_Courses_CourseId",
                table: "CourseTeachers",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeachers_Courses_CourseId",
                table: "CourseTeachers");

            migrationBuilder.DropIndex(
                name: "IX_CourseTeachers_Id",
                table: "CourseTeachers");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Id",
                table: "Courses");

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
                name: "CourseTeacherId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseTeacherId",
                table: "Courses",
                column: "CourseTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseTeachers_CourseTeacherId",
                table: "Courses",
                column: "CourseTeacherId",
                principalTable: "CourseTeachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
