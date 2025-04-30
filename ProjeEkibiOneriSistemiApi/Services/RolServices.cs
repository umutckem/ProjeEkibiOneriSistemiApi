using Microsoft.EntityFrameworkCore;
using ProjeEkibiOneriSistemiApi.EfCore;
using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public class RolServices : IRolServices
    {
        private readonly OgrenciAnalizDbContext _context;
        public RolServices(OgrenciAnalizDbContext context)
        {
            _context = context;
        }
        public async Task ekleRol(Rol rol)
        {
            await _context.roller.AddAsync(rol);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Rol>> GetAllRol()
        {
            return await _context.roller.ToListAsync();
        }

        public Task silRol(Guid id)
        {
            var silincekRol = _context.roller.FirstOrDefaultAsync(x => x.Id == id);
            if (silincekRol != null)
            {
                _context.roller.Remove(silincekRol.Result);
                return _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Silinecek rol bulunamadı.");
            }
        }
    }
}
