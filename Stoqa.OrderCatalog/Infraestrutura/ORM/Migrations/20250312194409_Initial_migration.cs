using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stoqa.OrderCatalog.Infraestrutura.ORM.Migrations
{
    /// <inheritdoc />
    public partial class Initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Stoqa");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Stoqa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "varchar(10)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
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
                    code = table.Column<string>(type: "varchar(50)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                schema: "Stoqa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transportType = table.Column<byte>(type: "tinyint", nullable: false),
                    freight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    trackingCode = table.Column<string>(type: "varchar(100)", nullable: false),
                    standardQuote = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrder",
                schema: "Stoqa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    quantity_ordered = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrder", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductOrder_Orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "Stoqa",
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrder_Product_product_id",
                        column: x => x.product_id,
                        principalSchema: "Stoqa",
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Return",
                schema: "Stoqa",
                columns: table => new
                {
                    orderId = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "varchar(250)", nullable: false),
                    approved = table.Column<bool>(type: "bit", nullable: false),
                    code = table.Column<string>(type: "varchar(50)", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Return", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Return_Orders_orderId",
                        column: x => x.orderId,
                        principalSchema: "Stoqa",
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Return_Transport_orderId",
                        column: x => x.orderId,
                        principalSchema: "Stoqa",
                        principalTable: "Transport",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                schema: "Stoqa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoice = table.Column<string>(type: "varchar(100)", nullable: false),
                    value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    shipping = table.Column<bool>(type: "bit", nullable: false),
                    orderId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sale_Orders_orderId",
                        column: x => x.orderId,
                        principalSchema: "Stoqa",
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sale_Transport_orderId",
                        column: x => x.orderId,
                        principalSchema: "Stoqa",
                        principalTable: "Transport",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_order_id",
                schema: "Stoqa",
                table: "ProductOrder",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_product_id",
                schema: "Stoqa",
                table: "ProductOrder",
                column: "product_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Return_orderId",
                schema: "Stoqa",
                table: "Return",
                column: "orderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_orderId",
                schema: "Stoqa",
                table: "Sale",
                column: "orderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOrder",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Return",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Sale",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Transport",
                schema: "Stoqa");
        }
    }
}
