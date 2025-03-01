using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public interface IOgrenciServices
    {
        Task<List<Ogrenci>> GetOgrencis();
        Task ogrenciEkle (Ogrenci ogrenci);
        Task ogrenciGuncelle(Ogrenci ogrenci);
        Task ogrenciSil (Guid id);
    }
}
