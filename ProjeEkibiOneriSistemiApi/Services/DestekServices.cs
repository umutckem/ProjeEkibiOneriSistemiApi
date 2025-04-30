using Microsoft.EntityFrameworkCore;
using ProjeEkibiOneriSistemiApi.EfCore;
using ProjeEkibiOneriSistemiApi.Models;
using System.Threading.Tasks;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public class DestekServices : IDestekServices
    {
        private readonly OgrenciAnalizDbContext _context;
        public DestekServices(OgrenciAnalizDbContext context)
        {
            _context = context;
        }
        public async Task ekleDestek(Destek destek)
        {
            await _context.desteks.AddAsync(destek);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Destek>> GetAllDestek()
        {
            return await _context.desteks.ToListAsync();
        }

        public async Task silDestek(int id)
        {
            var silinecekDestekMesajı = await _context.desteks.FindAsync(id);
            if (silinecekDestekMesajı != null)
            {
                _context.desteks.Remove(silinecekDestekMesajı);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Silinecek destek mesajı bulunamadı.");
            }
        }

    }
}
