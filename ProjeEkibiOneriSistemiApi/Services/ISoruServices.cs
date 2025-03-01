using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public interface ISoruServices
    {
        Task<List<Soru>> GetSorus();
        Task ekleSoru(Soru soru);

        Task guncelleSoru(Soru soru);

        Task silSoru(int id);
    }
}
