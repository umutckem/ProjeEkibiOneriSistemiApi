using Microsoft.EntityFrameworkCore;
using ProjeEkibiOneriSistemiApi.EfCore;
using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public class GrupServices : IGrupServices
    {
        private readonly OgrenciAnalizDbContext _context;

        public GrupServices(OgrenciAnalizDbContext context)
        {
            _context = context;
        }

        public async Task ekleGrup(Grup grup)
        {
            await _context.grups.AddAsync(grup);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Grup>> getGrups()
        {
            return await _context.grups.ToListAsync();
        }

        public async Task guncelleGrup(Grup grup)
        {
            var _grup = await _context.grups.FindAsync(grup.Id);
            if (_grup is not null)
            {
                _grup.GrupNo = grup.GrupNo;
                _grup.OgrenciId = grup.OgrenciId;
                _grup.ProjeId = grup.ProjeId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task silGrup(Guid id)
        {
            var silinecekGrup = await _context.grups.FirstOrDefaultAsync(x => x.Id == id);
            if (silinecekGrup is not null)
            {
                _context.grups.Remove(silinecekGrup);
                await _context.SaveChangesAsync();
            }
        }
    }
}
