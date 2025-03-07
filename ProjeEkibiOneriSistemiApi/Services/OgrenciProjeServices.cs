using Microsoft.EntityFrameworkCore;
using ProjeEkibiOneriSistemiApi.EfCore;
using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public class OgrenciProjeServices : IOgrenciProjeServices
    {
        private readonly OgrenciAnalizDbContext _context;

        public OgrenciProjeServices(OgrenciAnalizDbContext context)
        {
            _context = context;
        }

        public async Task ekleOgrenciProje(OgrenciProje ogrenciProje)
        {
           await _context.ogrenciProjeler.AddAsync(ogrenciProje);
            _context.SaveChanges();
        }

        public Task<List<OgrenciProje>> GetOgrenciProjeler()
        {
            return _context.ogrenciProjeler.ToListAsync();
        }

        public async Task guncelleOgrenciProje(OgrenciProje ogrenciProje)
        {
            var guncelecekOgrenciProje = await _context.ogrenciProjeler.FirstOrDefaultAsync(x => x.Id == ogrenciProje.Id);
            if(guncelecekOgrenciProje is not null)
            {
                guncelecekOgrenciProje.Id = ogrenciProje.Id;
                guncelecekOgrenciProje.Rol = ogrenciProje.Rol;
                guncelecekOgrenciProje.BitisTarihi = ogrenciProje.BitisTarihi;
                guncelecekOgrenciProje.ProjeId = ogrenciProje.ProjeId;
                guncelecekOgrenciProje.OgrenciId = ogrenciProje.OgrenciId;
                guncelecekOgrenciProje.Durum = ogrenciProje.Durum;
                guncelecekOgrenciProje.BaslangicTarihi = ogrenciProje.BaslangicTarihi;
                _context.SaveChanges();
            }
        }

        public async Task silOgrenciProje(int id)
        {
            var silinecekOgrenciProje = await _context.ogrenciProjeler.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
