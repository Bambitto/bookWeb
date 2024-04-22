using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bookWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addRoleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("92be180c-9da6-4160-b329-28941a676051"), "Kryminał" },
                    { new Guid("bad03d5b-0398-4efe-a343-0b2c0a8d796c"), "Komedia" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("36590529-1bf3-46db-ad8e-023caafb6e13"), "Admin" },
                    { new Guid("c9c05127-1026-4b32-8ed4-27824d44e08b"), "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Roles_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Roles_RoleId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                table: "User");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("92be180c-9da6-4160-b329-28941a676051"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("bad03d5b-0398-4efe-a343-0b2c0a8d796c"));

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "User");

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
    }
}
