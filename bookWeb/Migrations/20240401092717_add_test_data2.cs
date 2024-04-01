using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bookWebApi.Migrations
{
    /// <inheritdoc />
    public partial class add_test_data2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("10cd7a5d-445f-4410-89e7-4c849f674d9b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("038a14c8-e246-452e-8990-241af8d17dc0"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5c6ab8d7-1ebe-4855-bf94-d442f1d31f3d"));

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Review",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("17320e59-c5dc-427a-80fc-22e73e353961"), "Komedia" },
                    { new Guid("f4b085dc-f486-4069-acc0-ba8c9dc1fb8b"), "Kryminał" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { new Guid("a4c47528-e04d-4817-a520-854564fe190a"), "test@test.com", "Test", "Test", "test123" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "CreatedDate", "Description", "GenreId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("08465f3f-f45b-4766-9d30-2efe280c1961"), "Test2", new DateTime(2024, 4, 1, 11, 27, 17, 31, DateTimeKind.Local).AddTicks(5550), "test2", new Guid("f4b085dc-f486-4069-acc0-ba8c9dc1fb8b"), "Test2", new DateTime(2024, 4, 1, 11, 27, 17, 31, DateTimeKind.Local).AddTicks(5552) },
                    { new Guid("43bee7aa-bd10-406e-a501-009701b25822"), "Test", new DateTime(2024, 4, 1, 11, 27, 17, 31, DateTimeKind.Local).AddTicks(5496), "test", new Guid("17320e59-c5dc-427a-80fc-22e73e353961"), "Test", new DateTime(2024, 4, 1, 11, 27, 17, 31, DateTimeKind.Local).AddTicks(5548) }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "BookId", "Comment", "Score", "UserId" },
                values: new object[,]
                {
                    { new Guid("27ff0714-2929-41eb-a0c6-bb7a33b2fb1a"), new Guid("08465f3f-f45b-4766-9d30-2efe280c1961"), "test", 5, new Guid("a4c47528-e04d-4817-a520-854564fe190a") },
                    { new Guid("41d7f06c-966d-4fae-80a1-28813879900c"), new Guid("43bee7aa-bd10-406e-a501-009701b25822"), "test", 4, new Guid("a4c47528-e04d-4817-a520-854564fe190a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("27ff0714-2929-41eb-a0c6-bb7a33b2fb1a"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("41d7f06c-966d-4fae-80a1-28813879900c"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("08465f3f-f45b-4766-9d30-2efe280c1961"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("43bee7aa-bd10-406e-a501-009701b25822"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a4c47528-e04d-4817-a520-854564fe190a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("17320e59-c5dc-427a-80fc-22e73e353961"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f4b085dc-f486-4069-acc0-ba8c9dc1fb8b"));

            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "Review",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("038a14c8-e246-452e-8990-241af8d17dc0"), "Kryminał" },
                    { new Guid("5c6ab8d7-1ebe-4855-bf94-d442f1d31f3d"), "Komedia" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "CreatedDate", "Description", "GenreId", "Title", "UpdatedDate" },
                values: new object[] { new Guid("10cd7a5d-445f-4410-89e7-4c849f674d9b"), "Test", new DateTime(2024, 4, 1, 11, 17, 39, 379, DateTimeKind.Local).AddTicks(4234), "test", new Guid("5c6ab8d7-1ebe-4855-bf94-d442f1d31f3d"), "Test", new DateTime(2024, 4, 1, 11, 17, 39, 379, DateTimeKind.Local).AddTicks(4311) });
        }
    }
}
