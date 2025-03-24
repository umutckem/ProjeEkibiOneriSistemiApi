using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public interface IKatilimciServices
    {
        Task<List<Katilimci>> GetKatilimcis();
        Task KatlilimciEkle(Katilimci katilimci);
        Task KatilimciSil(Guid id);
    }
}
