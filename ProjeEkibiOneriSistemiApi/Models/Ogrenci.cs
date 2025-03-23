namespace ProjeEkibiOneriSistemiApi.Models
{
    public class Ogrenci
    {
        public Guid Id { get; set; } 
        public string Ad { get; set; } 
        public string Soyad { get; set; }
        public string BabaAdi { get; set; }
        public string AnneAdi { get; set; }
        public string Email { get; set; } 
        public string Telefon { get; set; } 
        public string Bolum { get; set; } 
        public int Sinif { get; set; }
        public string OgrenciNo { get; set; }
        public string TC { get; set; }
        public string Sifre { get; set; }
        public string OgrenciResmi { get; set; }
        public int ToplamCevaplananSoruSayisi { get; set; }
        public float OrtalamaPuan { get; set; }

    }
}
