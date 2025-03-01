namespace ProjeEkibiOneriSistemiApi.Models
{
    public class Soru
    {
        public int Id { get; set; }
        public int KategoriId { get; set; } //İlgili Kategorinin Id'si
        public string Metin { get; set; } // Sorunun içeriği
        public string OnemDerecesi { get; set; } // 1-5 arasında bir OnemDerecesi

    }
}
