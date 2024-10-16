using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baby_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class createadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$CsI1vmPUp1a37PR4PWcDQeC1lRGLBDrWZrNwRVXcD462sbpg5CKFa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$NlvwB.4k3Cm493GijZQcCOKlOw2dsiEkzHzOlux3lOmtowT1AdO8i");
        }
    }
}
