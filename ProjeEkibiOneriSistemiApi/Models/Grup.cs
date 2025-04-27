namespace ProjeEkibiOneriSistemiApi.Models
{
    public class Grup
    {
        public Guid Id { get; set; }
        public Guid OgrenciId { get; set; }
        public Guid ProjeId { get; set; }
        public int GrupNo { get; set; }
    }
}
