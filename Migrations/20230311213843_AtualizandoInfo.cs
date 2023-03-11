using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_API.Migrations
{
    public partial class AtualizandoInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url_Img",
                table: "Contatos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url_Img",
                table: "Contatos");
        }
    }
}
