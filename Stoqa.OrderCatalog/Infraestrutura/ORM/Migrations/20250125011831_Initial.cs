using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stoqa.OrderCatalog.Infraestrutura.ORM.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Stoqa");

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Stoqa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "varchar(10)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
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
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrder", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductOrder_Order_order_id",
                        column: x => x.order_id,
                        principalSchema: "Stoqa",
                        principalTable: "Order",
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
                        name: "FK_Return_Order_orderId",
                        column: x => x.orderId,
                        principalSchema: "Stoqa",
                        principalTable: "Order",
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
                        name: "FK_Sale_Order_orderId",
                        column: x => x.orderId,
                        principalSchema: "Stoqa",
                        principalTable: "Order",
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

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Stoqa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "varchar(150)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    code = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_ProductOrder_id",
                        column: x => x.id,
                        principalSchema: "Stoqa",
                        principalTable: "ProductOrder",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_order_id",
                schema: "Stoqa",
                table: "ProductOrder",
                column: "order_id");

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
                name: "Product",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Return",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Sale",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "ProductOrder",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Transport",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Stoqa");
        }
    }
}
