using Microsoft.EntityFrameworkCore.Migrations;

namespace production.Database.Migrations
{
    public partial class newproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Products_productId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCountry_Companies_CompanyId",
                table: "CompanyCountry");

            migrationBuilder.DropIndex(
                name: "IX_Companies_productId",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyCountry",
                table: "CompanyCountry");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "CompanyCountry",
                newName: "CompanyCountries");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCountry_CompanyId",
                table: "CompanyCountries",
                newName: "IX_CompanyCountries_CompanyId");

            migrationBuilder.AlterColumn<short>(
                name: "Color",
                table: "Products",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyCountries",
                table: "CompanyCountries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCompany_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCompany_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCompany_CompanyId",
                table: "ProductCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCompany_ProductId",
                table: "ProductCompany",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCountries_Companies_CompanyId",
                table: "CompanyCountries",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCountries_Companies_CompanyId",
                table: "CompanyCountries");

            migrationBuilder.DropTable(
                name: "ProductCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyCountries",
                table: "CompanyCountries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "CompanyCountries",
                newName: "CompanyCountry");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCountries_CompanyId",
                table: "CompanyCountry",
                newName: "IX_CompanyCountry_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "Color",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyCountry",
                table: "CompanyCountry",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_productId",
                table: "Companies",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Products_productId",
                table: "Companies",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCountry_Companies_CompanyId",
                table: "CompanyCountry",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
