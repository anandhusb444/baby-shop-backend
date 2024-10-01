using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baby_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class seeding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "password", "userEmail","Role" },
                values: new object[] { "$2a$11$pAD9kYWHPHsQXMxeWdhnXupm5ZSLV0B9YUqrYXS//22uW/UW0x8Qa", "admin@.com","Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "password", "userEmail" },
                values: new object[] { "$2a$11$qrlAF2dlgqIIomimnR3/S.1Vtx6runLVk/OP8rkSYt/wnR3eURMgO", "admin@gmail" });
        }
    }
}
