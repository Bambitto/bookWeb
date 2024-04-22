using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bookWebApi.Migrations
{
    /// <inheritdoc />
    public partial class add_test_data3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "CreatedDate", "Description", "GenreId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("b566f1ce-fe95-49e1-80fe-00599c72a63c"), "Test", new DateTime(2024, 4, 21, 19, 53, 48, 855, DateTimeKind.Local).AddTicks(1024), "test", new Guid("92be180c-9da6-4160-b329-28941a676051"), "Test", new DateTime(2024, 4, 21, 19, 53, 48, 855, DateTimeKind.Local).AddTicks(1076) },
                    { new Guid("c5925e50-5698-4117-b649-447e38d8ac87"), "Test2", new DateTime(2024, 4, 21, 19, 53, 48, 855, DateTimeKind.Local).AddTicks(1078), "test2", new Guid("bad03d5b-0398-4efe-a343-0b2c0a8d796c"), "Test2", new DateTime(2024, 4, 21, 19, 53, 48, 855, DateTimeKind.Local).AddTicks(1080) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "RoleId" },
                values: new object[] { new Guid("3cc9a958-1247-43fc-a0c7-462289af73cd"), "test@test.com", "Test", "Test", "test123", new Guid("36590529-1bf3-46db-ad8e-023caafb6e13") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "BookId", "Comment", "Score", "UserId" },
                values: new object[,]
                {
                    { new Guid("3ccdf84b-7df2-484f-987c-f55e0013e672"), new Guid("c5925e50-5698-4117-b649-447e38d8ac87"), "test", 5, new Guid("3cc9a958-1247-43fc-a0c7-462289af73cd") },
                    { new Guid("ab08f374-bbec-4005-8122-73d687faf833"), new Guid("b566f1ce-fe95-49e1-80fe-00599c72a63c"), "test", 4, new Guid("3cc9a958-1247-43fc-a0c7-462289af73cd") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("3ccdf84b-7df2-484f-987c-f55e0013e672"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("ab08f374-bbec-4005-8122-73d687faf833"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("b566f1ce-fe95-49e1-80fe-00599c72a63c"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("c5925e50-5698-4117-b649-447e38d8ac87"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3cc9a958-1247-43fc-a0c7-462289af73cd"));
        }
    }
}
