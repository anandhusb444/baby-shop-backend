using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baby_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class seedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "Role", "isStatus", "password", "userEmail", "userName" },
                values: new object[] { 2, "User", true, "$2a$11$7b/XA.CezOIb/B2.Cqt1AeVEaltmMThciaT1Of6rEYbuM.xgVWSFC", "admin@gmail.com", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
