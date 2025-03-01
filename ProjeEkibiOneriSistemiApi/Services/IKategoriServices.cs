using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public interface IKategoriServices
    {
        Task<List<Kategori>> GetKategoriListAsync();

        Task ekleKategori(Kategori kategori);
        Task removeKategori (int id);
    }
}
