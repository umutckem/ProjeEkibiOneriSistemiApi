using Microsoft.EntityFrameworkCore;
using ProjeEkibiOneriSistemiApi.EfCore;
using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public class SoruServices : ISoruServices
    {
        private readonly OgrenciAnalizDbContext _ogrenciAnalizDbContext;

        public SoruServices(OgrenciAnalizDbContext ogrenciAnalizDbContext)
        {
            _ogrenciAnalizDbContext = ogrenciAnalizDbContext;
        }

        public async Task ekleSoru(Soru soru)
        {
            await _ogrenciAnalizDbContext.Sorular.AddAsync(soru);
            await _ogrenciAnalizDbContext.SaveChangesAsync();

        }

        public Task<List<Soru>> GetSorus()
        {
            return _ogrenciAnalizDbContext.Sorular.ToListAsync();
        }

        public async Task guncelleSoru(Soru soru)
        {
            var guncellenecekSoru = await _ogrenciAnalizDbContext.Sorular.FindAsync(soru.Id);
            if (guncellenecekSoru is not null) 
            {
                guncellenecekSoru.Metin = soru.Metin ;
                guncellenecekSoru.OnemDerecesi = soru.OnemDerecesi ;
                guncellenecekSoru.KategoriId = soru.KategoriId ;
                guncellenecekSoru.Cevap = soru.Cevap ;
                guncellenecekSoru.Id = soru.Id ;
                
                await _ogrenciAnalizDbContext.SaveChangesAsync() ;
            }
        }

        public async Task silSoru(int id)
        {
            var silinecekSoru = await _ogrenciAnalizDbContext.Sorular.FirstOrDefaultAsync(s => s.Id == id);
            if (silinecekSoru is not null)
            {
                _ogrenciAnalizDbContext.Sorular.Remove(silinecekSoru);
                await _ogrenciAnalizDbContext.SaveChangesAsync();
            }
        }
    }
}
