using Microsoft.EntityFrameworkCore;
using ProjeEkibiOneriSistemiApi.EfCore;
using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public class YetkiServices : IYetkiServices
    {
        private readonly OgrenciAnalizDbContext _context;
        public YetkiServices(OgrenciAnalizDbContext context)
        {
            _context = context;
        }
        public async Task ekleYetki(Yetki yetki)
        {
            await _context.yetkiler.AddAsync(yetki);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Yetki>> GetYetkis()
        {
            return await _context.yetkiler.ToListAsync();
        }

        public async Task guncelleYetki(Yetki yetki)
        {
            var guncellenecekYetki = await _context.yetkiler.FirstOrDefaultAsync(x => x.Id == yetki.Id);
            if (guncellenecekYetki != null)
            {
                guncellenecekYetki.OgrenciId = yetki.OgrenciId;
                guncellenecekYetki.RolId = yetki.RolId;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Güncellenecek yetki bulunamadı.");
            }
        }

        public async Task silYetki(Guid id)
        {
            var silincekYetki = _context.yetkiler.FirstOrDefaultAsync(x => x.Id == id);
            if (silincekYetki != null)
            {
                _context.yetkiler.Remove(silincekYetki.Result);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Silinecek yetki bulunamadı.");
            }
        }
    }
}
