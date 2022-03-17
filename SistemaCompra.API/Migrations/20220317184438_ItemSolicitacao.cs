using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class ItemSolicitacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Produto_ProdutoId",
                table: "Itens");

            migrationBuilder.DropForeignKey(
                name: "FK_Itens_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Itens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Itens",
                table: "Itens");

            migrationBuilder.RenameTable(
                name: "Itens",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_SolicitacaoCompraId",
                table: "Item",
                newName: "IX_Item_SolicitacaoCompraId");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_ProdutoId",
                table: "Item",
                newName: "IX_Item_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Produto_ProdutoId",
                table: "Item",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Item",
                column: "SolicitacaoCompraId",
                principalTable: "SolicitacaoCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Produto_ProdutoId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Itens");

            migrationBuilder.RenameIndex(
                name: "IX_Item_SolicitacaoCompraId",
                table: "Itens",
                newName: "IX_Itens_SolicitacaoCompraId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_ProdutoId",
                table: "Itens",
                newName: "IX_Itens_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Itens",
                table: "Itens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Produto_ProdutoId",
                table: "Itens",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Itens",
                column: "SolicitacaoCompraId",
                principalTable: "SolicitacaoCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
