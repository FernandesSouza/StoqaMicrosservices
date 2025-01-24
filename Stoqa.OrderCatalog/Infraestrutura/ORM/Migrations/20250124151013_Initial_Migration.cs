using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stoqa.OrderCatalog.Infraestrutura.ORM.Migrations
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
                name: "Address",
                schema: "Stoqa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street = table.Column<string>(type: "varchar(150)", nullable: false),
                    district = table.Column<string>(type: "varchar(150)", nullable: false),
                    city = table.Column<string>(type: "varchar(150)", nullable: false),
                    number = table.Column<string>(type: "varchar(150)", nullable: false),
                    complement = table.Column<string>(type: "varchar(150)", nullable: true),
                    state = table.Column<string>(type: "varchar(150)", nullable: false),
                    zipCode = table.Column<string>(type: "varchar(150)", nullable: false),
                    country = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
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
                name: "Collaborator",
                schema: "Stoqa",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(150)", nullable: false),
                    password = table.Column<string>(type: "varchar(30)", nullable: false),
                    document = table.Column<string>(type: "varchar(150)", nullable: false),
                    role = table.Column<byte>(type: "tinyint", nullable: false),
                    gender = table.Column<byte>(type: "tinyint", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborator", x => x.id);
                    table.ForeignKey(
                        name: "FK_Collaborator_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Stoqa",
                        principalTable: "Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Stoqa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(150)", nullable: false),
                    document = table.Column<string>(type: "varchar(50)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    customerType = table.Column<byte>(type: "tinyint", nullable: false),
                    address_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                    table.ForeignKey(
                        name: "FK_Customer_Address_address_id",
                        column: x => x.address_id,
                        principalSchema: "Stoqa",
                        principalTable: "Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Stoqa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    collaboratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "varchar(10)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_Collaborator_collaboratorId",
                        column: x => x.collaboratorId,
                        principalSchema: "Stoqa",
                        principalTable: "Collaborator",
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
                    description = table.Column<string>(type: "varchar(250)", nullable: false),
                    code = table.Column<string>(type: "varchar(50)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Order_id",
                        column: x => x.id,
                        principalSchema: "Stoqa",
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    id = table.Column<long>(type: "bigint", nullable: false),
                    invoice = table.Column<string>(type: "varchar(100)", nullable: false),
                    value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    shipping = table.Column<bool>(type: "bit", nullable: false),
                    orderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sale_Customer_id",
                        column: x => x.id,
                        principalSchema: "Stoqa",
                        principalTable: "Customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "PackagingComposition",
                schema: "Stoqa",
                columns: table => new
                {
                    level = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<long>(type: "bigint", nullable: false),
                    packing = table.Column<byte>(type: "tinyint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagingComposition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackagingComposition_Product_productId",
                        column: x => x.productId,
                        principalSchema: "Stoqa",
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_AddressId",
                schema: "Stoqa",
                table: "Collaborator",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_address_id",
                schema: "Stoqa",
                table: "Customer",
                column: "address_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_collaboratorId",
                schema: "Stoqa",
                table: "Order",
                column: "collaboratorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackagingComposition_productId",
                schema: "Stoqa",
                table: "PackagingComposition",
                column: "productId");

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
                name: "PackagingComposition",
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
                name: "Customer",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Transport",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Collaborator",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Stoqa");
        }
    }
}
