using Microsoft.EntityFrameworkCore;
using ProjeEkibiOneriSistemiApi.EfCore;
using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public class KatilimciServices : IKatilimciServices
    {
        private readonly OgrenciAnalizDbContext _context;

        public KatilimciServices(OgrenciAnalizDbContext context)
        {
            _context = context;

        }

        public Task<List<Katilimci>> GetKatilimcis()
        {
            return _context.katilimcilar.ToListAsync();
        }

        public async Task KatilimciSil(Guid id)
        {
            var Katilimciler = await _context.katilimcilar.FirstOrDefaultAsync(x => x.Id == id);
            if (Katilimciler is not null)
            {
                _context.Remove(Katilimciler);
                _context.SaveChanges();
            }

        }

        public async Task KatlilimciEkle(Katilimci katilimci)
        {
            await _context.katilimcilar.AddAsync(katilimci);
            _context.SaveChanges();
        }
    }
}
