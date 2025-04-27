using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public interface IGrupServices
    {
        Task<List<Grup>> getGrups();
        Task ekleGrup(Grup grup);
        Task guncelleGrup(Grup grup);
        Task silGrup(Guid id);
    }
}
