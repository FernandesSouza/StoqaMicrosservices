using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stoqa.ProductCatalog.Infraestrutura.ORM.Migrations
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
                name: "IX_PackagingComposition_productId",
                schema: "Stoqa",
                table: "PackagingComposition",
                column: "productId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackagingComposition",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Stoqa");
        }
    }
}
