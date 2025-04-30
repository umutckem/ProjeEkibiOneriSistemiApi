using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public interface IDestekServices
    {
        Task<List<Destek>> GetAllDestek();
        Task ekleDestek(Destek destek);
        Task silDestek(int id);

    }
}
