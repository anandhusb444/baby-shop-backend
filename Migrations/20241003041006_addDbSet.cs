using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baby_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class addDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_User_UserId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Cart_cartId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_productId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Order_orderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_productId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_categoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_WhishList_Products_productId",
                table: "WhishList");

            migrationBuilder.DropForeignKey(
                name: "FK_WhishList_User_UserId",
                table: "WhishList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WhishList",
                table: "WhishList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "WhishList",
                newName: "WhishListTable");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ProductsTable");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItemsTable");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "OrderTable");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "CategoriesTable");

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "CartItemsTable");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "CartTable");

            migrationBuilder.RenameIndex(
                name: "IX_WhishList_UserId",
                table: "WhishListTable",
                newName: "IX_WhishListTable_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WhishList_productId",
                table: "WhishListTable",
                newName: "IX_WhishListTable_productId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_categoryId",
                table: "ProductsTable",
                newName: "IX_ProductsTable_categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_productId",
                table: "OrderItemsTable",
                newName: "IX_OrderItemsTable_productId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_orderId",
                table: "OrderItemsTable",
                newName: "IX_OrderItemsTable_orderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "OrderTable",
                newName: "IX_OrderTable_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_productId",
                table: "CartItemsTable",
                newName: "IX_CartItemsTable_productId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_cartId",
                table: "CartItemsTable",
                newName: "IX_CartItemsTable_cartId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_UserId",
                table: "CartTable",
                newName: "IX_CartTable_UserId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_WhishListTable",
                table: "WhishListTable",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsTable",
                table: "ProductsTable",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemsTable",
                table: "OrderItemsTable",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderTable",
                table: "OrderTable",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesTable",
                table: "CategoriesTable",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItemsTable",
                table: "CartItemsTable",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartTable",
                table: "CartTable",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CartItemsTable_CartTable_cartId",
                table: "CartItemsTable",
                column: "cartId",
                principalTable: "CartTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItemsTable_ProductsTable_productId",
                table: "CartItemsTable",
                column: "productId",
                principalTable: "ProductsTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartTable_User_UserId",
                table: "CartTable",
                column: "UserId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemsTable_OrderTable_orderId",
                table: "OrderItemsTable",
                column: "orderId",
                principalTable: "OrderTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemsTable_ProductsTable_productId",
                table: "OrderItemsTable",
                column: "productId",
                principalTable: "ProductsTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTable_User_UserId",
                table: "OrderTable",
                column: "UserId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsTable_CategoriesTable_categoryId",
                table: "ProductsTable",
                column: "categoryId",
                principalTable: "CategoriesTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WhishListTable_ProductsTable_productId",
                table: "WhishListTable",
                column: "productId",
                principalTable: "ProductsTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WhishListTable_User_UserId",
                table: "WhishListTable",
                column: "UserId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItemsTable_CartTable_cartId",
                table: "CartItemsTable");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItemsTable_ProductsTable_productId",
                table: "CartItemsTable");

            migrationBuilder.DropForeignKey(
                name: "FK_CartTable_User_UserId",
                table: "CartTable");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemsTable_OrderTable_orderId",
                table: "OrderItemsTable");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemsTable_ProductsTable_productId",
                table: "OrderItemsTable");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTable_User_UserId",
                table: "OrderTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsTable_CategoriesTable_categoryId",
                table: "ProductsTable");

            migrationBuilder.DropForeignKey(
                name: "FK_WhishListTable_ProductsTable_productId",
                table: "WhishListTable");

            migrationBuilder.DropForeignKey(
                name: "FK_WhishListTable_User_UserId",
                table: "WhishListTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WhishListTable",
                table: "WhishListTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsTable",
                table: "ProductsTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderTable",
                table: "OrderTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemsTable",
                table: "OrderItemsTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesTable",
                table: "CategoriesTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartTable",
                table: "CartTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItemsTable",
                table: "CartItemsTable");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "CategoriesTable");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "CategoriesTable");

            migrationBuilder.RenameTable(
                name: "WhishListTable",
                newName: "WhishList");

            migrationBuilder.RenameTable(
                name: "ProductsTable",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "OrderTable",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderItemsTable",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "CategoriesTable",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "CartTable",
                newName: "Cart");

            migrationBuilder.RenameTable(
                name: "CartItemsTable",
                newName: "CartItems");

            migrationBuilder.RenameIndex(
                name: "IX_WhishListTable_UserId",
                table: "WhishList",
                newName: "IX_WhishList_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WhishListTable_productId",
                table: "WhishList",
                newName: "IX_WhishList_productId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsTable_categoryId",
                table: "Products",
                newName: "IX_Products_categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderTable_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemsTable_productId",
                table: "OrderItems",
                newName: "IX_OrderItems_productId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemsTable_orderId",
                table: "OrderItems",
                newName: "IX_OrderItems_orderId");

            migrationBuilder.RenameIndex(
                name: "IX_CartTable_UserId",
                table: "Cart",
                newName: "IX_Cart_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItemsTable_productId",
                table: "CartItems",
                newName: "IX_CartItems_productId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItemsTable_cartId",
                table: "CartItems",
                newName: "IX_CartItems_cartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WhishList",
                table: "WhishList",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "id");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$yiqu3B16lT27ge5OkdEZdeXCJ0NdMdL/qz3qH2H.wShQuJ3UrmHNS");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_User_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Cart_cartId",
                table: "CartItems",
                column: "cartId",
                principalTable: "Cart",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_productId",
                table: "CartItems",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Order_orderId",
                table: "OrderItems",
                column: "orderId",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_productId",
                table: "OrderItems",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_categoryId",
                table: "Products",
                column: "categoryId",
                principalTable: "Category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WhishList_Products_productId",
                table: "WhishList",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WhishList_User_UserId",
                table: "WhishList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
