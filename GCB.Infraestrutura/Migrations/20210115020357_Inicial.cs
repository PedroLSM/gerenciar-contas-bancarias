using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GCB.Infraestrutura.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContasBancarias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeBanco = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TipoConta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaldoAtual = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Ativa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasBancarias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Referencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnoReferencia = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    MesReferencia = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalRetirado = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    TotalDepositado = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    DiferencaSaldoAnterior = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Saldo = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referencias", x => x.Id);
                    table.UniqueConstraint("AK_Referencias_AnoReferencia_MesReferencia", x => new { x.AnoReferencia, x.MesReferencia });
                });

            migrationBuilder.CreateTable(
                name: "Extratos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContaBancariaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    TotalDepositado = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    TotalRetirado = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Extratos_ContasBancarias_ContaBancariaId",
                        column: x => x.ContaBancariaId,
                        principalTable: "ContasBancarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Extratos_Referencias_ReferenciaId",
                        column: x => x.ReferenciaId,
                        principalTable: "Referencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepositosBancarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtratoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ValorDepositado = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositosBancarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositosBancarios_Extratos_ExtratoId",
                        column: x => x.ExtratoId,
                        principalTable: "Extratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RetiradasBancarias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtratoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ValorRetirado = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetiradasBancarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetiradasBancarias_Extratos_ExtratoId",
                        column: x => x.ExtratoId,
                        principalTable: "Extratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepositosBancarios_ExtratoId",
                table: "DepositosBancarios",
                column: "ExtratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Extratos_ContaBancariaId",
                table: "Extratos",
                column: "ContaBancariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Extratos_ReferenciaId",
                table: "Extratos",
                column: "ReferenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_RetiradasBancarias_ExtratoId",
                table: "RetiradasBancarias",
                column: "ExtratoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositosBancarios");

            migrationBuilder.DropTable(
                name: "RetiradasBancarias");

            migrationBuilder.DropTable(
                name: "Extratos");

            migrationBuilder.DropTable(
                name: "ContasBancarias");

            migrationBuilder.DropTable(
                name: "Referencias");
        }
    }
}
