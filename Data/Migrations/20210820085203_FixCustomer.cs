using Microsoft.EntityFrameworkCore.Migrations;

namespace TcKimlikTest.Data.Migrations
{
    public partial class FixCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Company_CompanyNameId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_TcKimlik_TcKimlikId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CompanyNameId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CompanyNameId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "TcKimlikId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Company_CompanyId",
                table: "Customers",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_TcKimlik_TcKimlikId",
                table: "Customers",
                column: "TcKimlikId",
                principalTable: "TcKimlik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Company_CompanyId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_TcKimlik_TcKimlikId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "TcKimlikId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompanyNameId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyNameId",
                table: "Customers",
                column: "CompanyNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Company_CompanyNameId",
                table: "Customers",
                column: "CompanyNameId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_TcKimlik_TcKimlikId",
                table: "Customers",
                column: "TcKimlikId",
                principalTable: "TcKimlik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
