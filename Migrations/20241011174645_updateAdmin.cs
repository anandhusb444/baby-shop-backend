using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baby_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class updateAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "password", "userEmail" },
                values: new object[] { "$2a$11$NlvwB.4k3Cm493GijZQcCOKlOw2dsiEkzHzOlux3lOmtowT1AdO8i", "admin@123.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "password", "userEmail" },
                values: new object[] { "$2a$11$LZsuct4Qy4iSAnybgazVxuPu.B5oKH.MLg9qkz/2608gI1SrDINoK", "admin@.com" });
        }
    }
}
