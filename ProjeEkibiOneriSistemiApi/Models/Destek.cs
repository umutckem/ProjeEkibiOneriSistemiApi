namespace ProjeEkibiOneriSistemiApi.Models
{
    public class Destek
    {
        public int Id { get; set; }
        public Guid AdminId { get; set; }
        public string AdminCevap { get; set; }
        public Guid OgrenciId { get; set; }
        public string Konu { get; set; }
        public string Açıklama { get; set; }
        public DateOnly OlusturmaTarihi { get; set; }
    }
}
