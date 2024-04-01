using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bookWebApi.Migrations
{
    /// <inheritdoc />
    public partial class change_relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("af78fa2b-2652-45da-948d-194d24755bfa"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6dd51115-5be9-49b8-8887-e9462efcf272"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cacd9ed7-1e13-40ff-b0cd-1b0cb03b6823"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6dd51115-5be9-49b8-8887-e9462efcf272"), "Kryminał" },
                    { new Guid("cacd9ed7-1e13-40ff-b0cd-1b0cb03b6823"), "Komedia" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "CreatedDate", "Description", "GenreId", "Title", "UpdatedDate" },
                values: new object[] { new Guid("af78fa2b-2652-45da-948d-194d24755bfa"), "Test", new DateTime(2024, 4, 1, 10, 41, 26, 18, DateTimeKind.Local).AddTicks(7661), "test", new Guid("cacd9ed7-1e13-40ff-b0cd-1b0cb03b6823"), "Test", new DateTime(2024, 4, 1, 10, 41, 26, 18, DateTimeKind.Local).AddTicks(7730) });
        }
    }
}
