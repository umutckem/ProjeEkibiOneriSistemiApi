using Microsoft.EntityFrameworkCore;
using ProjeEkibiOneriSistemiApi.EfCore;
using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public class ProjeServices : IProjeServices
    {
        private readonly OgrenciAnalizDbContext _context;

        public ProjeServices(OgrenciAnalizDbContext context)
        {
            _context = context;
        }

        public Task<List<Proje>> GetProjeler()
        {
            return _context.projeler.ToListAsync();
        }

        public async Task projeEkle(Proje proje)
        {
            await _context.projeler.AddAsync(proje);
            await _context.SaveChangesAsync();
        }

        public async Task projeGuncelle(Proje proje)
        {
            var guncellenecekProje = await _context.projeler.FindAsync(proje.Id);
            if(guncellenecekProje is not null)
            {
                guncellenecekProje.Id = proje.Id;
                guncellenecekProje.Ad = proje.Ad;
                guncellenecekProje.Aciklama= proje.Aciklama;
                guncellenecekProje.AktifMi = proje.AktifMi;
                guncellenecekProje.BaslangicTarihi = proje.BaslangicTarihi;
                guncellenecekProje.BitisTarihi = proje.BitisTarihi;
                guncellenecekProje.GerekenKategoriIdler = proje.GerekenKategoriIdler;
                guncellenecekProje.ZorlukSeviyesi = proje.ZorlukSeviyesi;
                guncellenecekProje.Bolum = proje.Bolum;
                await _context.SaveChangesAsync();
            }
        }

        public async Task projeSil(Guid id)
        {
            var silinecekProje = await _context.projeler.FirstOrDefaultAsync(x => x.Id == id);
            if (silinecekProje is not null)
            {
                _context.projeler.Remove(silinecekProje);
                _context.SaveChanges();
            }
        }
    }
}
