using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailStore.Data.Migrations
{
    public partial class stockHistoryTableRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockHistory_Products_ProductId",
                table: "StockHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_StockHistory_Vendors_VendorId",
                table: "StockHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_StockHistory_Vendors_VendorId1",
                table: "StockHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockHistory",
                table: "StockHistory");

            migrationBuilder.RenameTable(
                name: "StockHistory",
                newName: "StockHistories");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistory_VendorId1",
                table: "StockHistories",
                newName: "IX_StockHistories_VendorId1");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistory_VendorId",
                table: "StockHistories",
                newName: "IX_StockHistories_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistory_ProductId",
                table: "StockHistories",
                newName: "IX_StockHistories_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockHistories",
                table: "StockHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistories_Products_ProductId",
                table: "StockHistories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistories_Vendors_VendorId",
                table: "StockHistories",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistories_Vendors_VendorId1",
                table: "StockHistories",
                column: "VendorId1",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockHistories_Products_ProductId",
                table: "StockHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_StockHistories_Vendors_VendorId",
                table: "StockHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_StockHistories_Vendors_VendorId1",
                table: "StockHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockHistories",
                table: "StockHistories");

            migrationBuilder.RenameTable(
                name: "StockHistories",
                newName: "StockHistory");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistories_VendorId1",
                table: "StockHistory",
                newName: "IX_StockHistory_VendorId1");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistories_VendorId",
                table: "StockHistory",
                newName: "IX_StockHistory_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistories_ProductId",
                table: "StockHistory",
                newName: "IX_StockHistory_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockHistory",
                table: "StockHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistory_Products_ProductId",
                table: "StockHistory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistory_Vendors_VendorId",
                table: "StockHistory",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistory_Vendors_VendorId1",
                table: "StockHistory",
                column: "VendorId1",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
