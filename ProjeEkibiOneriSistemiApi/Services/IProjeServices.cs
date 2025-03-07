using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public interface IProjeServices
    {
        Task<List<Proje>> GetProjeler();
        Task projeEkle(Proje proje);
        Task projeGuncelle(Proje proje);
        Task projeSil(Guid id);
    }
}

