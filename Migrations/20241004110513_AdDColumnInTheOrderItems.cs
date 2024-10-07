using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baby_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class AdDColumnInTheOrderItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "OrderItemsTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$LZsuct4Qy4iSAnybgazVxuPu.B5oKH.MLg9qkz/2608gI1SrDINoK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "OrderItemsTable");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$sUxEZb8lk/09OqzjNKdo.eN3wLgqSt5RqJRAGjh.xjolC2S3cXAa.");
        }
    }
}
