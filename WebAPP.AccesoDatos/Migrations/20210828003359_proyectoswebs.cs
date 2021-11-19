using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPP.AccesoDatos.Migrations
{
    public partial class proyectoswebs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectoswebs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    FechaCreacion = table.Column<string>(nullable: true),
                    UrlImagen = table.Column<string>(nullable: true),
                    CategoriaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectoswebs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyectoswebs_Categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proyectoswebs_CategoriaID",
                table: "Proyectoswebs",
                column: "CategoriaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proyectoswebs");
        }
    }
}
