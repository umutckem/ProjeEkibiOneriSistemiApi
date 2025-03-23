using Microsoft.EntityFrameworkCore;
using ProjeEkibiOneriSistemiApi.EfCore;
using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public class OgrenciServices : IOgrenciServices
    {
        private readonly OgrenciAnalizDbContext _context;

        public OgrenciServices(OgrenciAnalizDbContext context)
        {
            _context = context;
        }

        public Task<List<Ogrenci>> GetOgrencis()
        {
            return _context.Ogrenciler.ToListAsync();
        }

        public async Task ogrenciEkle(Ogrenci ogrenci)
        {
            await _context.Ogrenciler.AddAsync(ogrenci);
            await _context.SaveChangesAsync();
        }


        public async Task ogrenciGuncelle(Ogrenci ogrenci)
        {
            var guncellenecekOgrenci = await _context.Ogrenciler.FindAsync(ogrenci.Id);
            if (guncellenecekOgrenci != null)
            {
                guncellenecekOgrenci.Ad = ogrenci.Ad;
                guncellenecekOgrenci.Soyad = ogrenci.Soyad;
                guncellenecekOgrenci.Sinif = ogrenci.Sinif;
                guncellenecekOgrenci.Bolum = ogrenci.Bolum;
                guncellenecekOgrenci.Email = ogrenci.Email;
                guncellenecekOgrenci.Telefon = ogrenci.Telefon;
                guncellenecekOgrenci.OgrenciNo = ogrenci.OgrenciNo;
                guncellenecekOgrenci.TC = ogrenci.TC;
                guncellenecekOgrenci.Sifre = ogrenci.Sifre;
                guncellenecekOgrenci.OgrenciResmi = ogrenci.OgrenciResmi;
                guncellenecekOgrenci.ToplamCevaplananSoruSayisi = ogrenci.ToplamCevaplananSoruSayisi;
                guncellenecekOgrenci.OrtalamaPuan = ogrenci.OrtalamaPuan;
                guncellenecekOgrenci.AnneAdi = ogrenci.AnneAdi;
                guncellenecekOgrenci.BabaAdi = ogrenci.BabaAdi;

                await _context.SaveChangesAsync();
            }
        }



        public async Task ogrenciSil(Guid id)
        {
            var silinecekOgrenci = await _context.Ogrenciler.FirstOrDefaultAsync(x => x.Id == id);
            if(silinecekOgrenci is not null)
            {
                _context.Ogrenciler.Remove(silinecekOgrenci);
                _context.SaveChanges();
            }

        }


    }
}
