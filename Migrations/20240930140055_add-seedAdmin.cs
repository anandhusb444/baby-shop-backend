using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baby_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class addseedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "Role", "password", "userEmail" },
                values: new object[] { "Admin", "$2a$11$qrlAF2dlgqIIomimnR3/S.1Vtx6runLVk/OP8rkSYt/wnR3eURMgO", "admin@gmail" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "Role", "password", "userEmail" },
                values: new object[] { "User", "$2a$11$7b/XA.CezOIb/B2.Cqt1AeVEaltmMThciaT1Of6rEYbuM.xgVWSFC", "admin@gmail.com" });
        }
    }
}
