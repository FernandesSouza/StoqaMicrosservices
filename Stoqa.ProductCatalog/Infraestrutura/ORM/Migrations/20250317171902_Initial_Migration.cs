using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stoqa.ProductCatalog.Infraestrutura.ORM.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Stoqa");

            migrationBuilder.CreateTable(
                name: "Deposit",
                schema: "Stoqa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    identifier = table.Column<string>(type: "varchar(20)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Stoqa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(150)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    description = table.Column<string>(type: "varchar(250)", nullable: false),
                    code = table.Column<string>(type: "varchar(50)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "Stoqa",
                columns: table => new
                {
                    serial_code = table.Column<string>(type: "varchar(30)", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    status_item = table.Column<byte>(type: "tinyint", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Product_product_id",
                        column: x => x.product_id,
                        principalSchema: "Stoqa",
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockItem",
                schema: "Stoqa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    quantity_reserved = table.Column<int>(type: "int", nullable: false),
                    deposit_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_StockItem_Deposit_deposit_id",
                        column: x => x.deposit_id,
                        principalSchema: "Stoqa",
                        principalTable: "Deposit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockItem_Product_product_id",
                        column: x => x.product_id,
                        principalSchema: "Stoqa",
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_product_id",
                schema: "Stoqa",
                table: "Item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_deposit_id",
                schema: "Stoqa",
                table: "StockItem",
                column: "deposit_id");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_product_id",
                schema: "Stoqa",
                table: "StockItem",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "StockItem",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Deposit",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Stoqa");
        }
    }
}
