using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBookStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyNavigationCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 8, 11, 18, 59, 57, 500, DateTimeKind.Utc).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 8, 11, 18, 59, 57, 500, DateTimeKind.Utc).AddTicks(1613));

            migrationBuilder.CreateIndex(
                name: "IX_Books_Genre",
                table: "Books",
                column: "Genre");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_Genre",
                table: "Books",
                column: "Genre",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_Genre",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Genre",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 8, 11, 18, 14, 27, 522, DateTimeKind.Utc).AddTicks(4986));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 8, 11, 18, 14, 27, 522, DateTimeKind.Utc).AddTicks(4993));
        }
    }
}
