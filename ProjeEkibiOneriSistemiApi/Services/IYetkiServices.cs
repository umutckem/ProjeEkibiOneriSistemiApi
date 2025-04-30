using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public interface IYetkiServices
    {
        Task<List<Yetki>> GetYetkis();
        Task ekleYetki(Yetki yetki);
        Task guncelleYetki(Yetki yetki);
        Task silYetki(Guid id);
    }
}
