using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeEkibiOneriSistemiApi.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseV304 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ogrenciResmi",
                table: "Ogrenciler",
                newName: "OgrenciResmi");

            migrationBuilder.RenameColumn(
                name: "ogrenciNo",
                table: "Ogrenciler",
                newName: "OgrenciNo");

            migrationBuilder.AddColumn<float>(
                name: "OrtalamaPuan",
                table: "Ogrenciler",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ToplamCevaplananSoruSayisi",
                table: "Ogrenciler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ogrenciProjeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjeId = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ogrenciProjeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "projeler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GerekenKategoriIdler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZorlukSeviyesi = table.Column<int>(type: "int", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projeler", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ogrenciProjeler");

            migrationBuilder.DropTable(
                name: "projeler");

            migrationBuilder.DropColumn(
                name: "OrtalamaPuan",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "ToplamCevaplananSoruSayisi",
                table: "Ogrenciler");

            migrationBuilder.RenameColumn(
                name: "OgrenciResmi",
                table: "Ogrenciler",
                newName: "ogrenciResmi");

            migrationBuilder.RenameColumn(
                name: "OgrenciNo",
                table: "Ogrenciler",
                newName: "ogrenciNo");
        }
    }
}
