using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class UserSeedData_Jwt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "ImagePath", "IsDeleted", "Password", "UpdatedAt", "UserName" },
                values: new object[] { -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admain@gmail.com", "Admain", "default.png", false, "00000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADMAIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
