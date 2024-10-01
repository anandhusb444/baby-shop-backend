using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baby_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class seeding3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "Role", "isStatus", "password", "userEmail", "userName" },
                values: new object[] { 3, "Admin", true, "$2a$11$76fOqJAB8v8tmxvfM6vsC.4y1rgeMkncM.8ZEBG0/e9P8WGy5NNjy", "admin@.com", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "Role", "isStatus", "password", "userEmail", "userName" },
                values: new object[] { 2, "Admin", true, "$2a$11$pAD9kYWHPHsQXMxeWdhnXupm5ZSLV0B9YUqrYXS//22uW/UW0x8Qa", "admin@.com", "Admin" });
        }
    }
}
