using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bookWebApi.Migrations
{
    /// <inheritdoc />
    public partial class add_test_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
