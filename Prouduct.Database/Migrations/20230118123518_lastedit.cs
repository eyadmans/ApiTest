using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace production.Database.Migrations
{
    public partial class lastedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCompany_Companies_CompanyId",
                table: "ProductCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCompany_Products_ProductId",
                table: "ProductCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCompany",
                table: "ProductCompany");

            migrationBuilder.RenameTable(
                name: "ProductCompany",
                newName: "ProductCompanies");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCompany_ProductId",
                table: "ProductCompanies",
                newName: "IX_ProductCompanies_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCompany_CompanyId",
                table: "ProductCompanies",
                newName: "IX_ProductCompanies_CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditDate",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerName",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Companies",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Companies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditDate",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCompanies",
                table: "ProductCompanies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCompanies_Companies_CompanyId",
                table: "ProductCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCompanies_Products_ProductId",
                table: "ProductCompanies",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCompanies_Companies_CompanyId",
                table: "ProductCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCompanies_Products_ProductId",
                table: "ProductCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCompanies",
                table: "ProductCompanies");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastEditDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastEditDate",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "ProductCompanies",
                newName: "ProductCompany");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCompanies_ProductId",
                table: "ProductCompany",
                newName: "IX_ProductCompany_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCompanies_CompanyId",
                table: "ProductCompany",
                newName: "IX_ProductCompany_CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerName",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCompany",
                table: "ProductCompany",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCompany_Companies_CompanyId",
                table: "ProductCompany",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCompany_Products_ProductId",
                table: "ProductCompany",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
