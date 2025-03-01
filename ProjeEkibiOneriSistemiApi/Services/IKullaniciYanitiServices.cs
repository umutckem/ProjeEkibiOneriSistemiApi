using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public interface IKullaniciYanitiServices
    {
        Task<List<KullaniciYaniti>> GetKullaniciYanitis();
        Task ekleKullaniciYaniti(KullaniciYaniti kullaniciYaniti);
        Task silKullaniciYaniti(int id);
    }
}
