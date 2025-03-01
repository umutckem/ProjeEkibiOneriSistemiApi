using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeEkibiOneriSistemiApi.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ogrenciNo",
                table: "Ogrenciler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ogrenciNo",
                table: "Ogrenciler");
        }
    }
}
