using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IARA.Data.Migrations
{
    public partial class TesteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cotacao",
                columns: table => new
                {
                    IdCotacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CnpjCliente = table.Column<string>(type: "varchar(14)", nullable: false),
                    CnpjFornecedor = table.Column<string>(type: "varchar(14)", nullable: false),
                    NumeroCotacao = table.Column<int>(type: "int", nullable: false),
                    DataCotacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEntregaCotacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cep = table.Column<string>(type: "varchar(12)", nullable: true),
                    Endereco = table.Column<string>(type: "varchar(70)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(25)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(30)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(30)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(30)", nullable: true),
                    Observacao = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotacao", x => x.IdCotacao);
                });

            migrationBuilder.CreateTable(
                name: "CotacaoItem",
                columns: table => new
                {
                    ItemCotacaoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    NumeroItem = table.Column<int>(type: "int", nullable: false),
                    cotacaoIdCotacao = table.Column<int>(type: "int", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "varchar(30)", nullable: true),
                    Unidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotacaoItem", x => x.ItemCotacaoId);
                    table.ForeignKey(
                        name: "FK_CotacaoItem_Cotacao_cotacaoIdCotacao",
                        column: x => x.cotacaoIdCotacao,
                        principalTable: "Cotacao",
                        principalColumn: "IdCotacao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CotacaoItem_cotacaoIdCotacao",
                table: "CotacaoItem",
                column: "cotacaoIdCotacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotacaoItem");

            migrationBuilder.DropTable(
                name: "Cotacao");
        }
    }
}
