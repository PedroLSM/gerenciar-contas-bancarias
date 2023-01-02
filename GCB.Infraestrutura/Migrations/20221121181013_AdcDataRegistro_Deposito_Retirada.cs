using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GCB.Infraestrutura.Migrations
{
    public partial class AdcDataRegistro_Deposito_Retirada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegistro",
                table: "RetiradasBancarias",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegistro",
                table: "DepositosBancarios",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRegistro",
                table: "RetiradasBancarias");

            migrationBuilder.DropColumn(
                name: "DataRegistro",
                table: "DepositosBancarios");
        }
    }
}
