using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stoqa.Managment.Infraestrutura.ORM.Migrations
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collaborator",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Stoqa");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Stoqa");
        }
    }
}
