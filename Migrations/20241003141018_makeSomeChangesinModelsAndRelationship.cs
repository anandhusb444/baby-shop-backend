using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baby_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class makeSomeChangesinModelsAndRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "CategoriesTable");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "CategoriesTable");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$sUxEZb8lk/09OqzjNKdo.eN3wLgqSt5RqJRAGjh.xjolC2S3cXAa.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "CategoriesTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "CategoriesTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CategoriesTable",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "categoryId", "quantity" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "CategoriesTable",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "categoryId", "quantity" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "CategoriesTable",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "categoryId", "quantity" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "CategoriesTable",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "categoryId", "quantity" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$8je6eV7fZDZtfofdxMSBuOlzFt7XJ5Pxq4DFQE3WcWpIn9Cbf3nwq");
        }
    }
}
