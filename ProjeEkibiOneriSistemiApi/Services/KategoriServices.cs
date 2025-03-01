using Microsoft.EntityFrameworkCore;
using ProjeEkibiOneriSistemiApi.EfCore;
using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public class KategoriServices : IKategoriServices
    {
        private readonly OgrenciAnalizDbContext _context;

        public KategoriServices(OgrenciAnalizDbContext context)
        {
            _context = context;
        }

        public async Task ekleKategori(Kategori kategori)
        {
            await _context.kategoriler.AddAsync(kategori);
            await _context.SaveChangesAsync();
        }

        public Task<List<Kategori>> GetKategoriListAsync()
        {
            return _context.kategoriler.ToListAsync();
        }

        public async Task removeKategori(int id)
        {
            var silinecekKategori = await _context.kategoriler.FirstOrDefaultAsync(x=>x.Id == id);
            if(silinecekKategori is not null)
            {
                _context.Remove(silinecekKategori);
                _context.SaveChanges();
            }
        }
    }
}
