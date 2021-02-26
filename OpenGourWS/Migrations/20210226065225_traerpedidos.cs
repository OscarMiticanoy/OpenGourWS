using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenGourWS.Migrations
{
    public partial class traerpedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Categoria_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__C929A16A82C0AF24", x => x.Categoria_Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Cliente_Id = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Mail = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Contraseña = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Cliente_Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidoResponses",
                columns: table => new
                {
                    pedido_Id = table.Column<int>(nullable: false),
                    total = table.Column<double>(nullable: false),
                    cliente = table.Column<string>(nullable: true),
                    producto = table.Column<string>(nullable: true),
                    precio = table.Column<double>(nullable: false),
                    cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Producto_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Precio = table.Column<double>(nullable: true),
                    stock = table.Column<int>(nullable: true),
                    Fk_Categoria_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Producto_Id);
                    table.ForeignKey(
                        name: "FK__Producto__Fk_Cat__29572725",
                        column: x => x.Fk_Categoria_Id,
                        principalTable: "Categoria",
                        principalColumn: "Categoria_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Pedido_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<double>(nullable: true),
                    Fk_Cliente_Id = table.Column<int>(nullable: true),
                    Fk_Producto_Id = table.Column<int>(nullable: true),
                    Cantidad = table.Column<int>(nullable: true),
                    Activo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Pedido_Id);
                    table.ForeignKey(
                        name: "FK__Pedido__Fk_Clien__2C3393D0",
                        column: x => x.Fk_Cliente_Id,
                        principalTable: "Cliente",
                        principalColumn: "Cliente_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Pedido__Fk_Produ__2D27B809",
                        column: x => x.Fk_Producto_Id,
                        principalTable: "Producto",
                        principalColumn: "Producto_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Fk_Cliente_Id",
                table: "Pedido",
                column: "Fk_Cliente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Fk_Producto_Id",
                table: "Pedido",
                column: "Fk_Producto_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Fk_Categoria_Id",
                table: "Producto",
                column: "Fk_Categoria_Id",
                unique: true,
                filter: "[Fk_Categoria_Id] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "PedidoResponses");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
