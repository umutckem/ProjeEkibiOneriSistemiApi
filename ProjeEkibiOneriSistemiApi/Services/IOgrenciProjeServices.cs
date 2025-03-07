using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public interface IOgrenciProjeServices
    {
        Task<List<OgrenciProje>> GetOgrenciProjeler();
        Task ekleOgrenciProje(OgrenciProje ogrenciProje);
        Task guncelleOgrenciProje(OgrenciProje ogrenciProje);
        Task silOgrenciProje(int id);
    }
}
