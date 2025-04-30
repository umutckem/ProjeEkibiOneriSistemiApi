using ProjeEkibiOneriSistemiApi.Models;

namespace ProjeEkibiOneriSistemiApi.Services
{
    public interface IRolServices
    {
        Task<List<Rol>> GetAllRol();
        Task ekleRol(Rol rol);
        Task silRol(Guid id);
    }
}
