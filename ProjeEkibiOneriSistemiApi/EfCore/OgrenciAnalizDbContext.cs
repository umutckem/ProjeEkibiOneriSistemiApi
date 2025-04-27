using Microsoft.EntityFrameworkCore;
using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.EfCore
{
    public class OgrenciAnalizDbContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }  // İsimlendirme düzeltildi
        public DbSet<Soru> Sorular { get; set; }
        public DbSet<KullaniciYaniti> kullaniciYanitlari { get; set; }
        public DbSet<Kategori> kategoriler { get; set; }
        public DbSet<Proje> projeler { get; set; } // İsimlendirme düzeltildi
        public DbSet<OgrenciProje> ogrenciProjeler { get; set; } // İsimlendirme düzeltildi
        public DbSet<Katilimci> katilimcilar { get; set; }
        public DbSet<Grup> grups { get; set; }


        public OgrenciAnalizDbContext(DbContextOptions<OgrenciAnalizDbContext> options) : base(options)
        {
        }
    }
}
