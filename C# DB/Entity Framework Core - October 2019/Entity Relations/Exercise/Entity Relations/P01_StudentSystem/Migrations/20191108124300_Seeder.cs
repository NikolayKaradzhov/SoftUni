using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_StudentSystem.Migrations
{
    public partial class Seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "HomeworkSubmissions",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false);

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "EndDate", "Name", "Price", "StartDate" },
                values: new object[,]
                {
                    { 1, "In this course you will learn the principles of OOP", new DateTime(2020, 1, 17, 14, 43, 0, 199, DateTimeKind.Local).AddTicks(7958), "C# OOP", 399.00m, new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, new DateTime(2020, 2, 6, 14, 43, 0, 205, DateTimeKind.Local).AddTicks(3955), "Java Basics", 180.00m, new DateTime(2019, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Birthday", "Name", "PhoneNumber", "RegisteredOn" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 11, 8, 14, 43, 0, 225, DateTimeKind.Local).AddTicks(9817), "Gosho", "0885444555", new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, new DateTime(2001, 11, 8, 14, 43, 0, 226, DateTimeKind.Local).AddTicks(1077), "Pesho", "0885111222", new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "HomeworkSubmissions",
                columns: new[] { "HomeworkId", "Content", "ContentType", "CourseId", "StudentId", "SubmissionTime" },
                values: new object[,]
                {
                    { 1, null, 1, 1, 1, new DateTime(2019, 11, 8, 12, 43, 0, 217, DateTimeKind.Utc).AddTicks(5137) },
                    { 2, null, 2, 2, 2, new DateTime(2019, 11, 8, 12, 43, 0, 217, DateTimeKind.Utc).AddTicks(7646) }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "CourseId", "Name", "ResourceType", "Url" },
                values: new object[,]
                {
                    { 1, 1, "Documents", 2, "https://testdocs.com/resources/docs" },
                    { 2, 2, "Video", 0, "https://testdocs.com/resources/video" }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "StudentId", "CourseId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "StudentId", "CourseId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "StudentId", "CourseId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "HomeworkSubmissions",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldNullable: true);
        }
    }
}
