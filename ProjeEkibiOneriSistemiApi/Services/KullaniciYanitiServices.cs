using Microsoft.EntityFrameworkCore;
using ProjeEkibiOneriSistemiApi.EfCore;
using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public class KullaniciYanitiServices : IKullaniciYanitiServices
    {
        private readonly OgrenciAnalizDbContext _context;

        public KullaniciYanitiServices(OgrenciAnalizDbContext context)
        {
            _context = context;
        }

        public async Task ekleKullaniciYaniti(KullaniciYaniti kullaniciYaniti)
        {
            await _context.kullaniciYanitlari.AddAsync(kullaniciYaniti);
            await _context.SaveChangesAsync();
        }

        public Task<List<KullaniciYaniti>> GetKullaniciYanitis()
        {
            return _context.kullaniciYanitlari.ToListAsync();
        }

        public async Task silKullaniciYaniti(int id)
        {
            var silinecekYanit = await _context.kullaniciYanitlari.FirstOrDefaultAsync(x => x.Id == id);
            if (silinecekYanit is not null)
            {
                _context.kullaniciYanitlari.Remove(silinecekYanit);
                await _context.SaveChangesAsync();
            }
        }
    }
}
